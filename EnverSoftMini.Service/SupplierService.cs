using EnverSoftMini.Core.Entities;
using EnverSoftMini.Core.Interfaces;
using EnverSoftMini.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnverSoftMini.Service
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.AddAsync(supplier);
        }

        public async Task<Supplier?> GetSupplierByCompanyNameAsync(string companyName)
        {
            return await _supplierRepository.GetByCompanyNameAsync(companyName);
        }

        public async Task<Supplier?> GetSupplierByCompanyIdAsync(long supplierId)
        {
            return await _supplierRepository.GetByCompanyIdAsync(supplierId);
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task DeleteSupplierAsync(long supplierId)
        {
            await _supplierRepository.DeleteAsync(supplierId);
        }
    }
}
