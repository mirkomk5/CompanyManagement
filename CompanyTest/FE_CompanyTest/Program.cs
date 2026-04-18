using FE_CompanyTest.Interfaces;
using FE_CompanyTest.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FE_CompanyTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    // registrazione singleton
                    service.AddSingleton<IAuthService, AuthService>();

                    // registrazione delle form che ricevono dipendenze
                    service.AddTransient<LoginForm>();
                    service.AddTransient<RegisterForm>();
                    service.AddTransient<Home>();
                })
                .Build();

            var loginForm = host.Services.GetRequiredService<LoginForm>();

            
            Application.Run(loginForm);
        }
    }
}