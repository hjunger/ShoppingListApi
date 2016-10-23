using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class ProductDB : IBaseDB<Product>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Find(int id)
        {
            using(var context = new ShoppingListContext())
            {
                return context.Products.Find(id);
            }
        }

        public List<Product> GetAll()
        {
            using (var context = new ShoppingListContext())
            {
                return context.Products.ToList();
            }
        }

        public Product Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
