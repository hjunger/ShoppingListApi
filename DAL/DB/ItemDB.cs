using Domain.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class ItemDB : IBaseDB<Item>
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Item> GetItemsFromCustomer(string customerId)
        {
            using (var context = new ShoppingListContext())
            {
                return context.Items
                    .Include("Product")
                    .Where(item => item.CustomerID == customerId).ToList();
            }
        }
        
        public List<Item> GetItemsByProduct(int productId)
        {
            using (var context = new ShoppingListContext())
            {
                return context.Items
                    .Where(item => item.ProductID == productId).ToList();
            }
        }

        public bool Update(Item entity)
        {
            using (var context = new ShoppingListContext())
            {
                try
                {
                    if (entity.ProductID > 0)
                    {
                        entity.Product = null;
                        var oldItem = context.Items.Find(entity.ItemID);
                        if (entity.Quantity > 0)
                            oldItem.Quantity = entity.Quantity;
                        else
                        {
                            return Delete(entity.Id);
                        }

                        oldItem.Name = entity.Name;
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("ProductID cannot be 0.");
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return false;
                }
            }
        }

        public Item Find(int id)
        {
            using (var context = new ShoppingListContext())
            {
                return context.Items
                    .Include("Product")
                    .SingleOrDefault(i => i.ItemID == id);
            }
        }

        public bool Delete(int id)
        {
            using (var context = new ShoppingListContext())
            {
                try
                {
                    var itemToRemove = context.Items.Find(id);
                    if (itemToRemove != null)
                        context.Items.Remove(itemToRemove);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return false;
                }
            }
        }

        public List<Item> GetAll()
        {
            using(var context = new ShoppingListContext())
            {
                return context.Items
                    .Include("Product").ToList();
            }
        }

        Item IBaseDB<Item>.Insert(Item entity)
        {
            using (var context = new ShoppingListContext())
            {
                try
                {
                    if (entity.ProductID > 0)
                    {
                        entity.Product = null;
                        var checkCustomer = context.Items
                            .SingleOrDefault(item => item.CustomerID == entity.CustomerID && item.ProductID == entity.ProductID);

                        if (checkCustomer == null)
                            context.Items.Add(entity);
                        else
                        {
                            checkCustomer.Quantity += entity.Quantity;
                            entity.Quantity = checkCustomer.Quantity;
                        }

                        context.SaveChanges();
                        entity.Product = context.Products.Find(entity.ProductID);
                        return entity;
                    }
                    else
                        throw new Exception("ProductID cannot be 0.");
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }
    }
}
