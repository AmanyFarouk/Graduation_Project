using Graduation_Project.DTO.NotificationsDto;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notification)
        {
            _notificationRepository = notification;    
        }
        //error in these actIOns
        [HttpGet("SendNotificationToClient")]
        public IActionResult SendToClient( int id)
        {
            List<NotificationsDto> clientNoti=_notificationRepository.ToClient(id);
            return Ok(clientNoti);
        }
        [HttpGet("SendNotificationToWorker")]
        public IActionResult SendToWorker(int id)
        {
            List<NotificationsDto>workerNoti= _notificationRepository.ToWorker(id);
            return Ok(workerNoti);
        }
    }
}
