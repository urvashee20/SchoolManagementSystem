using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Students> Students { get; }
        public IRepository<Teacher> Teacher { get; }
        public IRepository<Classes> Classes { get; }
        public IRepository<City> Citys { get; }
        public IRepository<Country> Countrys { get; }
        public IRepository<State> States { get; }

        public IStudentRepository Student { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new Repository<Students>(context);
            Teacher = new Repository<Teacher>(context);
            Classes = new Repository<Classes>(context);
            Citys = new Repository<City>(context);
            Countrys = new Repository<Country>(context);
            States = new Repository<State>(context);
            Student = new StudentRepository(context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        { 
            _context.Dispose();
        }






    }
}
