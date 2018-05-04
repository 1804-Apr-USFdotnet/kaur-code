using System;
using System.Collections.Generic;
using System.Linq;
using Tapas.DataLayer.Models;

namespace Tapas.DAL.Repositories
{
   public interface ICrud<T>where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }       
    }
}
