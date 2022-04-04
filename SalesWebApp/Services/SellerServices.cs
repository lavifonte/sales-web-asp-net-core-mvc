using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApp.Data;
using SalesWebApp.Models;

namespace SalesWebApp.Services
{
    // quem implementa as regras de negócio e acessa os dados deve ser a camada services
    public class SellerServices
    {
        private readonly SalesWebAppContext  _context; // declaração de dependência à database

        public SellerServices(SalesWebAppContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
            // retorna uma lista com todos os vendedores armazenados no banco de dados
        }

        public void Inser(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
