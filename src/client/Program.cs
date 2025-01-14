using AzureStaticWebApps.Blazor.Authentication;
using Cloud5mins.TinyBlazorAdmin;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
		.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
		.AddStaticWebAppsAuthentication();

builder.Services.AddMsalAuthentication(options =>
{
	builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

// regiser fusion blazor service
// Community Licence for your personal use ONLY. Thank you Syncfusion for this generous offer.
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzYyMzI1QDMyMzAyZTMxMmUzMFY0cEZ3MVozdkwvekVhek8xTWdPMkg2NlhvdVFNR1lvZHdhQWJWUlNjZW89");
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

await builder.Build().RunAsync();
