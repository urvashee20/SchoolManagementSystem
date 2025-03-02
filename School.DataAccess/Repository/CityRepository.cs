using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.cities.ToListAsync();
        }

        public async Task<IEnumerable<City>> GetByCondition(Expression<Func<City, bool>> predicate)
        {
            return await _context.cities.Where(predicate).ToListAsync();
        }
    }
}
