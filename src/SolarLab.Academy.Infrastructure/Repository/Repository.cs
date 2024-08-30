using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Infrastructure.Repository
{
    /// <inheritdoc />
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity model)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
