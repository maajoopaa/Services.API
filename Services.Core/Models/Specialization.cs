using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Models
{
    public class Specialization
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; } = false; 
    }
}
