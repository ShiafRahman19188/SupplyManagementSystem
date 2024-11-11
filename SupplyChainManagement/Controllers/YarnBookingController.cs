using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;
using SupplyChainManagement.DTO;
using SupplyChainManagement.Models;

namespace SupplyChainManagement.Controllers
{
    public class YarnBookingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SCMDbContext _context;

        public YarnBookingController(IConfiguration configuration, SCMDbContext context)
        {
            _configuration = configuration;

            _context = context;
        }
        public IActionResult Index()
        {
            var yarnbookingData = GetUnacknowledgedYarnBookingsAsync();
            var yarnSummary = _context.YarnBookingChilds
        .Join(_context.ItemMasters, c => c.ItemMasterId, im => im.ItemMasterId, (c, im) => new { c, im })
        .GroupBy(x => x.im.ItemName)
        .Select(g => new
        {
            YarnName = g.Key,
            TotalQuantity = g.Sum(x => x.c.Quantity)
        })
        .ToList();

            ViewBag.YarnSummary = yarnSummary;
            return View(yarnbookingData);
        }


        private List<YarnBookingMasterDto> GetUnacknowledgedYarnBookingsAsync()
        {
            var query = from yb in _context.YarnBookingMasters
                        join yc in _context.YarnBookingChilds on yb.YarnBookingMasterId equals yc.YarnBookingMasterId
                        join im in _context.ItemMasters on yc.ItemMasterId equals im.ItemMasterId
                        join fy in _context.FabricYarns on yc.ItemMasterId equals fy.YarnId
                        join fab in _context.ItemMasters on fy.FabricId equals fab.ItemMasterId
                        
                        select new
                        {
                            yb.YarnBookingMasterId,
                            yb.YarnBookingMasterNo,
                            FabricName = fab.ItemName,
                            YarnName = im.ItemName,
                            yb.IsAcknowledge,
                            Quantity = yc.Quantity,
                            yc.YarnBookingChildId,
                            yc.ItemMasterId
                        };

            var groupedData = query
                .GroupBy(x => new { x.YarnBookingMasterId, x.YarnBookingMasterNo, x.FabricName, x.IsAcknowledge })
                .Select(g => new YarnBookingMasterDto
                {
                    YarnBookingMasterId = g.Key.YarnBookingMasterId,
                    YarnBookingMasterNo = g.Key.YarnBookingMasterNo,
                    FabricName = g.Key.FabricName,
                    IsAcknowledge = g.Key.IsAcknowledge,
                    yarnBookingChildren = g.Select(x => new YarnBookingChildDto
                    {
                        YarnBookingChildId = x.YarnBookingChildId,
                        ItemMasterId = x.ItemMasterId,
                        YarnBookingMasterId=x.YarnBookingMasterId,
                        YarnName = x.YarnName,
                        Quantity = x.Quantity
                    }).ToList()
                })
                .ToList();

            return groupedData;
        }




        [HttpPost]
        public IActionResult Acknowledge([FromForm] int yarnBookingMasterId)
        {
            var booking = _context.YarnBookingMasters.FirstOrDefault(ym => ym.YarnBookingMasterId == yarnBookingMasterId);

            if (booking != null && booking.IsAcknowledge == 0)
            {
                booking.IsAcknowledge = 1;

                var bookingChildren = _context.YarnBookingChilds
                                      .Where(yc => yc.YarnBookingMasterId == yarnBookingMasterId)
                                      .Include(yc => yc.YarnBookingMaster)
                                      .AsEnumerable(); 

                var requisitions = new List<PurchaseRequisitionMaster>();

                foreach (var item in bookingChildren)
                {
                    var requisition = new PurchaseRequisitionMaster
                    {
                        PRNo = "PR-" + item.ItemMasterId,
                        PRDate = DateTime.Now,
                        ItemYarnId = item.ItemMasterId,
                        TotalQuantity = item.Quantity,
                        YarnBookingMasterId = yarnBookingMasterId,
                    };

                    _context.PurchaseRequisitionMasters.Add(requisition);
                    requisitions.Add(requisition);
                }

                _context.SaveChanges(); 

                foreach (var requisition in requisitions)
                {
                    requisition.PRNo = "PR-" + requisition.PurchaseRequisitionMasterId;
                }

                _context.PurchaseRequisitionMasters.UpdateRange(requisitions);
                _context.SaveChanges(); 

                return Ok();
            }

            return BadRequest("Unable to acknowledge booking.");
        }





        public IActionResult GetYarnSummary()
        {

            var yarnSummary = _context.YarnBookingChilds
            .Join(_context.YarnBookingMasters, c => c.YarnBookingMasterId, yb => yb.YarnBookingMasterId, (c, yb) => new { c, yb })
            .Join(_context.ItemMasters, combined => combined.c.ItemMasterId, im => im.ItemMasterId, (combined, im) => new { combined.c, im, combined.yb })
            .Where(x => x.yb.IsAcknowledge == 1) 
            .GroupBy(x => new { x.im.ItemMasterId, x.im.ItemName }) 
            .Select(g => new YarnBookingChildDto
            {
                ItemMasterId = g.Key.ItemMasterId, 
                YarnName = g.Key.ItemName, 
                TotalQuantity = g.Sum(x => x.c.Quantity) ,
                
            })
            .ToList();

            foreach (var summary in yarnSummary)
            {
               
                summary.yarnBookingDetails = GetYarnBookingDetails(summary.ItemMasterId);
            }

            return Json(yarnSummary);
        }


        public List<YarnBookingDetailsDto> GetYarnBookingDetails(int itemMasterId)
        {
            var yarnBookingDetails = _context.YarnBookingMasters
                .Join(_context.YarnBookingChilds, yb => yb.YarnBookingMasterId, yc => yc.YarnBookingMasterId, (yb, yc) => new { yb, yc })
                .Join(_context.ItemMasters, combined => combined.yc.ItemMasterId, im => im.ItemMasterId, (combined, im) => new { combined.yb, combined.yc, im })
                .Join(_context.FabricYarns, combined => combined.yc.ItemMasterId, fy => fy.YarnId, (combined, fy) => new { combined.yb, combined.yc, combined.im, fy })
                .Join(_context.ItemMasters, combined => combined.fy.FabricId, fab => fab.ItemMasterId, (combined, fab) => new { combined.yb, combined.yc, combined.im, combined.fy, fab })
                .Where(x => x.yc.ItemMasterId == itemMasterId) 
                .Select(x => new YarnBookingDetailsDto
                {
                    YarnBookingMasterId = x.yb.YarnBookingMasterId,
                    YarnBookingMasterNo = x.yb.YarnBookingMasterNo,
                    FabricId = x.fy.FabricId,
                    Fabric = x.fab.ItemName,
                    Quantity = x.yc.Quantity
                })
                
                .ToList();

            return yarnBookingDetails;
        }

        


    }
}
