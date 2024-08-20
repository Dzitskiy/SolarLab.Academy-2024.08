using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Возвращает все элементы сущности <see cref="TEntity"/>
        /// </summary>
        /// <returns>Все элементы сущности <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAll();

        //TODO
    }
}
