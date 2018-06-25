using app.Models.Entities;
using app.Models.ViewModels;
using AutoMapper;

namespace app.Context
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageView, MessageEntity>(MemberList.None);
        }
    }
}
