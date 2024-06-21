using AutoMapper;
using Graduation_Project.DTO.NotificationsDto;
using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Repository
{
    public class NotificationRepository:INotificationRepository
    {
        private readonly Context context;
        private readonly IMapper _mapper;
        public NotificationRepository(Context context, IMapper _mapper)
        {
            this.context = context;
            this._mapper = _mapper;
        }
        public List<NotificationsDto> ToClient(int id)
        {
            List<Notifications> notifications=context.Notifications.Where(o=>o.ClientId==id).ToList();
            List<NotificationsDto> notificationsDto = new List<NotificationsDto>();
            foreach(var notification in notifications)
            {
                NotificationsDto notificationDto = new NotificationsDto();
                notificationDto.Messege=notification.Messege;
                notificationDto.Date=notification.Date;
                notificationsDto.Add(notificationDto);
            }
            return notificationsDto;
        }
        public List<NotificationsDto> ToWorker(int id)
        {
            List<Notifications> notifications = context.Notifications.Where(o => o.WorkerId == id).ToList();
            List<NotificationsDto> notificationsDto = new List<NotificationsDto>();
            foreach (var notification in notifications)
            {
                NotificationsDto notificationDto = new NotificationsDto();
                notificationDto.Messege = notification.Messege;
                notificationDto.Date = notification.Date;
                notificationsDto.Add(notificationDto);
            }
            return notificationsDto;
        }
    }
}
