using Song.Api.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.AddSwaggerDocumentation();
builder.ConfigureDatabase();
builder.ConfigureDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseSwaggerGen();

app.UseHttpsRedirection();
app.MapControllersApp();
await app.ExceptionHandler();

app.Run();
