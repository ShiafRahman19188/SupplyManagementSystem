﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;
using SupplyChainManagement.DTO;
using SupplyChainManagement.Models;
using System.ComponentModel.DataAnnotations;
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
        private readonly SCMDbContext _context;
        public PurchaseRequisitionController(IConfiguration configuration, DBService DBService, SCMDbContext context)
        {
            _configuration = configuration;
            textile = _configuration.GetConnectionString("TextileConnection");
            scm = _configuration.GetConnectionString("DefaultConnection");
            _queryService = DBService;
            _context = context;
        }
        public IActionResult Index()
        {
            PRPending model = new PRPending();
            //model.EWOBookings = GetBookingsForEWO();
            model.PurchaseRequisitionMasterDtos = GetPR();


            return View(model);
        }

        public IActionResult Edit(int bookingId)
        {
            PurchaseRequisition model = new PurchaseRequisition();
            model.PRID = 0;
            model.PRNumber = "YPR" + bookingId;
            model.PRDate= DateTime.Now;
            model.Requisitionar = "Md.  Shiafur Rahman";
            model.DeliveryUnit = "Warehouse";
            model.ItemDetails = GetItems(bookingId);

            return View(model);
        }

         List<PRDetails> GetItems(int bookingId)
        {


            List<PRDetails> items = new List<PRDetails>();


            string textileQuery = $" select yn.YBookingNo,IM.ItemMasterID,im.DisplayItemName,sum(ch.BookingQty)qty,ShadeCode,u.UnitDesc from YarnBookingChild_New ch\r\n  inner join YarnBookingChildItem_New chi on chi.YBChildID=ch.YBChildID\r\n  left join EPYSL..ItemMaster IM ON  IM.ItemMasterID = ch.ItemMasterID\r\n  inner join EPYSL..Unit u on chi.UnitID=u.UnitID\r\ninner join YarnBookingMaster_New yn on yn.YBookingID=ch.YBookingID\r\n  where ch.YBookingID=" + bookingId + "  group by IM.ItemMasterID,im.DisplayItemName,ShadeCode,UnitDesc,yn.YBookingNo";

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
                item.YBookingNo = reader["YBookingNo"] != DBNull.Value ? reader["YBookingNo"].ToString() : string.Empty;
                items.Add(item);


            }
            return items;


        }


        [HttpPost]
        public IActionResult SavePurchaseRequisition([FromBody] PurchaseRequisition model)
        {
            if (!ModelState.IsValid)
            {
                PurchaseRequisition purchaseRequisition = new PurchaseRequisition();
                purchaseRequisition.PRNumber = model.PRNumber;
                purchaseRequisition.PRDate = model.PRDate;
                purchaseRequisition.DeliveryDate = model.DeliveryDate;
                purchaseRequisition.DeliveryUnit = model.DeliveryUnit;
                purchaseRequisition.Supplier= model.Supplier;
                purchaseRequisition.Requisitionar= model.Requisitionar;



                _context.PurchaseRequisitions.Add(purchaseRequisition);
                _context.SaveChanges();
                var user = _context.PurchaseRequisitions.FirstOrDefault(i => i.PRNumber == purchaseRequisition.
                PRNumber);

                PRDetails purchaseDetails = new PRDetails();
                foreach (var item in model.ItemDetails)
                {
                   purchaseDetails.PurchaseRequisitionPRID= purchaseRequisition.PRID;
                    purchaseDetails.ItemMasterID = item.ItemMasterID;
                    purchaseDetails.UnitPrice = item.UnitPrice;
                    purchaseDetails.LeadTime = item.LeadTime;
                    purchaseDetails.UOM= item.UOM;
                    purchaseDetails.PRQuantity = item.PRQuantity;
                    purchaseDetails.ItemName = item.ItemName;
                    purchaseDetails.ShadeCode = item.ShadeCode;
                    _context.ItemDetails.Add(purchaseDetails);

                }
                _context.SaveChanges();

             
                return RedirectToAction("Index"); 
            }

            
            return View("Edit", model); 
        }

        public IActionResult GetPRInsight(int ItemMasterId)
        {


            List<ItemInsight> items = new List<ItemInsight>();


            string textileQuery = $"select top 10 ch.poqty poqty,rate,ch.QuotationRefNo,con.CountryName,ReceiveDate,po.DateAdded,\r\nc.Name from YarnPOChild ch \r\ninner join YarnPOMaster po on po.YPOMasterID = ch.YPOMasterID \r\ninner join YarnReceiveMaster rm on rm.POID=po.YPOMasterID\r\ninner join EPYSL..Contacts c on c.ContactID = po.SupplierID \r\ninner join EPYSL..country con on con.CountryID = CountryOfOriginID  where ItemMasterID = " + ItemMasterId + " order by po.DateAdded desc";

            var textileResults = _queryService.ExecuteQuery(textile, textileQuery);

            foreach (var reader in textileResults)
            {

                ItemInsight item = new ItemInsight();

                item.POQty = reader["poqty"] != DBNull.Value ? Convert.ToDecimal(reader["poqty"]) : 0;
                item.Rate = reader["rate"] != DBNull.Value ? Convert.ToDecimal(reader["rate"]) : 0;
                item.QuotationRefNo = reader["QuotationRefNo"] != DBNull.Value ? reader["QuotationRefNo"].ToString() : string.Empty;
                item.CountryName = reader["CountryName"] != DBNull.Value ? reader["CountryName"].ToString() : string.Empty;
                item.SupplierName = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
                item.POdate = reader["DateAdded"] != DBNull.Value ? reader["DateAdded"].ToString() : string.Empty;
                item.ReceivedDate = reader["ReceiveDate"] != DBNull.Value ? reader["ReceiveDate"].ToString() : string.Empty;
                items.Add(item);

                
            }
            // return Json(items);
            return PartialView("_ItemInsightPartial", items);



        }

        List<BookingInfo> GetBookingsForEWO()
        {
            List<BookingInfo> bookings = new List<BookingInfo>();


            string textileQuery = $"SELECT   distinct top 5 YBM.YBookingID, YBM.YBookingNo, FBM.ExportOrderID,FBM.BookingID ,BookingNo, c.Name,   FBM.BuyerTeamID  , StyleNo  \r\nFROM FBookingAcknowledge FBM\r\ninner join FBookingAcknowledgeChild FBC on FBC.AcknowledgeID = FBM.FBAckID\r\ninner join YarnBookingMaster_New YBM on  YBM.BookingID=FBM.BookingID\r\ninner join EPYSL..Contacts c  on c.ContactID = FBM.BuyerID\r\nwhere  FBM.ExportOrderID in (21747,23048,23068,23512,23975) order by FBM.ExportOrderID desc";

            var textileResults = _queryService.ExecuteQuery(textile, textileQuery);

            foreach (var reader in textileResults)
            {

                BookingInfo b = new BookingInfo();

                b.YBookingID = reader["YBookingID"] != DBNull.Value ? Convert.ToInt32(reader["YBookingID"]) : 0;
                b.ExportOrderID = reader["ExportOrderID"] != DBNull.Value ? Convert.ToInt32(reader["ExportOrderID"]) : 0;
                b.FabricBookingNo = reader["BookingNo"] != DBNull.Value ? reader["BookingNo"].ToString() : string.Empty;
                b.YarnBookingNo = reader["YBookingNo"] != DBNull.Value ? reader["YBookingNo"].ToString() : string.Empty;
                b.BuyerName = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty;
              
                b.StyleNo = reader["StyleNo"] != DBNull.Value ? reader["StyleNo"].ToString() : string.Empty;

                bookings.Add(b);


            }
            return bookings;

        }

        public List<PurchaseRequisitionMasterDto> GetPR()
        {
            List<PurchaseRequisitionMasterDto> prList = new List<PurchaseRequisitionMasterDto>();

            string textileQuery = @"select pr.PurchaseRequisitionMasterId,pr.PRNo,pr.PRDate,im.ItemName,pr.TotalQuantity from PurchaseRequisitionMasters pr
              inner join ItemMasters im on im.ItemMasterId=pr.ItemYarnId";

            var textileResults = _queryService.ExecuteQuery(scm, textileQuery);

            foreach (var reader in textileResults)
            {
                var pr = new PurchaseRequisitionMasterDto
                {
                    PurchaseRequisitionMasterId = reader["PurchaseRequisitionMasterId"] != DBNull.Value ? Convert.ToInt32(reader["PurchaseRequisitionMasterId"]) : 0,
                    PRNo = reader["PRNo"] != DBNull.Value ? reader["PRNo"].ToString() : string.Empty,
                    PRDate = reader["PRDate"] != DBNull.Value ? Convert.ToDateTime(reader["PRDate"]) : DateTime.MinValue,
                   
                    ItemName = reader["ItemName"] != DBNull.Value ? reader["ItemName"].ToString() : string.Empty,
                    TotalQuantity = reader["TotalQuantity"] != DBNull.Value ? Convert.ToDecimal(reader["TotalQuantity"]) : 0,
                    
                };

                prList.Add(pr);
            }

            return prList;
        }




    }
}
