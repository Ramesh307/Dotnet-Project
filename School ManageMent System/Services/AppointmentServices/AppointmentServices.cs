using SchoolManageMentSystem.Models;

namespace SchoolManageMentSystem.Services.AppointmentServices
{
    public class AppointmentServices:IAppointment
    {
        private readonly SchoolDbContext _schoolDbContext;

        public AppointmentServices(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public void Create(AppointmentModel model)
        {
            _schoolDbContext.Appointments.Add(model);
            _schoolDbContext.SaveChanges();
        }
    }
}
