using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        // GET: Product
        public ProductController( IProductRepository repositoryProcut)
        {
            this.repository = repositoryProcut;
        }

        public ViewResult List(int page=1)
        {
            return View(repository.Products.OrderBy(p=>p.ProductId).Skip((page-1)*PageSize).Take(PageSize));
        }

    }
}