using DAL.DB;
using Domain.Entities;
using ShoppingListApi.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShoppingListApi.Controllers
{
    [ShoppingListAuthorize]
    public class ShoppingListController : BaseController<Item>
    {
        public ShoppingListController()
        {
            DataBase = new ItemDB();
        }
        
        [HttpGet]
        public List<Item> GetByCustomer(string customerId, int skip = 0, int take = 10)
        {
            return GetPagination(skip, take, ((ItemDB)DataBase).GetItemsFromCustomer(customerId)).ToList();
        }

        [HttpGet]
        public List<Item> GetByProduct(int productId, int skip = 0, int take = 10)
        {
            var ret = GetPagination(skip, take, ((ItemDB)DataBase).GetItemsByProduct(productId)).ToList();
            return ret;
        }
    }
}
