using DAL;
using DAL.Interfaces;
using DAL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Permite que el frontend puead usar la API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añade el DBContext
builder.Services.AddDbContext<DBContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICamping, CampingManager>();
builder.Services.AddTransient<IService, ServiceManager>();
builder.Services.AddTransient<IUser, UserManager>();
builder.Services.AddTransient<IComment, CommentManager>();
builder.Services.AddTransient<IRequest, RequestManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
