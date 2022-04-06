using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebApp.Data;
using SalesWebApp.Models;
using SalesWebApp.Services.Exceptions;

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

        public void Insert(Seller obj)
        {            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);

        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if(!_context.Seller.Any(obj => obj.Id == seller.Id))
            {
                throw new NotFoundException("ID not found");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }

            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}
