using Contacts.WebAPI;
using Contacts.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

app.MapGet("/api/contacts", async ([FromQuery]string? s, ApplicationDBContext db) => {
    List<Contact> contacts;

    if (string.IsNullOrWhiteSpace(s)) {
        contacts = await db.Contacts.ToListAsync();
    }
    else {
        contacts = await db.Contacts.Where(x => 
                !string.IsNullOrWhiteSpace(x.Name) && x.Name.ToLower().IndexOf(s.ToLower()) >= 0 ||
                !string.IsNullOrWhiteSpace(x.Email) && x.Email.ToLower().IndexOf(s.ToLower()) >= 0 ||
                !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.ToLower().IndexOf(s.ToLower()) >= 0 ||
                !string.IsNullOrWhiteSpace(x.Address) && x.Address.ToLower().IndexOf(s.ToLower()) >= 0)
                .ToListAsync();
    }

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

app.MapDelete("/api/contacts/{id}", async (int id, ApplicationDBContext db) => {
    var contactsToDelete = await db.Contacts.FindAsync(id);

    if (contactsToDelete != null) {
        db.Contacts.Remove(contactsToDelete);
        await db.SaveChangesAsync();
        return Results.Ok(contactsToDelete);
    }
    return Results.NotFound();

});



app.Run();


