using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Queries.TaskQueries.GetListTaskByVendor
{
    public class GetListTaskByVendorQuery : IRequest<ListTaskByVendorVm>
    {
        public Guid VendorID { get; set; }
    }
}
