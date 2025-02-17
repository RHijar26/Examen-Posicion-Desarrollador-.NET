using ExamenDesarrollador.Data;
using ExamenDesarrollador.Data.Context;
using ExamenDesarrollador.Data.Processing;
using ExamenDesarrollador.Data.Repositorios;
using ExamenDesarrollador.Entitys.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ExamenDesarrollador.Server
{
    public class Services
    {
        public static void LoadServices(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddProblemDetails();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            #region Swagger

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Define the BearerAuth scheme that's in use
                c.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT"
                });

                // Make sure swagger UI requires a Bearer token specified
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "BearerAuth" }
                        },
                        new string[] {}
                    }
                });
            });




            #endregion

   

            #region Authentication & Authorization

            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = builder.Configuration["JwtToken:Issuer"],
            //        ValidAudience = builder.Configuration["JwtToken:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:Key"]))
            //    };
            //});

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .WithExposedHeaders("Content-Disposition")); ;
            //});

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()                           
                           .AllowAnyHeader();
                });
            });


            #endregion





            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();

            builder.Services.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.PropertyNamingPolicy = null;
               }); 


            builder.Services.AddDbContext<ContextDBO>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("BD"), sqlOptions =>
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    )
            ));



            DependecyInjection.AddServices(builder.Services);

        }
    }
}
