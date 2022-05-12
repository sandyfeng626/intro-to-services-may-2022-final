var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ConfigureServices in Startup.cs
builder.Services.AddCors(corsBuilder =>
{
    corsBuilder.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyMethod();
        pol.AllowAnyHeader();
    });
});
var fileScheduler = new FileScheduleAdapter(); // we create it here.. "Eager"
builder.Services.AddSingleton(fileScheduler);
// builder.Services.AddSingleton<FileScheduleAdapter>(); // "Lazy"
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Kestrel

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthorization();

app.MapControllers();

// Blocking call.
app.Run();
