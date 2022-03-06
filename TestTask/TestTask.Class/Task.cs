using System;

namespace TestTask.Domain
{
    class Task
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Date_Redact { get; set; }
        public User VendorID { get; set; }
        public User ExecutorID { get; set; }
        public string Status { get; set; }
    }
}
