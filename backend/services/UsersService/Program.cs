using EventsContracts.EventsContracts;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using UsersService.Consumers;
using UsersService.Data;
using UsersService.Interfaces;
using UsersService.Model;
using UsersService.Producers;
using UsersService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenTelemetry();

builder.AddServiceDefaults();
builder.Configuration.AddEnvironmentVariables();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<apiDbContext>();
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
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigninKey"]))

    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
});
builder.Services.AddMassTransit(x =>
{

    x.AddConsumer<FirstEventConsumer>();

    x.AddConsumer<SecondEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {

        cfg.Host("127.0.0.1", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.Message<INewUserRegistredEvent>(m =>
        {
            m.SetEntityName("user_registration_exchange"); // specify the exchange name explicitly
        });
        cfg.UseNewtonsoftRawJsonSerializer();
        cfg.UseNewtonsoftRawJsonDeserializer();

        cfg.ConfigureEndpoints(context);

        cfg.ReceiveEndpoint("first-publish-queue", e =>
        {
            e.Bind("publish_exchange");
            e.ConfigureConsumer<FirstEventConsumer>(context);
        });
        cfg.ReceiveEndpoint("second-publish-queue", e =>
        {
            e.Bind("publish_exchange");
            e.ConfigureConsumer<SecondEventConsumer>(context);
        });



    });
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddScoped<MyPublisher>();
builder.Services.AddScoped<ITokenService, TokenService>();
var app = builder.Build();

app.MapDefaultEndpoints();
if (args.Length >= 2 && args[0].Length == 1 && args[1].ToLower() == "seeddata")
{
    await SeedData.SeedUsersAndRolesAsync(app);
}
else
{
    Console.WriteLine("Invalid arguments or missing command.");
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();


