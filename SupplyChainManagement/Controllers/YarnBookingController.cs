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
            return View(yarnbookingData);
        }


        private List<YarnBookingMasterDto> GetUnacknowledgedYarnBookingsAsync()
        {
            var query = from yb in _context.YarnBookingMasters
                        join yc in _context.YarnBookingChilds on yb.YarnBookingMasterId equals yc.YarnBookingMasterId
                        join im in _context.ItemMasters on yc.ItemMasterId equals im.ItemMasterId
                        join fy in _context.FabricYarns on yc.ItemMasterId equals fy.YarnId
                        join fab in _context.ItemMasters on fy.FabricId equals fab.ItemMasterId
                        where yb.IsAcknowledge == 0
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



        
    }
}
