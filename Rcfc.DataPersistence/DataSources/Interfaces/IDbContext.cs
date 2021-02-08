using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Rcfc.DataPersistence.DataSources
{
    // TODO: Add more essential methods
    public interface IDbContext<TContext, TEntityEntry>
        where TContext : class, IDisposable
        where TEntityEntry : class
    {
        public TContext GetContext();

        public TEntityEntry Add([NotNull] object entity);

        // This should be possible, but it isn't:
        //
        //public TEntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity)
        //    where TEntity : class;

        // So, resorting to a workaround (requires a proxy method to the EF Core's DbContext method)
        // See: <https://software.codidact.com/posts/280670#answer-280670>
        // 
        public TEntityEntry_TEntity Add<TEntity, TEntityEntry_TEntity>([NotNull] TEntity entity,
            [NotNull] Func<TEntity, TEntityEntry_TEntity> baseGenericMethodWrapper)
            where TEntity : class
            where TEntityEntry_TEntity : TEntityEntry;
        // /workaround

        // Same as above
        public TEntityEntry_TEntity Remove<TEntity, TEntityEntry_TEntity>([NotNull] TEntity entity,
            [NotNull] Func<TEntity, TEntityEntry_TEntity> baseGenericMethodWrapper)
            where TEntity : class
            where TEntityEntry_TEntity : TEntityEntry;
        // /workaround

        public int SaveChanges();
    }
}
