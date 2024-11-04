using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SupplyChainManagement.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SupplyChainManagement.Controllers
{
    public class PurchaseRequisitionController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly string textile;
        private readonly string scm;
        private readonly DBService _queryService;
        public PurchaseRequisitionController(IConfiguration configuration, DBService DBService)
        {
            _configuration = configuration;
            textile = _configuration.GetConnectionString("TextileConnection");
            scm = _configuration.GetConnectionString("DefaultConnection");
            _queryService = DBService;
        }
        public IActionResult Index()
        {
            PRPending model = new PRPending();
            model.EWOBookings = GetBookingsForEWO();


            return View(model);
        }

        public IActionResult Edit(int bookingId)
        {
            PurchaseRequisition model = new PurchaseRequisition();
            model.PRID = 0;
            model.PRNumber = "YPR" + bookingId;
            model.PRDate= DateTime.Now;


            return View(model);
        }

        List<BookingInfo> GetBookingsForEWO()
        {
            List<BookingInfo> bookings = new List<BookingInfo>();


            string textileQuery = $"SELECT  distinct YBM.YBookingID, YBM.YBookingNo, FBM.ExportOrderID,FBM.BookingID ,BookingNo, c.Name,   FBM.BuyerTeamID  , StyleNo  \r\nFROM FBookingAcknowledge FBM\r\ninner join FBookingAcknowledgeChild FBC on FBC.AcknowledgeID = FBM.FBAckID\r\ninner join YarnBookingMaster_New YBM on  YBM.BookingID=FBM.BookingID\r\ninner join EPYSL..Contacts c  on c.ContactID = FBM.BuyerID\r\nwhere  FBM.ExportOrderID in (\r\n'26490',\r\n'24185'\r\n)";

            var textileResults = _queryService.ExecuteQuery(textile, textileQuery);

            foreach (var reader in textileResults)
            {

                BookingInfo b = new BookingInfo();

                b.YBookingID = reader["YBookingID"] != DBNull.Value ? Convert.ToInt32(reader["YBookingID"]) : 0;
                b.ExportOrderID = reader["ExportOrderID"] != DBNull.Value ? Convert.ToInt32(reader["ExportOrderID"]) : 0;
                b.FabricBookingNo = reader["BookingNo"] != DBNull.Value ? reader["BookingNo"].ToString() : string.Empty;
                b.YarnBookingNo = reader["YBookingNo"] != DBNull.Value ? reader["YBookingNo"].ToString() : string.Empty;
                b.BuyerName = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                b.BuyerTeamID = reader["BuyerTeamID"] != DBNull.Value ? Convert.ToInt32(reader["BuyerTeamID"]) : 0;
                b.StyleNo = reader["StyleNo"] != DBNull.Value ? reader["StyleNo"].ToString() : string.Empty;

                bookings.Add(b);


            }
            return bookings;

        }




    }
}
