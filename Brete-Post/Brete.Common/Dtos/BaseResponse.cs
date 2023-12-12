namespace Post.Common.DTOs;

public record BaseResponse
{
    public required string Message { get; set; }
}