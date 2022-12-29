using Application;
using Application.Contracts;
using Application.Features.NoteFeatures.Commands;
using Application.Features.NoteFeatures.Queries;
using Application.Features.UserFeatures.Commands;
using Infrastructure.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy",
        builder => {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:3000");
        });
});

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7288",
            ValidAudience = "https://localhost:7288",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gTqVff3L2j93ufiWf4l0"))
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GetAllNoteListRequest>();
builder.Services.AddTransient<GetNoteById>();
builder.Services.AddTransient<CreateNote>();
builder.Services.AddTransient<UpdateNoteCommand>();
builder.Services.AddTransient<DeleteNoteCommand>();
builder.Services.AddTransient<INotesRepository, NoteRepository>();

builder.Services.AddTransient <CreateNewUserCommand>();
builder.Services.AddTransient<SignInUserCommand>();
builder.Services.AddTransient<IGenerateJWTToken, GenerateJWTToken>();

builder.Services.AddTransient<IUserRepository, UserRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName: "CORSPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
