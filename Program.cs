    using Microsoft.EntityFrameworkCore;
    using todo_list_angular.Models;
    using todo_list_angular.Repository;
    using todo_list_angular.Repository.Impl;
    using todo_list_angular.Services;
    using todo_list_angular.Services.Impl;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddScoped<ITodoService, TodoService>();
    builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    //Database Sql Server
    builder.Services.AddDbContext<DbContexto>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
