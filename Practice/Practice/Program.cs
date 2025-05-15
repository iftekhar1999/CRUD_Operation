using Practice.Services;

var builder = WebApplication.CreateBuilder(args);

//*********************** Add services to the container.***********************
builder.Services.AddSingleton<IPracticeService, practiceService>();
//*********************** Add services to the container end.***********************


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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

app.Run();