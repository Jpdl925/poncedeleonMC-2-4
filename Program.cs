var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/doMath", (int a = 1, int b = 2) =>
{
    return $"{a} + {b} = {a+b}";
});


app.MapGet("/wakeUp", (string name = "Nobody", string time = "some time") =>
{
    return $"Hello {name}, you woke up at {time}. Congrats!";
});


app.MapGet("/compare", (int a = 1, int b = 2) =>
{
    if (a > b){
        return $"First number {a} is greater than second number {b}\nSecond number {b} is less than first number {a}";
    }
    else if(a < b){
        return $"First number {a} is less than second number {b}\nSecond number {b} is greater than first number {a}";
    }
    else{
        return $"First number {a} and second number {b} are EQUAL";
    }

});


app.Run();

