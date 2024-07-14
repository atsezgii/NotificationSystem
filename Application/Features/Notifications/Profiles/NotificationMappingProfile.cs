using Application.Features.Notifications.Commands.MarkAsRead;
using Application.Features.Notifications.Commands.SendNotification;
using Application.Features.Notifications.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notifications.Profiles
{
    public class NotificationMappingProfile  : Profile
    {
        public NotificationMappingProfile()
        {
        CreateMap<Notification, SendNotificationCommand>().ReverseMap();
        CreateMap<Notification, SendNotificationResponse>().ReverseMap();
        CreateMap<Notification, MarkAsReadCommand>().ReverseMap();
        CreateMap<Notification, MarkAsReadResponse>().ReverseMap();
        CreateMap<Notification, GetNotificationsQuery>().ReverseMap();
        CreateMap<Notification, GetNotificationsResponse>().ReverseMap();

        }
    }
}
