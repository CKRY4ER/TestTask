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
        public Guid VendorID { get; set; }
        public Guid? ExecutorID { get; set; }
        public User Vendor { get; set; }
        public User? Executor { get; set; }
    }
}
