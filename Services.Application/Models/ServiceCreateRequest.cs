using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Models
{
    public class ServiceCreateRequest
    {
        public string Name { get; set; } = null!;

        public double Price { get; set; } = 0;

        public Guid CategoryId { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
