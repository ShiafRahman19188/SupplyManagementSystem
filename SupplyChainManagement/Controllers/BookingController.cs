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


        //[HttpPost]
        //public async Task<IActionResult> SaveYarns([FromBody] SaveYarnRequestDto request)
        //{
        //    if (request == null || request.Yarns == null || request.Yarns.Count == 0)
        //    {
        //        return BadRequest("Invalid data.");
        //    }

        //    var bookingMasterId = request.BookingMasterId;

        //    // Loop through the yarns and save each one to the database
        //    foreach (var yarnName in request.Yarns)
        //    {
        //        var newYarn = new Yarn
        //        {
        //            BookingMasterId = bookingMasterId,
        //            YarnName = yarnName
        //        };

        //        _context.Yarns.Add(newYarn);
        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok("Yarns saved successfully.");
        //}




    }
}
