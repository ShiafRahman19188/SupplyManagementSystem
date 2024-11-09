using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.Models;
using SupplyChainManagement.Service;
using System.Web;

namespace SupplyChainManagement.Controllers
{
	public class StandaloneAppController : Controller
	{
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

			var viewModel = new POViewModel
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
	}
}
