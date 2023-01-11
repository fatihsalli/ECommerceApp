using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        //IQueryable => Memory'e çekmez ilgili database'in sorgusuna eklenir.
        IQueryable<T> GetAll();

        //Verilen şart ifadesi doğru olan dataların (<T,bool>) çekileceği anlamına gelir. x=> x.Name==name gibi ifadeler özünde Expression olduğu için bu şekilde sorgulama yapabiliyoruz.
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(string id);
    }
}
