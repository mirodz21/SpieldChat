// Ignore Spelling: Dto

using API.Dto;
using API.Migrations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Entities
{
    public static class Mapper
    {
       
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                City = user.City,
                Country = user.Country,
                LastActive = user.LastActive,
                Created = user.Created,
            };
        }
        public static User ToEntity(UserDto dto)
        {

            return new User
            {
                Id = dto.Id,
                UserName = dto.UserName,
                FullName = dto.FullName,
                City = dto.City,
                Country = dto.Country,
                LastActive = dto.LastActive,
                Created = dto.Created,
            };
        }
    }
}