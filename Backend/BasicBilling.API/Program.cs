using BasicBilling.Core.Interfaces;
using BasicBilling.Core.Services;
using BasicBilling.Infrastructure.Data;
using BasicBilling.Infrastructure.Filters;
using BasicBilling.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services
.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
})
.ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
}); ;
builder.Services.AddDbContext<BasicBillingContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("BasicBillingDatabase")));
builder.Services.AddTransient<IBillService, BillService>();
builder.Services.AddTransient<IBillRepository, BillRepository>();
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
});
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic));

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

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
