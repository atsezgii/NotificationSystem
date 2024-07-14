using Persistence;
using Application;
using Core;
using Core.Utilities.JWT;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials() // SignalR için gerekli
                .SetIsOriginAllowed((host) => true);
    });
});
builder.Services.AddControllers();
TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
if (tokenOptions != null)
{
    Console.WriteLine($"Issuer: {tokenOptions.Issuer}");
    Console.WriteLine($"Audience: {tokenOptions.Audience}");
    Console.WriteLine($"Audience: {tokenOptions.ExpirationTime}");
    // Diðer özellikler...
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddCoreServices(tokenOptions);
var app = builder.Build();
app.UseRouting();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
