using Microsoft.EntityFrameworkCore;
using PS213020_Server.DataAccess.Core.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PS213020_Server.DataAccess.Core.Interface.Context
{
    public interface IRubicContext : IDisposable, IAsyncDisposable
    {
        DbSet<UserRto> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancelallationToken = default);
    }
}
