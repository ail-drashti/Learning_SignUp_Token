using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
//using SignUp.Data;
//using SignUp.Interfaces;
//using SignUp.Authorize;
using SignUp.Model;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SignUpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls= true);
builder.Services.AddControllers();
//builder.Services.AddTransient<IUnitOfWork>()

//builder.Services.AddScoped<IUnitOfWork,UnitOfWork>( );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//builder.Services.AddAuthorization(options =>
//    {
//        string DefaultAuthorizedPolicy = null;
//        options.AddPolicy(DefaultAuthorizedPolicy, policy =>
//        {
//            policy.Requirements.Add(new TokenAuthRequirement());
//        });
//    });
//builder.Services.AddSingleton<IAuthorizationHandler, AuthTokenPolicy>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "SignUpApi", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
