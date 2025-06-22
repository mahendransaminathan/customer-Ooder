using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using CustomerOrder.Services;
using Blazored.LocalStorage;
using CustomerOrder; // Add this line if your App.razor is in the root namespace 'CustomerOrder'

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
// Ensure JwtAuthStateProvider is defined in your project, e.g., in CustomerOrder/Authentication/JwtAuthStateProvider.cs
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>();
// Register the handler
builder.Services.AddScoped<AuthHeaderHandler>();

// Inject HttpClient that uses the handler
builder.Services.AddScoped<AuthHeaderHandler>();

builder.Services.AddHttpClient("AuthenticatedClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5277/");
})
.AddHttpMessageHandler<AuthHeaderHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AuthenticatedClient"));

await builder.Build().RunAsync();
