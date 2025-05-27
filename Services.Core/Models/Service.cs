using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Models
{
    public class Service
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; } = 0;

        public Guid SpecializationId { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
