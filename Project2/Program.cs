using Microsoft.EntityFrameworkCore;
using Project2.Business.Services;
using Project2.EF;
using Project2.Persistence.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //Needed for Cors
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<EstateContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("estateagents")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors allows client requests to be made from same (localhost) machine
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            //policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();