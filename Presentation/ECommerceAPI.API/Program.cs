using ECommerceAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

//ProductService concrete class�ndaki listeye controllerda ula�mak i�in tetiklenmi�tir.
builder.Services.AddPersistenceServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//4 nolu derste kald�m!!!