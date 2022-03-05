using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Class
{
    class Task
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Date_Redact { get; set; }
        public string Status { get; set; }
    }
}
