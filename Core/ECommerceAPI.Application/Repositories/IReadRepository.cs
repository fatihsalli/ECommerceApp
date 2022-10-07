using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
    {
        //Veri tabanında sorgu üzerinde çalışmak için "IQueryable" In memoryde çalışmak için "IEnumerable". IQueryable sorgularında yazılan şartlar where vs. ya da select sorguları ilgili veritabanı sorgusuna eklenecektir. Bu sebeple IQueryable kullanmak daha doğrudur. List--> IEnumerable.
        IQueryable<T> GetAll();
        //where den sonra yazdığımız (x=> x.Id==5) gibi ifadeler için aşağıdaki method yazılır Expression<Func<T,bool>>method(name)
        IQueryable<T> GetWhere(Expression<Func<T,bool>>method);
        Task<T> GetSingleAsync(Expression<Func<T,bool>>method);
        Task<T> GetByIdAsync(string id);
    }
}
