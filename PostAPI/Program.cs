var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("https://*:5000");

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// https://www.c-sharpcorner.com/article/enable-cors-consume-web-api-by-mvc-in-net-core-4/
//builder.Services.AddCors(opt =>
//{
//    opt.AddDefaultPolicy(bld =>
//    {
//        bld.WithOrigins("https://localhost:5000").AllowAnyHeader().AllowAnyMethod();
//    });
//});

var app = builder.Build();


app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});


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
