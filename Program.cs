using FormulaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "Formula 1 API",
    Description = "API aplicando repository pattern",
    Version = "v1",
    TermsOfService = null,
    Contact = new OpenApiContact{Name = "Lucas Lima", Email = "lucaslima.94@hotmail.com.br", Url = new Uri("https://www.linkedin.com/in/l1malucasdev")},
    License = null,
}));

builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("LocalConnection")));
var app = builder.Build();

// Using swagger in production
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //   options.RoutePrefix = string.Empty; Means the route "localhost/" will show swagger,if you haven't this line API will launch "localhost/swagger/index"
    // options.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
