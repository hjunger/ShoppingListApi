using Domain.Entities;
using System.Collections.Generic;

namespace DAL.DB
{
    public interface IBaseDB<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Find(int id);
        T Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
