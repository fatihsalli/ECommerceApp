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
        public IQueryable<T> GetAll()
            => Table;

        //public IQueryable<T> GetAll()
        //{
        //    return Table;
        //}

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(p=> p.Id==Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }
    }
}
