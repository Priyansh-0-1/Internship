using Mission.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mission.Services.IServices
{
    public interface IMissionSkillService
    {
        Task<bool> AddMissionSkill(MissionSkillModel model);
        Task<List<MissionSkillModel>> GetAllMissionSkills();
        Task<MissionSkillModel?> GetMissionSkillById(int id);
        Task<bool> UpdateMissionSkill(MissionSkillModel model);
        Task<bool> DeleteMissionSkill(int id);
    }
}
