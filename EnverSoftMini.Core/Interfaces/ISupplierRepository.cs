using EnverSoftMini.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnverSoftMini.Core.Interfaces
{
    public interface ISupplierRepository
    {
        Task AddAsync(Supplier supplier);
        Task<Supplier?> GetByCompanyNameAsync(string companyName);
        Task<Supplier?> GetByCompanyIdAsync(long supplierId);
        Task<List<Supplier>> GetAllAsync();
        Task DeleteAsync(long supplierId);
    }
}
