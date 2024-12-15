using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
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
builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseCors("AllowOrigin");
app.MapGet("/", () => "Hello World!");
await app.UseOcelot();

app.Run();
