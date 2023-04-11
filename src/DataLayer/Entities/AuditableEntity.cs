using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class AuditableEntity
    {
        public string? CreateBy { get; set; }
        public DateTime CreatedWhen { get; set; }
        public DateTime ModifiedWhen { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
