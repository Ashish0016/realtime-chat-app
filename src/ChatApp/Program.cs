using ChatApp.AttributeFilters;
using ChatApp.Constants;
using ChatApp.Extensions;
using ChatApp.SignalR;
using Core.CoreExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionAttributeFilter>();
    options.Filters.Add(new AuthorizeFilter(
            new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build()));
});

builder.Services.AddMediatR();
builder.Services.AddSignalR();
builder.Services.AddApiCorsPolicy();
builder.Services.CoreExtensions(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(GlobalConstant.CorsPolicyName);

app.UseAuthentication();

app.UseAuthorization();

app.MapHub<ChatHub>("chat-hub");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
