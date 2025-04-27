using EnverSoftMini.Core.Entities;
using EnverSoftMini.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnverSoftMini.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(Supplier supplier)
        {
            await _supplierService.AddSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetSupplier), new { companyName = supplier.CompanyName }, supplier);
        }

        [HttpGet("{companyName}")]
        public async Task<IActionResult> GetSupplier(string companyName)
        {
            var supplier = await _supplierService.GetSupplierByCompanyNameAsync(companyName);
            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            if (suppliers == null || suppliers.Count == 0)
                return NotFound();

            return Ok(suppliers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(long id)
        {
            var supplier = await _supplierService.GetSupplierByCompanyIdAsync(id);
            if (supplier == null)
                return NotFound();

            await _supplierService.DeleteSupplierAsync(id);  
            return NoContent(); 
        }

    }
}
