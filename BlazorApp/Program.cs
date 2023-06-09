﻿using BlazorApp.Areas.Identity;
using BlazorApp.Data;
using BlazorApp.Models;
using BlazorApp.Models.Notes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            builder.Services.AddSingleton<WeatherForecastService>();


            //[DNN][1] Registering for a bulletin board service.            
            //[1] Specifying a concatenated string as a joined string with a string constructor.
            //services.AddSingleton<INoteRepository>(
            //  new NoteRepository(
            //      Configuration["Data:DefaultConnection:ConnectionString"]));            
            //[2] Injecting Configuration through Dependency Injection.
            //[a] Accessing the database connection string through IConfiguration in NoteRepository.
            builder.Services.AddTransient<INoteRepository, NoteRepository>();
            //[b] Passing the database connection string directly to the constructor of CommentRepository.
            //services.AddSingleton<INoteCommentRepository>(
            //    new NoteCommentRepository(
            //        Configuration["ConnectionStrings:DefaultConnection"]));
            //[b] Changing the above code
            builder.Services.AddTransient<INoteCommentRepository, NoteCommentRepository>();

            IServiceCollection serviceCollection = builder.Services.AddDbContext<DotNetNoteContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}