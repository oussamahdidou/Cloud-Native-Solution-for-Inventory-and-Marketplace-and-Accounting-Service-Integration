
using EventsContracts.EventsContracts;
using MarketplaceService.Application.Interfaces;
using MarketplaceService.Application.Services;
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
builder.Services.AddDbContext<ApiDbContext>(options =>
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
    x.AddConsumer<ProductUpdateConsumer>();
    x.AddConsumer<ProductDeleteConsumer>();
    x.AddConsumer<DeleteCategoryConsumer>();
    x.AddConsumer<UpdateCategoryConsumer>();
    x.AddConsumer<SortieRecordConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {

        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.Message<ICommandeConfirmedEvent>(m =>
        {
            m.SetEntityName("commande_confirmed_exchange"); // specify the exchange name explicitly
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
            e.ConfigureConsumer<ProductUpdateConsumer>(context);
        });
        // Delete Product 
        cfg.ReceiveEndpoint("product-Delete-Queue", e =>
        {
            e.Durable = true;
            e.Bind("product-Delete-exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout;
            });
            e.ConfigureConsumer<ProductDeleteConsumer>(context);
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
        // Delete category 
        cfg.ReceiveEndpoint("Category-Delete-queue", e =>
        {
            e.Durable = true;
            e.Bind("Category-Delete-Exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout;
            });
            e.ConfigureConsumer<DeleteCategoryConsumer>(context);
        });
        // Update category 
        cfg.ReceiveEndpoint("Category-Update-queue", e =>
        {
            e.Durable = true;
            e.Bind("Category-Update-Exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout;
            });
            e.ConfigureConsumer<UpdateCategoryConsumer>(context);
        });
        cfg.ReceiveEndpoint("Sortie-Record-queue", e =>
        {
            e.Durable = true;
            e.Bind("Sortie-Record-Exchange", exchange =>
            {
                exchange.ExchangeType = ExchangeType.Fanout;
            });
            e.ConfigureConsumer<SortieRecordConsumer>(context);
        });
    });
});

builder.Services.AddMassTransitHostedService();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
builder.Services.AddScoped<ICommandeProductRepository, CommandeProductRepository>();
builder.Services.AddScoped<ICartService,CartService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPaypalService, PaypalService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICommandeService, CommandeService>();

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