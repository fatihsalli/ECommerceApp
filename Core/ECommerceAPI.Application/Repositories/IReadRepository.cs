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
        //EF Core Tracking Performans Optimizasyonu => Read yani sorgulama kısmında sadece data çekileceği için EF Core Tracking sistemini bu fonksiyonlar için devre dışı bırakıyoruz. Bu sayede gereksiz performans kaybının önüne geçiyoruz.
        IQueryable<T> GetAll(bool tracking=true);
        //Lambda Expressions=> where den sonra yazdığımız (x=> x.Id==5) gibi ifadeler için aşağıdaki method yazılır Expression<Func<T,bool>>method(name)
        IQueryable<T> GetWhere(Expression<Func<T,bool>>method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T,bool>>method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
