using Microsoft.EntityFrameworkCore;

namespace MemeLib.DbContext;

public interface IAppDbContextFactory : IDbContextFactory<AppDbContext>;