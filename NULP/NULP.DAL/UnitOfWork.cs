using System;
using NULP.DAL.Repository;
using NULP.Model;
using NULP.Model.Models;

namespace NULP.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _context = new DataContext();
        private bool _disposed;

        private GenericRepository<Hospital> _hospitalRepository;
        private GenericRepository<Department> _departmentRepository;
        private GenericRepository<Person> _personRepository;

        public GenericRepository<Hospital> HospitalRepository
            => _hospitalRepository ?? (_hospitalRepository = new GenericRepository<Hospital>(_context));

        public GenericRepository<Department> DepartmentRepository
            => _departmentRepository ?? (_departmentRepository = new GenericRepository<Department>(_context));

        public GenericRepository<Person> PersonRepository
            => _personRepository ?? (_personRepository = new GenericRepository<Person>(_context));

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}