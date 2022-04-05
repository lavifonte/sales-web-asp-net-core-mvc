using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApp.Services;
using SalesWebApp.Models;
using SalesWebApp.Models.ViewModels;

namespace SalesWebApp.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerServices;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerServices sellerServices, DepartmentService departmentServices)
        {
            _sellerServices = sellerServices;
            _departmentService = departmentServices;
            
        }

        public IActionResult Index()
        {
            var list = _sellerServices.FindAll();  // o método criado no sellerservices

            return View(list);
            // chama a ação para retornar a lista de sellers, encaminhando os dados para a view
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel{ Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            //ação de post para inserir novo vendedor à lista seller
            _sellerServices.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerServices.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


    }
}
