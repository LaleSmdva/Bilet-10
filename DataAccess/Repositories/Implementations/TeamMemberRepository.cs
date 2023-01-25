using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class TeamMemberRepository:Repository<TeamMember>,ITeamMemberRepository
    {
        public TeamMemberRepository(AppDbContext context):base(context)
        {

        }
    }
}
