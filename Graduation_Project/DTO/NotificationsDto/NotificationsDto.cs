namespace Graduation_Project.DTO.NotificationsDto
{
    public class NotificationsDto
    {
        public string Messege { get; set; }
        //ClientId or WorkerId
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
