namespace SchoolManageMentSystem.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public string Details { get; set; }

        public DateTime Schedule { get; set; }
         
        public string GuardianId { get; set; }  


        public int DepartmentId { get; set; }   

        public string Status { get; set; }

    }
}
