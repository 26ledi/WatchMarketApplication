using Microsoft.EntityFrameworkCore;
using WatchMarket.BusinessLogic.Interfaces;
using WatchMarket.BusinessLogic.Services;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.BusinessLogic.Services;
using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Repositories.Implementations;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.Extensions
{
    public static class ApplicationDependanciesConfiguration
    {
        public static IServiceCollection ConfigureService(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<WatchMarketContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWatchService, WatchService>();
            builder.Services.AddScoped<IPriceService, PriceService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return builder.Services;
        }
    }
}
