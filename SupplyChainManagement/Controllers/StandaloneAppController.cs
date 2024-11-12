using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.DTO;
using SupplyChainManagement.Models;
using SupplyChainManagement.Service;
using System.Text;
using System.Web;

namespace SupplyChainManagement.Controllers
{
	public class StandaloneAppController : Controller
	{
		//private readonly IConverter _converter;
		public StandaloneAppController()
		{
			//_converter = converter;
		}
		public IActionResult Index(string data)
		{
			string decryptedQueryData;
			if (string.IsNullOrEmpty(data))
			{
				return View("Error", "Invalid Data");
			}
			else
			{
				decryptedQueryData = EncryptDecrypt.Decrypt(data);
			}

			var queryParams = HttpUtility.ParseQueryString(decryptedQueryData);

			var viewModel = new YarnPOMasterDetailViewModel
            {
                PONo = queryParams["PONo"],
				PODate = DateTime.TryParse(queryParams["PODate"], out var poDate) ? poDate : (DateTime?)null,
				SupplierName = queryParams["SupplierName"],
				Charges = decimal.TryParse(queryParams["Charges"], out var charges) ? charges : (decimal?)null,
				CountryOfOrigin = queryParams["CountryOfOrigin"],
				ShippingTolerance = int.TryParse(queryParams["ShippingTolerance"], out var tolerance) ? tolerance : (int?)null,
				PortofLoading = queryParams["PortofLoading"],
				PortofDischarge = queryParams["PortofDischarge"],
				ShipmentMode = queryParams["ShipmentMode"]
			};

            if (queryParams["ItemDetails"] != null)
            {
                string itemDetailsJson = EncryptDecrypt.Decrypt(queryParams["ItemDetails"]);//HttpUtility.UrlDecode(queryParams["ItemDetails"]);
                viewModel.ItemDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<YarnPOChild>>(itemDetailsJson);
            }

            return View(viewModel);

			//var viewModel = new POViewModel
			//{
			//    PONo = HttpContext.Request.Query["PONo"],
			//    PODate = DateTime.TryParse(HttpContext.Request.Query["PODate"], out var poDate) ? poDate : (DateTime?)null,  
			//    SupplierName = HttpContext.Request.Query["SupplierName"],
			//    Charges = decimal.TryParse(HttpContext.Request.Query["Charges"], out var charges) ? charges : (decimal?)null,
			//    CountryOfOrigin = HttpContext.Request.Query["CountryOfOrigin"],
			//    ShippingTolerance = int.TryParse(HttpContext.Request.Query["ShippingTolerance"], out var shippingTolerance) ? shippingTolerance : (int?)null,
			//    PortofLoading = HttpContext.Request.Query["PortofLoading"],
			//    PortofDischarge = HttpContext.Request.Query["PortofDischarge"],
			//    ShipmentMode = HttpContext.Request.Query["ShipmentMode"]
			//};
		}

		public IActionResult DownloadPI(YarnPOMasterDetailViewModel model)
		{
			// Build the HTML string
			var htmlContent = new StringBuilder();
			htmlContent.AppendLine("<html><body>");

			//htmlContent.AppendLine("<div style='display: flex; justify-content: space-between; align-items: center;'>");
			//htmlContent.AppendLine("<div style='text-align: left; font-size: 14px; font-weight: bold;'>");
			//htmlContent.AppendLine("MONTRIMS LTD<br/>MOUCHAK, KALIAKOIR,<br/>GAZIPUR, BANGLADESH");
			//htmlContent.AppendLine("</div>");

			htmlContent.AppendLine("<p style='text-align:left;font-size:24px;color:red;font-weight:bold'>MONTRIMS LTD</p>");

			htmlContent.AppendLine("<p style='text-align:center;font-size:18px;font-weight:bold'>PURCHASE ORDER</p>");

			// Master Details
			htmlContent.AppendLine($@"
            <div style='font-size: small;'>
                <p><strong>PO Number:</strong> {model.PONo}</p>
                <p><strong>PO Date:</strong> {model.PODate:yyyy-MM-dd}</p>
                <p><strong>Supplier Name:</strong> {model.SupplierName}</p>
                <p><strong>Charges:</strong> {model.Charges}</p>
                <p><strong>Port of Loading:</strong> {model.PortofLoading}</p>
                <p><strong>Port of Discharge:</strong> {model.PortofDischarge}</p>
                <p><strong>Shipment Mode:</strong> {model.ShipmentMode}</p>
                <p><strong>Country of Origin:</strong> {model.CountryOfOrigin}</p>
            </div>");

			// Details Table
			htmlContent.AppendLine(@"
            <h6>Details Info</h6>
            <table border='1' cellspacing='0' cellpadding='5' style='width:100%; font-size:small;'>
                <thead>
                    <tr>
                        
                        <th>Item Name</th>
                        <th>Shade</th>
                        <th>Unit</th>
                        <th>PO Qty</th>
                        <th>Rate</th>
                        <th>Value</th>
                        <th>Remarks</th>
                    </tr>
                </thead>
                <tbody>");

			foreach (var detail in model.ItemDetails)
			{
				htmlContent.AppendLine($@"
                <tr>
                    
                    <td>{detail.ItemName}</td>
                    <td>{detail.UnitName}</td>
                    <td>{detail.PoQty}</td>
                    <td>{detail.Rate}</td>
                    <td>{detail.PIValue}</td>
                    <td>{detail.Remarks}</td>
                </tr>");
			}

			htmlContent.AppendLine("</tbody></table>");

			// Terms and Conditions
			htmlContent.AppendLine("<p style='margin-top:20px; font-size:small;'>Terms and Conditions:</p>");
			htmlContent.AppendLine("<ul style='font-size:small;'>");
			htmlContent.AppendLine("<li>All orders are subject to confirmation by the supplier.</li>");
			htmlContent.AppendLine("<li>Goods will be delivered as per the agreed terms and schedule.</li>");
			htmlContent.AppendLine("<li>Any discrepancies must be reported within 7 days of receipt.</li>");
			htmlContent.AppendLine("</ul>");

			htmlContent.AppendLine("</body></html>");

			var Renderer = new IronPdf.HtmlToPdf();
			var PDF = Renderer.RenderHtmlAsPdf(htmlContent.ToString());
			var pdfBytes = PDF.BinaryData;
			return File(pdfBytes, "application/pdf", "PurchaseOrder.pdf");
		
		}

        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile UploadedFile)
        {
            if (UploadedFile != null && UploadedFile.Length > 0)
            {
                string path = @"D:\File";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = Path.Combine(path, UploadedFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await UploadedFile.CopyToAsync(stream);
                }

                return Json(new { success = true, message = "File uploaded successfully!" });
            }
            return Json(new { success = false, message = "No file selected or file is empty." });
        }
		 
    }
}
