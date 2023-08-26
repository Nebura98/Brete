namespace Brete.Cmd.Infrastructure.Config;

public class MongoDbConfig
{
    public required string ConnectionString { get; set; }
    public required string DataBase { get; set; }
    public required string Collection { get; set; }
}