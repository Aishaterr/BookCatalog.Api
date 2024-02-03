using BookCatalog.Api.Book;
using BookCatalog.Domain.Repositories;
using BookCatalog.Persistence;
using BookCatalog.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "V1",
        Title = "Book Catalog API",
        Description = "An API to manage books."
    });
});

services.AddMediatR(config => config.RegisterServicesFromAssembly(BookCatalog.Application.AssemblyReference.Assembly));

services.AddDbContext<BookCatalogDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookCatalog"));

services.AddScoped<IBookRepository, BookRepository>();

services.AddScoped<DataSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { 
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterBookEndpoints();

app.UseHttpsRedirection();

// seed in-memory dB
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    dataSeeder.Seed();
}

app.Run();