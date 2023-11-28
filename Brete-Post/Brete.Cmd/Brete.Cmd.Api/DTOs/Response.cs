using Post.Common.DTOs;

namespace Post.Cmd.Api.DTOs;

public class Response : BaseResponse
{
    public Guid Id { get; set; }
}