using System;

namespace TestTask.Domain
{
    public class Task
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Date_Redact { get; set; }
        public string Status { get; set; }
        public int VendorID { get; set; }
        public int ExecutorID { get; set; }
    }
}
