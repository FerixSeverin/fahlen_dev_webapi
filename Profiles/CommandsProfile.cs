using AutoMapper;
using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile() {
            //Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}