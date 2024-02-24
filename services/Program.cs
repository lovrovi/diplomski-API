using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using services;
using services.Models;
using services.Requests;
using services.Responses;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AdContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AdContext")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Advertisement API",
        Description = "An API for ad data",
        Version = "v1"
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advertisement API V1");
});
app.UseCors("MyAllowedOrigins");

app.MapGet("/advertisements",
    async ([FromQuery] int pageSize,
    [FromQuery] int pageNum,
    [FromQuery] string sortBy,
    [FromServices] IMapper mapper,
    [FromServices] AdContext db) =>
    {
        System.Reflection.PropertyInfo prop = typeof(Advertisement).GetProperty(sortBy);
        var query = db.Advertisements.AsQueryable();
        var pages = (query.Count() + pageSize - 1) / pageSize;
        var data = await query
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        var adData = data
            .OrderBy(x => prop.GetValue(x))
            .Select((x) => mapper.Map<AdvertisementResponse>(x));

        var res = new AdvertisementPaginatedResponse { Data = adData, Pages = pages };
        return res;
    });

app.MapPost("/advertisements",
    async ([FromBody] AdvertisementPostRequest req,
    [FromServices] IMapper mapper,
    [FromServices] AdContext db) =>
    {
        var data = mapper.Map<Advertisement>(req);
        data.Views = 0;
        data.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        data.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
        await db.Advertisements.AddAsync(data);
        await db.SaveChangesAsync();
        return Results.Created($"/ad/{data.Id}", data);
    });


app.Run();
