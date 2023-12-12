using Brete.Cmd.Api.Commands;
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
        BsonClassMap.RegisterClassMap<JobRemovedEvent>();
        BsonClassMap.RegisterClassMap<CompanyCreatedEvent>();
        BsonClassMap.RegisterClassMap<CompanyUpdatedEvent>();
        BsonClassMap.RegisterClassMap<CompanyDisableEvent>();
        BsonClassMap.RegisterClassMap<CompanyDeletedEvent>();
        BsonClassMap.RegisterClassMap<SkillCreatedEvent>();
        BsonClassMap.RegisterClassMap<SkillUpdatedEvent>();
        BsonClassMap.RegisterClassMap<SkillDisableEvent>();
        BsonClassMap.RegisterClassMap<SkillDeletedEvent>();
        BsonClassMap.RegisterClassMap<UserCreatedEvent>();
        BsonClassMap.RegisterClassMap<UserUpdatedEvent>();
        BsonClassMap.RegisterClassMap<DisableUserCommand>();
        BsonClassMap.RegisterClassMap<DeleteUserCommand>();
        BsonClassMap.RegisterClassMap<UpdatePasswordUserCommand>();
        BsonClassMap.RegisterClassMap<UserResetPasswordEvent>();
    }

}