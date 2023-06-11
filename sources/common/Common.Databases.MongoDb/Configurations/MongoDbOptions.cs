namespace Common.Databases.MongoDb.Configurations;

public class MongoDbOptions
{

    public static string Section = "MongoDbOptions";

    public string ConnectionString { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
}