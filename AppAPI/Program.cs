using Confluent.Kafka;
using Couchbase.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add Couchbase configuration
builder.Services.AddCouchbase(builder.Configuration.GetSection("Couchbase"));
builder.Services.AddCouchbaseBucket<INamedBucketProvider>("test");


// Add Kafka Producer configuration
builder.Services.AddSingleton(x =>
{
    var config = new ProducerConfig();
    builder.Configuration.Bind("Kafka", config);
    return new ProducerBuilder<Null, string>(config).Build();
});

// Add Kafka Consumer configuration (if needed)
builder.Services.AddSingleton(x =>
{
    var config = new ConsumerConfig();
    builder.Configuration.Bind("Kafka", config);
    return new ConsumerBuilder<Ignore, string>(config).Build();
});

// Add services to the container.

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
