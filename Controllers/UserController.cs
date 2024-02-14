// Ignore Spelling: username API

using API.Data;
using API.Dto;
using API.Entities;
using API.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>>GetAllUser()
        {
           var users = await _userRepository.GetAllUserAsync();
           var userToReturn = _mapper.Map<IEnumerable<UserDto>>(users);
           return Ok(userToReturn);
        }
        [HttpGet(":{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetAllUserById(id);
            var userToReturn = _mapper.Map<UserDto>(user);
            return userToReturn;          
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserDto>> GetUserByName(string username)
        {
            var user = await _userRepository.GetAllUserByName(username);
            var userToReturn = _mapper.Map<UserDto>(user);
            return userToReturn;
        }
    }
}
