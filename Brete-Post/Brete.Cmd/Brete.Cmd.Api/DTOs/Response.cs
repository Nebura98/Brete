using Post.Common.DTOs;

namespace Post.Cmd.Api.DTOs;

public record Response : BaseResponse
{
    public Guid Id { get; set; }
}