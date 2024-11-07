using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.Db;
using SupplyChainManagement.DTO;
using SupplyChainManagement.Models;

namespace SupplyChainManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SCMDbContext _context;

        public BookingController(IConfiguration configuration, SCMDbContext context)
        {
            _configuration = configuration;

            _context = context;
        }
        public IActionResult Index()
        {
            var bookingData = GetBookingData();
            return View(bookingData);

        }


        private List<BookingInfoDto> GetBookingData()
        {
            return _context.BookingMasters
                .Select(bm => new BookingInfoDto
                {
                    BookingMasterId = bm.BookingMasterId,
                    BookingMasterNo = bm.BookingMasterNo,
                    ExportWorkOrder = bm.ExportWorkOrder,
                    StyleNo = bm.StyleNo,
                    Fabric = _context.ItemMasters
                        .Where(im => im.ItemMasterId == _context.BookingChild
                            .Where(bc => bc.BookingMasterId == bm.BookingMasterId)
                            .Select(bc => bc.ItemMasterId)
                            .FirstOrDefault())
                        .Select(im => im.ItemName)
                        .FirstOrDefault(),
                    SupplierName = _context.Suppliers
                        .Where(sup => sup.SupplierId == bm.SupplierId)
                        .Select(sup => sup.SupplierName)
                        .FirstOrDefault(),
                    Yarns = (from bc in _context.BookingChild
                             join im in _context.ItemMasters on bc.ItemMasterId equals im.ItemMasterId
                             join fy in _context.FabricYarns on im.ItemMasterId equals fy.FabricId
                             join imy in _context.ItemMasters on fy.YarnId equals imy.ItemMasterId
                             where bc.BookingMasterId == bm.BookingMasterId
                             select new YarnInfo
                             {
                                 YarnId = imy.ItemMasterId,
                                 Yarn = imy.ItemName
                             }).ToList()
                }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> SaveYarns([FromBody] SaveYarnRequest request)
        {
            if (request == null || request.Yarns == null || request.Yarns.Count == 0)
            {
                return BadRequest("Invalid request.");
            }

            var booking = _context.BookingChild.FirstOrDefault(i => i.BookingMasterId == request.BookingMasterId);

            
            var FabricBookingName = _context.BookingMasters
                                             .Where(i => i.BookingMasterId == request.BookingMasterId)
                                             .Select(i => i.BookingMasterNo)
                                             .FirstOrDefault();

            
            var existingYarnBookingMaster = _context.YarnBookingMasters
                                                    .FirstOrDefault(ybm => ybm.YarnBookingMasterNo == FabricBookingName + "-YB");

           
            if (existingYarnBookingMaster == null)
            {
                existingYarnBookingMaster = new YarnBookingMaster
                {
                    YarnBookingMasterNo = FabricBookingName + "-YB",
                    IsAcknowledge = 1
                };
                _context.YarnBookingMasters.Add(existingYarnBookingMaster);
                await _context.SaveChangesAsync();
            }

            foreach (var yarn in request.Yarns)
            {
                var itemMaster = _context.ItemMasters.FirstOrDefault(i => i.ItemName == yarn.Name);

                if (itemMaster == null)
                {
                    
                    itemMaster = new ItemMaster
                    {
                        ItemName = yarn.Name,
                        DisplayItemName = yarn.Name,
                        ItemGroupId = 2,
                        ItemSubGroupId = 2
                    };
                    _context.ItemMasters.Add(itemMaster);
                    await _context.SaveChangesAsync();

                    
                    var fabricYarn = new FabricYarn
                    {
                        FabricId = booking.ItemMasterId,
                        YarnId = itemMaster.ItemMasterId
                    };
                    _context.FabricYarns.Add(fabricYarn);
                }

                if (yarn.Selected)
                {
                   
                    var yarnBookingChild = new YarnBookingChild
                    {
                        YarnBookingMasterId = existingYarnBookingMaster.YarnBookingMasterId,
                        ItemMasterId = itemMaster.ItemMasterId,
                        Quantity = Convert.ToInt64(yarn.PoQuantity)
                    };

                    _context.YarnBookingChilds.Add(yarnBookingChild);
                }
            }

            
            await _context.SaveChangesAsync();

            return Ok();
        }



       




    }
}
