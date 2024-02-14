﻿using API.Dto;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}
