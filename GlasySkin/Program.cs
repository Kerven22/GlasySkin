using GlasySkin.Extentions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyRefference).Assembly);

builder.Services.RepositoryManagerConfigure();
builder.Services.ServiceManagerConfigure();
builder.Services.CorsConfigure();
builder.Services.SqlServerConfigure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("CustomPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();