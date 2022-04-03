using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApp.Models;

namespace SalesWebApp.Data
{
    public class SeedingService
    {
        private SalesWebAppContext _context;

        public SeedingService(SalesWebAppContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // testando para ver se já existe algum dado no banco de dados (usando o nome das tabelas do banco de dados)
            if(_context.Department.Any() || _context.Seller.Any() || _context.Sales.Any())
            {
                return;
            }

            Department d1 = new Department(5, "computer");
            Department d2 = new Department(6, "electronics");
            Department d3 = new Department(7, "books");
            Department d4 = new Department(8, "fashion");

            Seller s1 = new Seller(9, "Bob Brown", "bobbrown@hotmail.com", new DateTime(1970, 4, 10), 2500.00, d1);
            Seller s2 = new Seller(10, "Maria Green", "mariagreen@hotmail.com", new DateTime(1960, 5, 20), 3000.00, d2);
            Seller s3 = new Seller(11, "Alex Blue", "alexblue@hotmail.com", new DateTime(1980, 6, 30), 3500.00, d3);
            Seller s4 = new Seller(13, "Anna Red", "annared@hotmail.com", new DateTime(1990, 07, 5), 4000.00, d4);

            SalesRecord sales1 = new SalesRecord(14, new DateTime(2018, 9, 25), 10000.0, Models.Enums.SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.Sales.AddRange(sales1);

            _context.SaveChanges();

        }

    }
}
