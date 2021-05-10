//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Identity;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;
//using AWork.Candidate.API.Data;
//using AWork.WebAPI.Core.Identity;

//namespace AWork.Candidate.API.Configurations
//{
//    public static class IdentityConfiguration
//    {
//        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
//        {

//            services.AddDbContext<ApiContext>(options =>
//            {
//                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
//            });

//            services.AddDefaultIdentity<IdentityUser>()
//            .AddRoles<IdentityRole>()
//            .AddEntityFrameworkStores<ApiContext>()
//            .AddDefaultTokenProviders();

//            //JWT - Pegando Config 
//            var appSettingSection = configuration.GetSection("AppSettings");
//            services.Configure<AppSettings>(appSettingSection);

//            //Encode da Chave
//            var appSetting = appSettingSection.Get<AppSettings>();
//            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

//            //Configurando a Autenticação
//            services.AddAuthentication(auth =>
//            {

//                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            })
//            .AddJwtBearer(auth =>
//            {
//                auth.RequireHttpsMetadata = true;
//                auth.SaveToken = true;
//                auth.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidAudience = appSetting.Audience,
//                    ValidIssuer = appSetting.Issuer
//                };
//            });
//            return services;
//        }
//    }
//}
