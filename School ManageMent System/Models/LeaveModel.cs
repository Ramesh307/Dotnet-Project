namespace SchoolManageMentSystem.Models
{
    public class LeaveModel
    {
        public int Id { get; set; }
        public string Lstatus { get; set; }

        public string Ldescription { get; set; }    

        public DateTime Schedule { get; set; }

        public string StudentId { get; set; }
    }
}
