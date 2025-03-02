using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Students> Students { get; }
        IRepository<Teacher> Teacher { get; }
        IRepository<Classes> Classes { get; }
        IRepository<City> Citys { get; }
        IRepository<Country> Countrys { get; }
        IRepository<State> States { get; }
        Task Save();

        IStudentRepository Student {  get; }
    }
}
