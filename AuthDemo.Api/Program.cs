using AuthDemo.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContexts(builder.Configuration)
    .AddApplication()
    .AddInfrastructure()
    .AutentificationService(builder.Configuration);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
