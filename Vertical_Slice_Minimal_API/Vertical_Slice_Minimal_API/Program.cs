using Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
    options.InferSecuritySchemes();
});
builder.Services.AddCarter(); // Register Carter to handle route modules

var app = builder.Build();

// Configure Swagger in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Register Carter routes
app.MapCarter();

// Set up middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  // Map controller routes (if you have any controllers)

// Run the app
app.Run();
