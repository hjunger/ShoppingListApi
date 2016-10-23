using DAL.DB;
using Domain.Entities;
using ShoppingListApi.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingListApi.Controllers
{
    [ShoppingListAuthorize]
    public class ProductController : BaseController<Product>
    {
        public ProductController()
        {
            DataBase = new ProductDB();
        }
    }
}
