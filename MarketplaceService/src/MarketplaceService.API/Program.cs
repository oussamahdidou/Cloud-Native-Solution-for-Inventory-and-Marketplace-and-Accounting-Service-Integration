
using MarketplaceService.Domain.Repositories;
using MarketplaceService.Infrastructure.Consumers;
using MarketplaceService.Infrastructure.Data;
using MarketplaceService.Infrastructure.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

    }
);
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<apiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("MarketplaceService.API"));
  
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, //issuer url same as jwt token creation url
        ValidIssuer = builder.Configuration["JWT:Issuer"], //audience
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],//issuer url same as jwt token creation url
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigninKey"] ?? ""))

    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
   
});
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<RegistredUserConsumer>();
    x.AddConsumer<ProductAddedConsumer>();
    x.AddConsumer<CategoryAddedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {

        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.UseNewtonsoftRawJsonSerializer();
        cfg.UseNewtonsoftRawJsonDeserializer();

        cfg.ConfigureEndpoints(context);
       
        cfg.ReceiveEndpoint("marketplace_user_registration_queue", e =>
        {
            e.Bind("user_registration_exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout; // Use direct, topic, or fanout as appropriate
            });
            e.ConfigureConsumer<RegistredUserConsumer>(context);
        });
        // product 
        cfg.ReceiveEndpoint("product-added", e =>
        {
            e.Durable = true;
            e.Bind("product-exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout;
            });
            e.ConfigureConsumer<ProductAddedConsumer>(context);
        });
        // for update Product 
        cfg.ReceiveEndpoint("product-Update-Queue", e =>
        {
            e.Durable = true;
            e.Bind("product-Update-exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout;
            });
            e.ConfigureConsumer<ProductAddedConsumer>(context);
        });
        // category 
        cfg.ReceiveEndpoint("Category-added-queue", e =>
        {
            e.Durable = true;
            e.Bind("Category-added-Exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout;
            });
            e.ConfigureConsumer<CategoryAddedConsumer>(context);
        });

    });
});

builder.Services.AddMassTransitHostedService();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();