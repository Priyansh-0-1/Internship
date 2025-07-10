using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Mission.Entities.context;
using Mission.Entities.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.Repositories
{
    public class MissionSkillRepository(MissionDbContext missionDbContext) : IMissionSkillRepository
    {
        private readonly MissionDbContext _missionDbContext = missionDbContext;

        public async Task<bool> AddMissionSkill(MissionSkill missionSkill)
        {
            bool alreadyExist = await _missionDbContext.MissionSkill
                .AnyAsync(m => m.SkillName.ToLower() == missionSkill.SkillName.ToLower() && !m.IsDeleted);

            if (alreadyExist)
            {
                return false;
            }

            await _missionDbContext.MissionSkill.AddAsync(missionSkill);
            await _missionDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionSkill(int id)
        {
            var missionSkill = await _missionDbContext.MissionSkill
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);

            if (missionSkill == null)
            {
                return false;
            }

            missionSkill.IsDeleted = true;
            missionSkill.ModifiedDate = DateTime.UtcNow;

            await _missionDbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<MissionSkillModel>> GetAllMissionSkill()
        {
            return _missionDbContext.MissionSkill
                .Where(m => !m.IsDeleted)
                .Select(m => new MissionSkillModel
                {
                    Id = m.Id,
                    SkillName = m.SkillName,
                    Status = m.Status
                }).ToListAsync();
        }

        public Task<MissionSkillModel?> GetMissionSkillById(int id)
        {
            return _missionDbContext.MissionSkill
                .Where(m => m.Id == id && !m.IsDeleted)
                .Select(m => new MissionSkillModel
                {
                    Id = m.Id,
                    SkillName = m.SkillName,
                    Status = m.Status
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMissionSkill(MissionSkill missionSkill)
        {
            var skillExist = await _missionDbContext.MissionSkill
                .FirstOrDefaultAsync(m => m.Id == missionSkill.Id && !m.IsDeleted);

            if (skillExist == null)
            {
                return false;
            }

            skillExist.SkillName = missionSkill.SkillName;
            skillExist.Status = missionSkill.Status;
            skillExist.ModifiedDate = DateTime.UtcNow;

            await _missionDbContext.SaveChangesAsync();
            return true;
        }
    }
}
