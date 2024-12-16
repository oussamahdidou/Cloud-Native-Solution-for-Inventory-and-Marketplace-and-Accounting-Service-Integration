using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);
var redis =builder.AddRedis("redis", port: 6379)
    .WithImage("redis",tag:"latest");
var sqlserver = builder.AddSqlServer("sqlserver", port: 1433)
    .WithVolume("microservices_sqlserver_data", "/var/opt/mssql")
    .WithEnvironment("SA_PASSWORD", "Coding@1234?")
    .WithEnvironment("ACCEPT_EULA","Y");
var postgres = builder.AddPostgres("postgresql", port: 5432)
    .WithVolume("microservices_postgres_data", "/var/lib/postgresql/data")
    .WithImage("postgres", tag: "15")
    .WithEnvironment("POSTGRES_USER","stockuser")
    .WithEnvironment("POSTGRES_PASSWORD","stockpassword")
    .WithEnvironment("POSTGRES_DB", "stock");
var rabbitmq = builder.AddRabbitMQ("rabbitmq", port: 5672)
    .WithManagementPlugin(port: 15672)
    .WithEnvironment("RABBITMQ_DEFAULT_USER", "guest")
    .WithEnvironment("RABBITMQ_DEFAULT_PASS", "guest")
    .WithImage("rabbitmq", tag: "3-management");
builder.AddProject<Projects.UsersService>("usersservice")
    .WithReference(rabbitmq)
    .WithReference(sqlserver)
    .WithReference(redis);
builder.AddProject<Projects.Gateway>("gateway");
builder.AddProject<Projects.MarketplaceService_API>("marketplaceservice-api")
    
    .WithReference(rabbitmq)
    .WithReference(sqlserver)
    .WithReference(redis);

var executableapp = builder.AddSpringApp("executableapp",
    @"C:\\Users\\pc\\Downloads\\projects\\microservices\\backend\\services\\stockservice\\build\\libs\\stockservice-0.0.1-SNAPSHOT.jar",
    new JavaAppExecutableResourceOptions()
    {
        
        ApplicationName = "stockservice",
        OtelAgentPath = "C:\\Users\\pc\\Downloads\\projects\\microservices\\backend\\services\\stockservice\\agents\\opentelemetry-javaagent.jar"
    })
.WithEnvironment("DB_HOST", "127.0.0.1");
builder.Build().Run();
