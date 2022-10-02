using Kafka.Base.Consumer;
using Kafka.Base;
using Serilog;
using Customer.EmailSender.Consumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, services, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services).Enrich.FromLogContext());

// Add services to the container.
builder.Services.AddHostedService<Worker>();

builder.Services.AddOptions<KafkaConfigurations>()
                .Bind(builder.Configuration.GetSection("Kafka"));

builder.Services.AddKafkaConsumer(typeof(Program));


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
