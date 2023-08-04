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

var app = builder.Build();

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
