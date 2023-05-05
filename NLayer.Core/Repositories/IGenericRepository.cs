using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();

        /// <summary>
        /// //IQueryable tipinde döndürürsek sorgularda ToList yapmadan veri tabanına
        /// gitmez, gitmeden önce orderby yapabiliriz. List tipinde döndürürsek hemen
        /// veri tabanına gider orderby yaparsak veri tabanından aldığı verilere
        /// yapar gönderdiği sorguya değil
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        //T entity'ye karşılık gelir, bool dönüş tipine karşılık gelir
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);       
        void RemoveRange(IEnumerable<T> entities);
    }
}
