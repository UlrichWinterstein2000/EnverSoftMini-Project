using EnverSoftMini.Core.Entities;
using EnverSoftMini.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnverSoftMini.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<Supplier?> GetByCompanyNameAsync(string companyName)
        {
            var supplier = await _context.Suppliers.Where(x => !x.IsDeleted)
                                            .FirstOrDefaultAsync(s => s.CompanyName == companyName);
            return supplier;
        }

        public async Task<Supplier?> GetByCompanyIdAsync(long supplierId)
        {
            var supplier = await _context.Suppliers
                                            .FirstOrDefaultAsync(s => s.Id == supplierId);
            return supplier;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task DeleteAsync(long supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if (supplier != null)
            {
                supplier.IsDeleted = true;
                _context.Suppliers.Update(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
