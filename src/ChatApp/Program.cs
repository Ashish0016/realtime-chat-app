using ChatApp.Constants;
using ChatApp.Extensions;
using ChatApp.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddApiCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseRouting();

app.UseCors(GlobalConstant.CorsPolicyName);

app.MapHub<ChatHub>("chat-hub");
app.MapControllers();

app.Run();
