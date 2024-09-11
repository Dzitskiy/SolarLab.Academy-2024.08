using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Infrastructure.Repository
{
    public interface IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        /// <summary>
        /// Возвращает все элементы сущности <see cref="TEntity"/>
        /// </summary>
        /// <returns>Все элементы сущности <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Получение сущности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление.
        /// </summary>
        /// <param name="model">Сущность.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task AddAsync(TEntity model, CancellationToken cancellationToken);

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="model">Сущность.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity model, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
