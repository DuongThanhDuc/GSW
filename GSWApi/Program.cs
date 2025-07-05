using BusinessModel.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GSWApi.Utility;
using DataAccess.Repository.IRepository;
using Repository.Repository.IRepository;
using Repository.Repository;
using DataAccess.Repository;
using CloudinaryDotNet;
using DataAccess.Repository.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameSalesWebsite")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IGamesCategoryRepository, GamesCategoryRepository>();
builder.Services.AddScoped<IGamesTagRepository, GamesTagRepository>();
builder.Services.AddScoped<IGamesInfoRepository, GamesInfoRepository>();
builder.Services.AddScoped<IStoreCartRepository, StoreCartRepository>();
builder.Services.AddScoped<ISystemCategoryRepository, SystemCategoryRepository>();
builder.Services.AddScoped<ISystemTagRepository, SystemTagRepository>();
builder.Services.AddScoped<IGamesMediaRepository, GamesMediaRepository>();
builder.Services.AddScoped<IStoreRefundRequestRepository, StoreRefundRequestRepository>();
builder.Services.AddScoped<IGamesReviewRepository, GamesReviewRepository>();
builder.Services.AddScoped<IStoreThreadRepository, StoreThreadRepository>();
builder.Services.AddScoped<IStoreThreadReplyRepository, StoreThreadReplyRepository>();   
builder.Services.AddScoped<IStoreOrderRepository, StoreOrderRepository>();  
builder.Services.AddScoped<IStoreOrderDetailRepository, StoreOrderDetailRepository>();



var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();

var account = new Account(
    cloudinarySettings.CloudName,
    cloudinarySettings.ApiKey,
    cloudinarySettings.ApiSecret
);

var cloudinary = new Cloudinary(account);
builder.Services.AddSingleton(cloudinary);

builder.Services.AddSingleton<EmailService>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddScoped<JwtTokenGenerator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
