namespace Persistence.Configurations.Options;

public class MongoOption
{
    public const string Key = "MongoDB";
    public string ServerUrl { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public string Port { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string GetConnectionString()
    {
        if (User == string.Empty || Password == string.Empty)
            return $"mongodb://{ServerUrl}:{Port}/";

        return $"mongodb://{User}:{Password}@{ServerUrl}:{Port}/";
    }
}