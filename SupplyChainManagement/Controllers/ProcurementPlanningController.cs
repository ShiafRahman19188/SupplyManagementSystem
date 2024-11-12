using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Db;
using SupplyChainManagement.DTO;
using SupplyChainManagement.Models;

namespace SupplyChainManagement.Controllers
{
    public class ProcurementPlanningController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SCMDbContext _context;
        private readonly string scm;
        private readonly DBService _queryService;

        public ProcurementPlanningController(IConfiguration configuration, DBService DBService, SCMDbContext context)
        {
            _configuration = configuration;
            scm = _configuration.GetConnectionString("DefaultConnection");
            _queryService = DBService;
            _context = context;

        }
        public IActionResult Index()
        {
            return View(GetPPData());
        }

        private List<ProcurementLandingDto> GetPPData()
        {

            List<ProcurementLandingDto> items = new List<ProcurementLandingDto>();
            string Query = $"select im.ItemName,pr.ItemYarnId,sum(TotalQuantity)TotalQuantity  from PurchaseRequisitionMasters pr inner join ItemMasters im on im.ItemMasterId=pr.ItemYarnId group by ItemYarnId,im.ItemName\r\n";

            var Results = _queryService.ExecuteQuery(scm, Query);

            foreach (var reader in Results)
            {

                ProcurementLandingDto b = new ProcurementLandingDto();

                b.YarnId = reader["ItemYarnId"] != DBNull.Value ? Convert.ToInt32(reader["ItemYarnId"]) : 0;
                b.YarnName = reader["ItemName"] != DBNull.Value ? reader["ItemName"].ToString() : string.Empty;
                b.TotalQuantity = reader["TotalQuantity"] != DBNull.Value ? Convert.ToDecimal(reader["TotalQuantity"]) : 0;
                b.ProcurementChildren = GetitemWiseData(b.YarnId);
                items.Add(b);


            }

            return items;
        }

        private List<ProcurementChildDto> GetitemWiseData(int ItemMasterId)
        {
            Random random = new Random();
         
            List<ProcurementChildDto> items = new List<ProcurementChildDto>();
            string Query = $"Select PurchaseRequisitionMasterId,PRNo,TotalQuantity as EwoQuantity from PurchaseRequisitionMasters where ItemYarnId="+ ItemMasterId;

            var Results = _queryService.ExecuteQuery(scm, Query);

            foreach (var reader in Results)
            {

                ProcurementChildDto b = new ProcurementChildDto();

                b.TNASlab ="Nov-Dec";
                b.PRNo = reader["PRNo"] != DBNull.Value ? reader["PRNo"].ToString() : string.Empty;
                b.EwoQuantity = reader["EwoQuantity"] != DBNull.Value ? Convert.ToDecimal(reader["EwoQuantity"]) : 0;
                b.ProjectionQuantity = Math.Round((decimal)(random.NextDouble() * (400 - 100) + 100), 2); 
                b.ROLQuantity = Math.Round((decimal)(random.NextDouble() * (50 - 20) + 20), 2);
                b.TotalQuantity = b.EwoQuantity + b.ProjectionQuantity + b.ROLQuantity;
                b.FreeStock = Math.Round((decimal)(random.NextDouble() * 100), 2); 
                b.FreePipeLineStock = Math.Round((decimal)(random.NextDouble() * 50), 2); 
                b.FreeTransitStock = Math.Round((decimal)(random.NextDouble() * 50), 2);
                b.FreePhysicalStock = Math.Round((decimal)(random.NextDouble() * 100), 2); 
                b.SuggestedStoreRequisition = Math.Round((decimal)(random.NextDouble() * (50 - 20) + 20), 2); //  20 and 50
                b.SuggestedPurchaseQuantity = b.TotalQuantity - b.FreeStock - b.FreePipeLineStock - b.FreePhysicalStock - b.FreeTransitStock;
                b.PurchaseOrderQuantity = b.SuggestedPurchaseQuantity;
                b.PurchaseRequisitionMasterId = reader["PurchaseRequisitionMasterId"] != DBNull.Value ? Convert.ToInt32(reader["PurchaseRequisitionMasterId"]) : 0;
                items.Add(b);


            }

            return items;
        }
    }
}
