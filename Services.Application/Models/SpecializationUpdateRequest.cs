using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Models
{
    public class SpecializationUpdateRequest
    {
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; } = false;

        public List<Guid> ServiceIds { get; set; } = [];
    }
}
