using Microsoft.EntityFrameworkCore;
using SalesWebApp.Data;
using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebAppContext _context;

        public SalesRecordService(SalesWebAppContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Sales select obj;
            if(minDate.HasValue)
            {
                result = result.Where(obj => obj.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(obj => obj.Date <= maxDate.Value);
            }

            return await result.Include(obj => obj.Seller).Include(obj => obj.Seller.Department).OrderByDescending(obj => obj.Date).ToListAsync();
        }
    }
}
