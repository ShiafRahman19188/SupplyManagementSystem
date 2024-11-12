using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;
using SupplyChainManagement.DTO;
using SupplyChainManagement.Models;
using SupplyChainManagement.Service;

namespace SupplyChainManagement.Controllers
{
    public class POController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly string textile;
        private readonly string scm;
        private readonly DBService _queryService;
        private readonly SCMDbContext _context;
        private readonly MailServices _emailService;
 
        public POController(IConfiguration configuration, DBService DBService, SCMDbContext context ,MailServices mailServices)
        {
            _configuration = configuration;
            textile = _configuration.GetConnectionString("TextileConnection");
            scm = _configuration.GetConnectionString("DefaultConnection");
            _queryService = DBService;
            _context = context;
            _emailService = mailServices;
        }
        public IActionResult Index()
        {
            var result = (from po in _context.ItemPOMaster
                          join im in _context.ItemMasters on po.YPOMasterID equals im.ItemMasterId
                          select new ItemMasterPODto
                          {
                              YPOMasterID = po.YPOMasterID,
                              PONo = po.PONo,
                              PODate = (DateTime)po.PODate,
                              //ItemYarnId = pr.ItemYarnId,
                              ItemName = im.ItemName
                              
                          }).ToList();


            return View(result);
        }

        public IActionResult Add(int id) 
        {
            var masterData = _context.ItemPOMaster
                             .FirstOrDefault(m => m.YPOMasterID == id);

            //var masterData = _context.ItemPOMaster.FirstOrDefault(m => m.YPOMasterID == id);
            var detailData = _context.ItemPODetail
                             .Where(d => d.YPOMasterID == id) 
                             .ToList();
            
            var model = new YarnPOMasterDetailViewModel
            {
                YarnPOMaster = masterData,
                ItemDetails = detailData
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SendPoEmail(int poId, string PONo, string supplierName, YarnPOMasterDetailViewModel model)
        {
			string linkURL = "http://localhost:5023/StandaloneApp/Index";
            var itemDetailsJson = Newtonsoft.Json.JsonConvert.SerializeObject(model.ItemDetails);
            string encryptedItemDetails = EncryptDecrypt.Encrypt(itemDetailsJson);
            var queryParameters = $"?PONo={model.YarnPOMaster.PONo}&PODate={model.YarnPOMaster.PODate:yyyy-MM-dd}&SupplierName={model.YarnPOMaster.SupplierName}&Charges={model.YarnPOMaster.Charges}&CountryOfOrigin={model.YarnPOMaster.CountryOfOrigin}&ShippingTolerance={model.YarnPOMaster.ShippingTolerance}&PortofLoading={model.YarnPOMaster.PortofLoading}&PortofDischarge={model.YarnPOMaster.PortofDischarge}&ShipmentMode={model.YarnPOMaster.ShipmentMode}&ItemDetails={Uri.EscapeDataString(encryptedItemDetails)}";
           // var queryParameters = $"?PONo={model.PONo}&PODate={model.PODate:yyyy-MM-dd}&SupplierName={model.SupplierName}&Charges={model.Charges}&CountryOfOrigin={model.CountryOfOrigin}&ShippingTolerance={model.ShippingTolerance}&PortofLoading={model.PortofLoading}&PortofDischarge={model.PortofDischarge}&ShipmentMode={model.ShipmentMode}&ItemDetails={model.ItemDetails}";
            string encryptedQueryData = EncryptDecrypt.Encrypt(queryParameters);
            string link = $"{linkURL}?data={Uri.EscapeDataString(encryptedQueryData)}";
           
            string emailBody = $"<p>Hello,</p><p>Please review the Purchase Order.</p><p><a href='{link}'>Click here to view PO {PONo}</a></p>";

            _emailService.SendEmail("noor.alam@epylliongroup.com", $"PO Notification for {supplierName}", emailBody);

            return RedirectToAction("Index");
        }

    }
}
