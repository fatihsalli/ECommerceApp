using ECommerceAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Neden Tracking Parametresi Ekledik
        //Track edilme özelliğini kontrol edebilmek adına parametre olarak ekledik. Gelen data da manipulasyon yani add,update,delete yapmadığımız durumlarda Track edilme özelliğini kapatmak faydalıdır,performansı artırır. 
        #endregion
        //IQueryable => Memory'e çekmez ilgili database'in sorgusuna eklenir.
        IQueryable<T> GetAll(bool tracking = true);

        //Verilen şart ifadesi doğru olan dataların (<T,bool>) çekileceği anlamına gelir. x=> x.Name==name gibi ifadeler özünde Expression olduğu için bu şekilde sorgulama yapabiliyoruz.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
