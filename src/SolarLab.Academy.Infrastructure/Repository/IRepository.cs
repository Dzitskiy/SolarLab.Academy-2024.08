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
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TEntity Add(TEntity model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TEntity Update(TEntity model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);
    }
}
