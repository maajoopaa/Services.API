using Services.Core.Interfaces;
using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess.Repositories
{
    public class SpecializationsRepository : BaseRepository<Specialization>, ISpecializationsRepository
    {
        public SpecializationsRepository(ServicesDbContext context) 
            : base(context) { } 
    }
}
