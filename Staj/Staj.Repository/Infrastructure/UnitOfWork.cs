using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Staj.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CBKFTEntities _dbContext;

        public UnitOfWork()
        {
            if(_dbContext == null)
            {
                _dbContext = new CBKFTEntities();
            }
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }

}