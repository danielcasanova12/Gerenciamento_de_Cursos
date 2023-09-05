using Curso.RazorPages.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
// using(var scope = app.Services.CreateAsyncScope()){

//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<AppDbContext>();
//     context.Database.EnsureCreated();
//     DbInitializer.Initialize(context);
    
// }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();


app.Run();