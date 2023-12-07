using Brete.Common.Events.Company;
using Brete.Common.Events.Job;
using Brete.Common.Events.Skill;
using Brete.Common.Events.User;
using CQRS.Core.Events;
using MongoDB.Bson.Serialization;

namespace Brete.Cmd.Api.Configuration;

public static class BsonConfiguration
{
    public static void MapBsonClasses()
    {
        BsonClassMap.RegisterClassMap<BaseEvent>();
        BsonClassMap.RegisterClassMap<JobCreatedEvent>();
        BsonClassMap.RegisterClassMap<JobUpdatedEvent>();
        BsonClassMap.RegisterClassMap<JobDisableEvent>();
        BsonClassMap.RegisterClassMap<JobDeletedEvent>();
        BsonClassMap.RegisterClassMap<CompanyCreatedEvent>();
        BsonClassMap.RegisterClassMap<CompanyUpdatedEvent>();
        BsonClassMap.RegisterClassMap<CompanyDisableEvent>();
        BsonClassMap.RegisterClassMap<CompanyRemovedEvent>();
        BsonClassMap.RegisterClassMap<SkillCreatedEvent>();
        BsonClassMap.RegisterClassMap<SkillUpdatedEvent>();
        BsonClassMap.RegisterClassMap<SkillDisableEvent>();
        BsonClassMap.RegisterClassMap<SkillDeletedEvent>();
        BsonClassMap.RegisterClassMap<UserCreatedEvent>();
        BsonClassMap.RegisterClassMap<UserUpdatedEvent>();
        BsonClassMap.RegisterClassMap<UserDisableEvent>();
        BsonClassMap.RegisterClassMap<UserDeletedEvent>();
        BsonClassMap.RegisterClassMap<UserUpdatedPasswordEvent>();
        BsonClassMap.RegisterClassMap<UserResetPasswordEvent>();
    }

}