using Microsoft.EntityFrameworkCore;
using Twitter.Dal.Contexts;
using Twitter.Business;
using Microsoft.AspNetCore.Identity;
using Twitter.Core.Entities;
using Twitter.Business.ExternalServices;
using Microsoft.AspNetCore.Authentication.OAuth;
using Twitter.Dal;
using Microsoft.OpenApi.Writers;
using Twitter.Core.Enums;
using System.Text;
using Twitter.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.   
builder.Services.AddControllers();
builder.Services.AddDbContext<TwitterContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 4;
    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    options.User.RequireUniqueEmail = false;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<TwitterContext>();
//Repositories Topic
builder.Services.AddRepositories();
//Services Topic
builder.Services.AddServices();
//AddBusinessLayer Topic
builder.Services.AddBusinessLayer();
//Repositories Blog
builder.Services.AddBlogRepositories();
//Services Blog
builder.Services.AddBlogServices();
//AddBusinessLayer Blog
builder.Services.AddBlogBusinessLayer();
//AddEmail
builder.Services.AddEmail();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSeedData();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    });
}

app.UseHttpsRedirection();
app.Use(async (context, n) =>
{
    var a = context.Connection.RemoteIpAddress;
    await n();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
    
