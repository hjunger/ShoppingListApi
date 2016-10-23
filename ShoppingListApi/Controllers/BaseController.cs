using DAL.DB;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ShoppingListApi.Controllers
{
    public abstract class BaseController<T> : ApiController where T : BaseEntity
    {
        protected IBaseDB<T> DataBase { get; set; }

        [HttpGet]
        public List<T> Get(int skip = 0, int take = 10)
        {
            return GetPagination(skip, take, DataBase.GetAll().ToList());
        }

        [HttpGet]
        public T GetById(int id)
        {
            return DataBase.Find(id);
        }

        [HttpPost]
        public T Insert(T entity)
        {
            return DataBase.Insert(entity);
        }

        [HttpPut]
        public bool Update(T entity)
        {

            return DataBase.Update(entity);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return DataBase.Delete(id);
        }

        protected List<T> GetPagination(int skip, int take, List<T> total)
        {
            if (skip == 0)
                return total;
            else
            {
                var paginationHeader = new
                {
                    TotalCount = total.Count,
                    TotalPages = (int)Math.Ceiling((double)total.Count / take)
                };

                System.Web.HttpContext.Current.Response.Headers.Add("Pagination",
                    JsonConvert.SerializeObject(paginationHeader));

                return total.Skip(skip * take).Take(take).ToList();
            }
        }
    }
}
