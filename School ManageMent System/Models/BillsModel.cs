namespace SchoolManageMentSystem.Models
{
    public class BillsModel
    {
        public int Id { get; set; }
        public string Billstatus { get; set; }

        public DateTime BillDate { get; set; }

        public string  StudentId { get; set; }  

        public string Amount { get; set; }


    }
}
