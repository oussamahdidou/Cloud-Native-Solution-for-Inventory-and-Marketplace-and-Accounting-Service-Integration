var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.UsersService>("usersservice");

builder.AddProject<Projects.Gateway>("gateway");

builder.AddProject<Projects.MarketplaceService_API>("marketplaceservice-api");

builder.Build().Run();
