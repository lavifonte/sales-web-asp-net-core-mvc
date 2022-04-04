using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApp.Services;
using SalesWebApp.Models;

namespace SalesWebApp.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerServices;

        public SellersController(SellerServices sellerServices)
        {
            _sellerServices = sellerServices;
        }

        public IActionResult Index()
        {
            var list = _sellerServices.FindAll();  // o método criado no sellerservices

            return View(list);
            // chama a ação para retornar a lista de sellers, encaminhando os dados para a view
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            //ação de post para inserir novo vendedor à lista seller
            _sellerServices.Inser(seller);
            return RedirectToAction(nameof(Index));
        }
        


    }
}
