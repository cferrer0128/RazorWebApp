
using BlazorAppWebApp.Components;
using BlazorAppWebApp.Services;



var builder = WebApplication.CreateBuilder(args);
var environmentName = Environment.GetEnvironmentVariable("HTTP_ENVIRONMENT");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(uriString: environmentName) });


builder.Services.AddScoped<INote, ClientNote>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(builder.Configuration.GetSection("BaseUri").Value!);
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    ;

app.Run();
