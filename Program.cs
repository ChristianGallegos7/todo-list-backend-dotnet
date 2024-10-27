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

    //Habilitar CORS
    builder.Services.AddCors(options => {
        options.AddPolicy("AllowAngular", builder => {
            builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
        });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowAngular");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
