
using Ecommerce.Server.Helper;
using Ecommerce.Server.Models.Domain;
using Ecommerce.Server.Repsitories.Abstrarct;
using Ecommerce.Server.Repsitories.Implemintation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Stripe;
using System.Configuration;
using System.Globalization;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddTransient<IUserRepsitory, UserRepsitory>();
builder.Services.AddTransient<IProductRepsitory, ProductRepsitory>();
builder.Services.AddTransient<ICategoryRepsitory, CategoryRepsitory>();
builder.Services.AddTransient<IAuthRepsitory, AuthRepsitory>();
//builder.Services.AddTransient<IOrderRepsitory, OrderRepsitory>();
//builder.Services.AddTransient<IAuthRepsitory, AuthRepsitory>();

var defaultCulture = new CultureInfo("en-US");


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();



builder.Services.AddEndpointsApiExplorer();
var secretKey = builder.Configuration.GetSection("AppSettings:key").Value;
var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = key,
        ClockSkew = TimeSpan.Zero
    };
});





// Configure the HTTP request pipeline.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
//this has to be Synchoars
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
    });
}
app.UseHttpsRedirection();
app.UseCors(option => option.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseStaticFiles();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture },
});



app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=pg}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
