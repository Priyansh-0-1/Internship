using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mission.Services.Services
{
    public class MissionSkillService(IMissionSkillRepository missionSkillRepository) : IMissionSkillService
    {
        private readonly IMissionSkillRepository _missionSkillRepository = missionSkillRepository;

        public Task<bool> AddMissionSkill(MissionSkillModel model)
        {
            MissionSkill missionSkill = new MissionSkill()
            {
                Id = model.Id,
                SkillName = model.SkillName,
                Status = model.Status
            };
            return _missionSkillRepository.AddMissionSkill(missionSkill);
        }

        public Task<List<MissionSkillModel>> GetAllMissionSkills()
        {
            return _missionSkillRepository.GetAllMissionSkill();
        }

        public Task<MissionSkillModel?> GetMissionSkillById(int id)
        {
            return _missionSkillRepository.GetMissionSkillById(id);
        }

        public Task<bool> UpdateMissionSkill(MissionSkillModel model)
        {
            MissionSkill missionSkill = new MissionSkill()
            {
                Id = model.Id,
                SkillName = model.SkillName,
                Status = model.Status
            };
            return _missionSkillRepository.UpdateMissionSkill(missionSkill);
        }

        public async Task<bool> DeleteMissionSkill(int id)
        {
            return await _missionSkillRepository.DeleteMissionSkill(id);
        }
    }
}
