using DataOne.WorkspaceHub.API.Exceptions;
using ErrorHandlingDemo.Model;
using ErrorHandlingDemo.Services;
using Microsoft.AspNetCore.Mvc;
using FastEndpoints;
using FastEndpoints.Swagger;
using ErrorHandlingDemo.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddSingleton<PostService, PostService>();
builder.Services.AddFastEndpoints().AddSwaggerGen();

var app = builder.Build();

//app.UseErrorHandlingMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseFastEndpoints().UseSwaggerGen();

app.MapPost("/minimal-posts", (PostService postService, PostCreateRequest postRequest) =>
{
    return postService.Create(new Post { Content = postRequest.Content, Title = postRequest.Title });
}
);

app.Run();
