using FluentValidation;
using GlasySkin.Extentions;
using GlasySkin.Middleware;
using Services.AuthenticationService;
using Services.ProductService;
using Services.UserService;
using Shared.CreateDtos;
using Shared.ValidatorCommands;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyRefference).Assembly);

builder.Services.RepositoryManagerConfigure();

builder.Services.AddAuthorization();
builder.Services.AddApiAuthentication();

builder.Services.ServiceManagerConfigure();
builder.Services.CorsConfigure();
builder.Services.SqlServerConfigure(builder.Configuration);
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IValidator<ProductRequestDto>, CreateProductCommandValidator>();
builder.Services.AddScoped<IValidator<UserDto>, RegisterUserCommandValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program)); 

var app = builder.Build();

//app.ConfigureExceptionHandler();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseCors("CustomPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.UseMiddleware<ErrorHandleMiddleware>();

app.Run();
