using Brete.Common.Events.Company;
using Brete.Common.Events.Job;
using Brete.Common.Events.Skill;
using Brete.Common.Events.User;
using CQRS.Core.Events;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Brete.Query.Infrastructure.Converters;

public class EventJsonConverter : JsonConverter<BaseEvent>
{
    public override bool CanConvert(Type type)
    {
        return type.IsAssignableFrom(typeof(BaseEvent));
    }

    public override BaseEvent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var doc))
        {
            throw new JsonException($"Failed to parse {nameof(JsonDocument)}");
        }

        if (!doc.RootElement.TryGetProperty("Type", out var type))
        {
            throw new JsonException("Could not detect the Type discriminator property!");
        }

        var typeDiscriminator = type.GetString();
        var json = doc.RootElement.GetRawText();

        return typeDiscriminator switch
        {
            nameof(JobCreatedEvent) => JsonSerializer.Deserialize<JobCreatedEvent>(json, options),
            nameof(JobUpdatedEvent) => JsonSerializer.Deserialize<JobUpdatedEvent>(json, options),
            nameof(JobDisableEvent) => JsonSerializer.Deserialize<JobDisableEvent>(json, options),
            nameof(JobDeletedEvent) => JsonSerializer.Deserialize<JobDeletedEvent>(json, options),
            nameof(CompanyCreatedEvent) => JsonSerializer.Deserialize<CompanyCreatedEvent>(json, options),
            nameof(CompanyUpdatedEvent) => JsonSerializer.Deserialize<CompanyUpdatedEvent>(json, options),
            nameof(CompanyDisableEvent) => JsonSerializer.Deserialize<CompanyDisableEvent>(json, options),
            nameof(CompanyRemovedEvent) => JsonSerializer.Deserialize<CompanyRemovedEvent>(json, options),
            nameof(SkillCreatedEvent) => JsonSerializer.Deserialize<SkillCreatedEvent>(json, options),
            nameof(SkillUpdatedEvent) => JsonSerializer.Deserialize<SkillUpdatedEvent>(json, options),
            nameof(SkillDisableEvent) => JsonSerializer.Deserialize<SkillDisableEvent>(json, options),
            nameof(SkillDeletedEvent) => JsonSerializer.Deserialize<SkillDeletedEvent>(json, options),
            nameof(UserCreatedEvent) => JsonSerializer.Deserialize<UserCreatedEvent>(json, options),
            nameof(UserUpdatedEvent) => JsonSerializer.Deserialize<UserUpdatedEvent>(json, options),
            nameof(UserDisableEvent) => JsonSerializer.Deserialize<UserDisableEvent>(json, options),
            nameof(UserDeletedEvent) => JsonSerializer.Deserialize<UserDeletedEvent>(json, options),
            nameof(UserUpdatedPasswordEvent) => JsonSerializer.Deserialize<UserUpdatedPasswordEvent>(json, options),
            nameof(UserResetPasswordEvent) => JsonSerializer.Deserialize<UserResetPasswordEvent>(json, options),
            _ => throw new JsonException($"{typeDiscriminator} is not supported yet!")
        };
    }

    public override void Write(Utf8JsonWriter writer, BaseEvent value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
