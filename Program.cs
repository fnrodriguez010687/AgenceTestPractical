
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var app = builder.Build();
//builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
