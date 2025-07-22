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

builder.Services.AddHttpContextAccessor();

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
builder.Services.AddScoped<IGamesDiscountRepository, GamesDiscountRepository>();
builder.Services.AddScoped<IGamesBannerRepository, GamesBannerRepository>();
builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddScoped<IGameStatisticRepository, GameStatisticRepository>();
builder.Services.AddScoped<IApprovalRepository, ApprovalRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ISystemProfilePictureRepository, SystemProfilePictureRepository>();
builder.Services.AddScoped<IStoreLibraryRepository, StoreLibraryRepository>();




var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings");
builder.Services.Configure<CloudinarySettings>(cloudinarySettings);

builder.Services.AddSingleton(x =>
{
    var config = cloudinarySettings.Get<CloudinarySettings>();
    var account = new Account(config.CloudName, config.ApiKey, config.ApiSecret);
    return new Cloudinary(account);
});

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GSWApi", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                        Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


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
