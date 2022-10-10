using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPIDbContext _context;
        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        //Bütün fonskyionlarda yazmamak için aşağıdaki gibi bir generic DbSet oluşturuyoruz.
        public DbSet<T> Table => _context.Set<T>();

        //Alternatif yazma şekli => return anlamına gelir aşağıdakiyle aynı mantıktır.
        //public IQueryable<T> GetAll()
        //    => Table;

        //Ef Core Tracking yani dataların takip edilmesini sorgu-read methotları için kapatabilmek adına ayar yapıyoruz. Böylece performansı artırabiliriz.
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query= query.AsNoTracking();
            }
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            //IQueryable da çalışırken FinsAsync hata verecek bu sebeple Marker pattern yöntemi ile göstereceğiz.
            //return await query.FindAsync(Guid.Parse(id));
            //Marker pattern yöntemi
            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }

    }
}
