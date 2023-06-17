using ErpaHoldingFatihKarakas.Application.Services.Baskets;
using ErpaHoldingFatihKarakas.Application.Services.Brands;
using ErpaHoldingFatihKarakas.Application.Services.Categories;
using ErpaHoldingFatihKarakas.Application.Services.Models;
using ErpaHoldingFatihKarakas.Application.Services.Orders;
using ErpaHoldingFatihKarakas.Application.Services.Products;
using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Services;
using ErpaHoldingFatihKarakas.Domain.Token;
using ErpaHoldingFatihKarakas.EntityFrameworkCore;
using ErpaHoldingFatihKarakas.Repository.Authentication;
using ErpaHoldingFatihKarakas.Repository.Baskets;
using ErpaHoldingFatihKarakas.Repository.Brands;
using ErpaHoldingFatihKarakas.Repository.Categories;
using ErpaHoldingFatihKarakas.Repository.Models;
using ErpaHoldingFatihKarakas.Repository.Orders;
using ErpaHoldingFatihKarakas.Repository.Products;
using ErpaHoldingFatihKarakas.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<IBasketServices, BasketService>();
builder.Services.AddScoped<IBrandServices, BrandServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IModelServices, ModelServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoriesRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();


builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<User, Role>(Opt =>
{
    Opt.User.RequireUniqueEmail = true;
    Opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecuritykeymysecuritykeymysecuritykeymysecuritykey")),
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
