var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var info = app.Configuration.GetSection("Service").Get<ServiceInfo>() ?? new ServiceInfo();

app.MapGet("/", () => Results.Ok(new { service = info.Name }));
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));
app.MapGet("/version", () => Results.Ok(new {
    service = info.Name,
    version = info.Version,
    commitSha = info.CommitSha,
    buildTime = info.BuildTime,
    environment = app.Environment.EnvironmentName,
}));

app.Run();

public sealed class ServiceInfo {
    public string Name { get; set; } = "service";
    public string Version { get; set; } = "v0.0.0-dev";
    public string CommitSha { get; set; } = "local";
    public string BuildTime { get; set; } = "unknown";
}

public partial class Program;
