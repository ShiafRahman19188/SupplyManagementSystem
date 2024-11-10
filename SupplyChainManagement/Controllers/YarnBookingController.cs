using Microsoft.AspNetCore.Mvc;
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
            var yarnbookingData = GetUnacknowledgedYarnBookings();
            return View(yarnbookingData);
        }

        private List<YarnBookingMasterDto> GetUnacknowledgedYarnBookings()
        {
            var query = from yb in _context.YarnBookingMasters
                        join yc in _context.YarnBookingChilds on yb.YarnBookingMasterId equals yc.YarnBookingMasterId
                        join im in _context.ItemMasters on yc.ItemMasterId equals im.ItemMasterId
                        join fy in _context.FabricYarns on yc.ItemMasterId equals fy.YarnId
                        join fab in _context.ItemMasters on fy.FabricId equals fab.ItemMasterId
                        where yb.IsAcknowledge == 0
                        select new YarnBookingMasterDto
                        {
                            YarnBookingMasterId = yb.YarnBookingMasterId,
                            YarnBookingMasterNo = yb.YarnBookingMasterNo,
                            FabricName = fab.ItemName,
                            YarnName = im.ItemName,
                            IsAcknowledge = yb.IsAcknowledge,
                            FabricId = fy.FabricId,
                            YarnId = im.ItemMasterId,
                            yarnBookingChildren = new List<YarnBookingChildDto>
                        {
                            new YarnBookingChildDto
                            { 

                                Quantity = yc.Quantity 
                            }
                        }
                        };

            return  query.ToList();
        }
    }
}
