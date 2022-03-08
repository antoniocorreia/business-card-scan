using Microsoft.AspNetCore.Components.WebView.Maui;
using BusinessCardScan.Mobile.Data;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using Plugin.Media;

namespace BusinessCardScan.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.RegisterBlazorMauiWebView()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        builder.Services.AddHttpClient("BCM.ServerAPI", client => {
			client.BaseAddress = new Uri("https://business-card-scan-api.azurewebsites.net/");
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
			//client.DefaultRequestHeaders.Add("Content-Type", "multipart/form-data");
		});
		builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BCM.ServerAPI"));
		
		builder.Services.AddBlazorWebView();
		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
