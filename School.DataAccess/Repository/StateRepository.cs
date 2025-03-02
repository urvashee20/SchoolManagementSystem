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
    public class StateRepository : Repository<State>, IStateRepository
    {
        private readonly ApplicationDbContext _context;

        public StateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetAll()
        {
            return await _context.states.ToListAsync();
        }

        public async Task<IEnumerable<State>> GetByCondition(Expression<Func<State, bool>> predicate)
        {
            return await _context.states.Where(predicate).ToListAsync();
        }
    }
}
