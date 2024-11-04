﻿using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.Models;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            model.ItemDetails = GetItems(bookingId);

            return View(model);
        }

         List<PRDetails> GetItems(int bookingId)
        {


            List<PRDetails> items = new List<PRDetails>();


            string textileQuery = $" select IM.ItemMasterID,im.DisplayItemName,sum(ch.BookingQty)qty,ShadeCode,u.UnitDesc from YarnBookingChild_New ch\r\n  inner join YarnBookingChildItem_New chi on chi.YBChildID=ch.YBChildID\r\n  left join EPYSL..ItemMaster IM ON  IM.ItemMasterID = ch.ItemMasterID\r\n  inner join EPYSL..Unit u on chi.UnitID=u.UnitID\r\n  where ch.YBookingID="+ bookingId + "  group by IM.ItemMasterID,im.DisplayItemName,ShadeCode,UnitDesc";

            var textileResults = _queryService.ExecuteQuery(textile, textileQuery);

            foreach (var reader in textileResults)
            {

                PRDetails item = new PRDetails();

                item.ItemMasterID = reader["ItemMasterID"] != DBNull.Value ? Convert.ToInt32(reader["ItemMasterID"]) : 0;
                item.ItemName = reader["DisplayItemName"] != DBNull.Value ? reader["DisplayItemName"].ToString() : string.Empty;
                item.PRQuantity = reader["qty"] != DBNull.Value ? Convert.ToInt32(reader["qty"]) : 0;
                item.ShadeCode = reader["ShadeCode"] != DBNull.Value ? reader["ShadeCode"].ToString() : string.Empty;
                item.UOM= reader["UnitDesc"] != DBNull.Value ? reader["UnitDesc"].ToString() : string.Empty;
                item.UnitPrice = 0;
                items.Add(item);


            }
            return items;


        }

        public JsonResult GetPRInsight(int ItemMasterId)
        {


            List<ItemInsight> items = new List<ItemInsight>();


            string textileQuery = $" select top 10 ch.poqty,rate,ch.QuotationRefNo,con.CountryName,c.Name from YarnPOChild ch inner join YarnPOMaster po on po.YPOMasterID = ch.YPOMasterID inner join EPYSL..Contacts c on c.ContactID = po.SupplierID inner join EPYSL..country con on con.CountryID = CountryOfOriginID where ItemMasterID = "+ ItemMasterId + " order by po.DateAdded desc";

            var textileResults = _queryService.ExecuteQuery(textile, textileQuery);

            foreach (var reader in textileResults)
            {

                ItemInsight item = new ItemInsight();

                item.POQty = reader["POQty"] != DBNull.Value ? Convert.ToDecimal(reader["POQty"]) : 0;
                item.Rate = reader["Rate"] != DBNull.Value ? Convert.ToDecimal(reader["Rate"]) : 0;
                item.QuotationRefNo = reader["QuotationRefNo"] != DBNull.Value ? reader["QuotationRefNo"].ToString() : string.Empty;
                item.CountryName = reader["CountryName"] != DBNull.Value ? reader["CountryName"].ToString() : string.Empty;
                item.SupplierName = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                items.Add(item);


            }
            return Json(items);


        }

        List<BookingInfo> GetBookingsForEWO()
        {
            List<BookingInfo> bookings = new List<BookingInfo>();


            string textileQuery = $"SELECT  distinct YBM.YBookingID, YBM.YBookingNo, FBM.ExportOrderID,FBM.BookingID ,BookingNo, c.Name,   FBM.BuyerTeamID  , StyleNo  \r\nFROM FBookingAcknowledge FBM\r\ninner join FBookingAcknowledgeChild FBC on FBC.AcknowledgeID = FBM.FBAckID\r\ninner join YarnBookingMaster_New YBM on  YBM.BookingID=FBM.BookingID\r\ninner join EPYSL..Contacts c  on c.ContactID = FBM.BuyerID\r\nwhere  FBM.ExportOrderID in (21747,23048,23068,23512,23975)";

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
