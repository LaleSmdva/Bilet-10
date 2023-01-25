using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ITeamMemberService
    {
        IEnumerable<TeamMember> GetAll();
        Task<TeamMember> GetByIdAsync(int id);
        Task CreateAsync();
        void Update();
        void Delete();
        void SaveAsync();
    }
}
