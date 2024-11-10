using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;
using SupplyChainManagement.DTO;

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
                            Quantity = yc.Quantity
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
            var booking = _context.YarnBookingMasters.Find(yarnBookingMasterId);
            if (booking != null && booking.IsAcknowledge == 0)
            {
                booking.IsAcknowledge = 1;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest("Unable to acknowledge booking.");
        }


        public IActionResult GetYarnSummary()
        {
            var yarnSummary = _context.YarnBookingChilds
                .Join(_context.YarnBookingMasters, c => c.YarnBookingMasterId, yb => yb.YarnBookingMasterId, (c, yb) => new { c, yb })
                .Join(_context.ItemMasters, combined => combined.c.ItemMasterId, im => im.ItemMasterId, (combined, im) => new { combined.c, im })
                .GroupBy(x => x.im.ItemName)
                .Select(g => new YarnSummaryDto
                {
                    YarnName = g.Key,
                    TotalQuantity = g.Sum(x => x.c.Quantity)
                })
                .ToList();

            return Json(yarnSummary);
        }


    }
}
