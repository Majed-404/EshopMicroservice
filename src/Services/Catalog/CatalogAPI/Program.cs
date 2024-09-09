var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

///Mapster, by default, assumes that property names follow PascalCase conventions. 
///This can cause issues when using lower case property names, 
///as it may not recognize the properties correctly for mapping. 
///Here's how you can configure Mapster to work with lowercase property names
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapCarter();

app.Run();
