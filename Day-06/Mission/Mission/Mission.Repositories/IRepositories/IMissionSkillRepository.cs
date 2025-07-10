using Mission.Entities.Entities;
using Mission.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepositories
{
    public interface IMissionSkillRepository
    {
        Task<bool> AddMissionSkill(MissionSkill missionSkill);
        Task<bool> DeleteMissionSkill(int id);
        Task<List<MissionSkillModel>> GetAllMissionSkill();
        Task<MissionSkillModel?> GetMissionSkillById(int id);
        Task<bool> UpdateMissionSkill(MissionSkill missionSkill);

    }
}
