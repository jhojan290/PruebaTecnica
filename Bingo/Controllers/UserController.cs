using AutoMapper;
using Bingo.API.Responses;
using Bingo.Core.Dto;
using Bingo.Core.Entities;
using Bingo.Core.Interfaces;
using Bingo.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Bingo.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UserController(IUserService userService, IMapper mapper, ApplicationDbContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            var response = new ApiResponse<IEnumerable<UserDto>>(usersDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);

            var userDto = _mapper.Map<UserDto>(user);

            var response = new ApiResponse<UserDto>(userDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDto userDto)
        {

            var numeroExistente = _context.Users
            .FirstOrDefault(n => n.IdCliente == userDto.IdCliente || n.IdSorteo == userDto.IdSorteo || n.IdUsuario == userDto.IdUsuario);

            if (numeroExistente != null)
            {
                return Conflict("El cliente ya existe.");
            }

            int numeroAleatorio = new Random().Next(10000, 100000);
         
            //numeroAleatorio.ToString("D5");
           
            var user = _mapper.Map<User>(userDto);

            user.Numero = numeroAleatorio;

            await _userService.InsertUser(user);

            userDto = _mapper.Map<UserDto>(user);

            var response = new ApiResponse<UserDto>(userDto);

            return Ok(response);
        }
    }
}
