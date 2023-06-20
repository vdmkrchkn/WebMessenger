using app.Models.Entities;
using app.Models.ViewModels;
using AutoMapper;

namespace app.Context
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageView, Message>(MemberList.None)
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Text));

            CreateMap<Message, MessageView>(MemberList.None)
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Contact.Name));
        }
    }
}
