using System.IdentityModel.Tokens.Jwt;
using System.Text;
using API_REST_PROYECT.Data;
using API_REST_PROYECT.DTOs.Supply;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.JWT;
using API_REST_PROYECT.Models;
using API_REST_PROYECT.Repository;
using API_REST_PROYECT.Services;
using API_REST_PROYECT.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Leer la clave JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTSettings:Secret"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

//Hacemos esta modificacion del manejo de validacion en ModelState. Se explica todo en la clase ValidationFormatter
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFormatter>();
})
.ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISupplyRepository<Profile>, ProfileRepository>();
builder.Services.AddScoped<ISupplyRepository<Glass>, GlassRepository>();
builder.Services.AddScoped<ISupplyRepository<Accessory>, AccessoryRepository>();
builder.Services.AddScoped<ISupplyService<ProfileDTO>, ProfileService>();
builder.Services.AddScoped<ISupplyService<GlassDTO>, GlassService>();
builder.Services.AddScoped<ISupplyService<AccessoryDTO>, AccessoryService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddSingleton<Token>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.Configure<JwtSettingsConfirmation>(builder.Configuration.GetSection("JwtSettingsConfirmation"));
builder.Services.AddDbContext<ContextDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();