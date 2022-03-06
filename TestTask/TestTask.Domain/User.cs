using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Date_Redact { get; set; }
        public string Status { get; set; }
    }
}
