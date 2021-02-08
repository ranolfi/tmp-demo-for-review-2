using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace Rcfc.DataPersistence.DataSources.Postgres_Rcfc
{
    public partial class EntityFrameworkContext : DbContext, IDbContext<EntityFrameworkContext, EntityEntry>
    {
        public EntityFrameworkContext GetContext()
        {
            return this;
        }

        // Workaround; from <https://software.codidact.com/posts/280670#answer-280670>
        //
        // Factory method:
        public override EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity)
            where TEntity : class
            => Add(entity, base.Add);

        // Interface implementation:
        public TEntityEntry_TEntity Add<TEntity, TEntityEntry_TEntity>([NotNull] TEntity entity,
            [NotNull] Func<TEntity, TEntityEntry_TEntity> baseGenericMethodWrapper)
            where TEntity : class
            where TEntityEntry_TEntity : EntityEntry
            => baseGenericMethodWrapper(entity);
        // /workaround

        // Same as above
        //
        // Factory method:
        public override EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity)
            where TEntity : class
            => Remove(entity, base.Remove);

        // Interface implementation:
        public TEntityEntry_TEntity Remove<TEntity, TEntityEntry_TEntity>([NotNull] TEntity entity,
            [NotNull] Func<TEntity, TEntityEntry_TEntity> baseGenericMethodWrapper)
            where TEntity : class
            where TEntityEntry_TEntity : EntityEntry
            => baseGenericMethodWrapper(entity);
        // /workaround
    }
}
