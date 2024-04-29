using Contacts.WebAPI;
using Contacts.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDBContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();


app.MapPost("/api/contacts", async (Contact contact, ApplicationDBContext db) => {
    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
});

app.MapGet("/api/contacts", async (ApplicationDBContext db) => {
    var contacts = await db.Contacts.ToListAsync();
    return Results.Ok(contacts);
});

app.MapPut("/api/contacts/{id}", async (int id, Contact contact, ApplicationDBContext db) => {
    var contactsToUpdate = await db.Contacts.FindAsync(id);

    if (contactsToUpdate is null) return Results.NotFound();

    contactsToUpdate.Name = contact.Name;
    contactsToUpdate.Email = contact.Email;
    contactsToUpdate.Phone = contact.Phone;
    contactsToUpdate.Address = contact.Address;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();


