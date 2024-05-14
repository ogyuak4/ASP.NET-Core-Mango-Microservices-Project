using AutoMapper;
using Mango.Services.CouponAPI;
using Mango.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMvc();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper(); //mappingconfig'teki auto mapperi eklemek için
builder.Services.AddSingleton(mapper);                           //mappingconfig'teki auto mapperi eklemek için
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); bu satýr eðitimde vardý ama hata verdi bkz: stackoverflow.com/questions/78025475/asp-net-core-automapper-how-to-resolve-errorcs0121-the-call-is-ambiguous-betwe

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
ApplyMigration();
app.Run();


void ApplyMigration()  //bu sayede pendind migration var ise komut beklemeden kendisi gidip databaseyi update edecek
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
