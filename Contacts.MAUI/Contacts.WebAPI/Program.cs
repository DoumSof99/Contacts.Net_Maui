using Contacts.WebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDBContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.MapGet("/api/contacts", async (ApplicationDBContext db) => {
    var contacts = await db.Contacts.ToListAsync();
    return Results.Ok(contacts);
});

app.Run();


