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
        /// <inheritdoc />
        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        //TODO
    }
}
