using System.ComponentModel.DataAnnotations;
using MyApp.DataLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var db = new MyApp.DataLayer.AppDbContext())
{
    db.Database.EnsureCreated();

    var user = new UserEntity { Name = "Shannon Debbusye", Email = "shanon@hotmail.com" };
    db.Users.Add(user);
    db.SaveChanges();
    Console.WriteLine($"User {user.Name} with ID {user.Id} added.");

    Console.WriteLine("All users in the database:");
    var users = db.Users.ToList();
    foreach (var u in users)
    {
        Console.WriteLine($"ID: {u.Id}, Name: {u.Name}, Email: {u.Email}");
    }
    //Console.ReadKey();  //toto je ze musim stlacit enter, aby sa ukazal internet !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
}
app.Run();

