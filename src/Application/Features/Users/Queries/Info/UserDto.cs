using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Users.Queries.Info;

public class UserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long NationalCode { get; set; }
    public StatusEnum IsActive { get; set; }
    public bool IsAdmin { get; set; }

    public DateTimeOffset LastModified { get; set; }
    public DateTimeOffset Created { get; set; }
    public string? LastModifiedBy { get; set; }

    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Pagination<User>, Pagination<UserDto>>()
                .ForMember(dest =>
                    dest.Items, opt =>
                    opt.MapFrom(src => src.Items));
        }
    }
}
