using AutoMapper;
using ChatApp.Core.Entities;
using ChatApp.Core.ViewModels;

namespace ChatApp.Communication.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();
        }
    }
}
