using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.Models;
using Mission.Services.IServices;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController(IMissionSkillService missionSkillService) : ControllerBase
    {
        private readonly IMissionSkillService _missionSkillService = missionSkillService;

        [HttpPost]
        [Route("AddMissionSkill")]
        public async Task<IActionResult> AddMissionSkill(MissionSkillModel model)
        {
            try
            {
                var res = await _missionSkillService.AddMissionSkill(model);
                if (res == true)
                {
                    return Ok(new ResponseResult() { Data = "Mission skill added.", Result = ResponseStatus.Success, Message = "" });
                }
                else
                {
                    return Ok(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Skill already exists" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to add skill" });
            }
        }

        [HttpGet]
        [Route("GetMissionSkillList")]
        public async Task<IActionResult> GetAllMissionSkills()
        {
            try
            {
                var res = await _missionSkillService.GetAllMissionSkills();
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to get skill list" });
            }
        }

        [HttpGet]
        [Route("GetMissionSkillById/{id}")]
        public async Task<IActionResult> GetMissionSkillById(int id)
        {
            var res = await _missionSkillService.GetMissionSkillById(id);
            if (res == null)
                return NotFound(new ResponseResult() { Data = "Not found", Result = ResponseStatus.Error, Message = "" });

            return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpPost]
        [Route("UpdateMissionSkill")]
        public async Task<IActionResult> UpdateMissionSkill(MissionSkillModel model)
        {
            var res = await _missionSkillService.UpdateMissionSkill(model);
            if (!res)
                return NotFound(new ResponseResult() { Data = "Not found", Result = ResponseStatus.Error, Message = "" });

            return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "Updated successfully" });
        }

        [HttpDelete]
        [Route("DeleteMissionSkill/{id}")]
        public async Task<IActionResult> DeleteMissionSkill(int id)
        {
            try
            {
                var res = await _missionSkillService.DeleteMissionSkill(id);
                if (!res)
                    return NotFound(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Skill not found or couldn't be deleted" });

                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "Skill deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Error deleting skill" });
            }
        }
    }
}
