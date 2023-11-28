using CQRS.Core.Events;
using MongoDB.Bson.Serialization;

namespace Brete.Cmd.Api.Configuration;

public static class BsonConfiguration
{

    public static void ConfigureBson()
    {
        BsonClassMap.RegisterClassMap<BaseEvent>();
    }

}
