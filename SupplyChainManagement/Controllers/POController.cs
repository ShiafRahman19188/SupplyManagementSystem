using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.Db;
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
            return View();
        }

        public IActionResult Add() 
        {
            YarnPOMaster model= new YarnPOMaster();
            return View(model);
        }

        [HttpPost]
        public IActionResult SendPoEmail(int poId, string PONo, string supplierName,YarnPOMaster model)
        {
            string linkURL = "http://localhost:5144/";
            var queryParameters = $"?PONo={model.PONo}&PODate={model.PODate:yyyy-MM-dd}&SupplierName={model.SupplierName}&Charges={model.Charges}&CountryOfOrigin={model.CountryOfOrigin}&ShippingTolerance={model.ShippingTolerance}&PortofLoading={model.PortofLoading}&PortofDischarge={model.PortofDischarge}&ShipmentMode={model.ShipmentMode}";
            string encryptedQueryData = EncryptDecrypt.Encrypt(queryParameters);
            string link = $"{linkURL}?data={Uri.EscapeDataString(encryptedQueryData)}";
           // string link = $"{linkURL}{queryParameters}";
            string emailBody = $"<p>Hello,</p><p>Please review the Purchase Order.</p><p><a href='{link}'>Click here to view PO {PONo}</a></p>";

            _emailService.SendEmail("noor.alam@epylliongroup.com", $"PO Notification for {supplierName}", emailBody);

            return RedirectToAction("Index");
        }

    }
}
