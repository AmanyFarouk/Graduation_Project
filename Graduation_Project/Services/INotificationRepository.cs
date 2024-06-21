using Graduation_Project.DTO.NotificationsDto;

namespace Graduation_Project.Services
{
    public interface INotificationRepository
    {
        List<NotificationsDto> ToClient(int id);
        List<NotificationsDto> ToWorker(int id);
    }
}
