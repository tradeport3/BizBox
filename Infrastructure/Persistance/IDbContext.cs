﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistance
{
    internal interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
