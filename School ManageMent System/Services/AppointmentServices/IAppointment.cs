using SchoolManageMentSystem.Models;

namespace SchoolManageMentSystem.Services.AppointmentServices
{
    public interface IAppointment
    {
        public void Create(AppointmentModel model);
    }
}
