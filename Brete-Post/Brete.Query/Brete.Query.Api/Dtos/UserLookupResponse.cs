using Brete.Query.Domain.Entities;
using Post.Common.DTOs;

namespace Brete.Query.Api.Dtos;

public record UserLookupResponse : BaseResponse
{
    public List<UserEntity> Users { get; set; }

}
