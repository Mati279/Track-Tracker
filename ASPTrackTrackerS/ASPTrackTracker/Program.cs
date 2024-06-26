using ASPTrackTracker.Comparers;
using ASPTrackTracker.FillersAndFilters;
using ASPTrackTracker.ScoreHelpers;
using DataLibrary;
using DataLibrary.Data;
using DataLibrary.Db;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ASPTrackTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton(new ConnectionStringData
            {
                sqlConnectionName = "Default"
            });
            builder.Services.AddSingleton<IDataAccess, SqlDb>();
            builder.Services.AddSingleton<ITrackData, TrackData>();
            builder.Services.AddSingleton<IUserData, UserData>();
            builder.Services.AddSingleton<IScoreData, ScoreData>();
            builder.Services.AddSingleton<IArtistData, ArtistData>();
            builder.Services.AddSingleton<IGenreData, GenreData>();
            builder.Services.AddSingleton<IStyleData, StyleData>();


            builder.Services.AddSingleton<SelectListsFiller, SelectListsFiller>();
            builder.Services.AddSingleton<TrackFilter, TrackFilter>();
            builder.Services.AddSingleton<ComparablesCreator, ComparablesCreator>();
            builder.Services.AddSingleton<ScoresManager, ScoresManager>();
            builder.Services.AddSingleton<ScoresSorter, ScoresSorter>();
            builder.Services.AddSingleton<ArtistsFilter, ArtistsFilter>();

            //En Program.cs.
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Users/UserLogin"; 
                options.LogoutPath = "/Index"; 
                options.AccessDeniedPath = "/AccessDenied"; 
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
