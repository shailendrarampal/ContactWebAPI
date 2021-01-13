using ContactWebAPI.DBOperation;
using ContactWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ContactWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        [Authorize()]
        // GET: api/Skills
        [HttpGet]
        public IEnumerable<SkillsEntity> Get()
        {
            return SkillsDB.GetAllSkills();
        }

        [Authorize()]
        // GET: api/Skills/java
        [HttpGet("{skill}", Name = "Get")]
        public ActionResult<SkillsEntity> Get(string skill)
        {
            return SkillsDB.GetSkillByName(skill);
        }

        [Authorize()]
        // POST: api/Skills
        [HttpPost]
        public ActionResult<string> Post([FromBody] SkillsEntity skills)
        {
            if (!ModelState.IsValid)
                return JsonConvert.SerializeObject(
                    ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList(), Formatting.Indented);
            skills.SkillId = new Guid();
            SkillsDB.CreateSkills(skills);
            return "Save Successfully";
        }

        [Authorize()]
        // PUT: api/Skills/c
        [HttpPut("{id}")]
        public ActionResult<string> Put(string skill, [FromBody] SkillsEntity skills)
        {
            if (!ModelState.IsValid)
                return JsonConvert.SerializeObject(
                    ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList(), Formatting.Indented);
            return SkillsDB.UpdateSkillsBySkillName(skill, skills);
        }

        [Authorize()]
        // DELETE: api/Delete/java
        [HttpDelete("{skill}")]
        public ActionResult<string> Delete(string skill)
        {
            return SkillsDB.DeleteSkillByName(skill);
        }
    }
}
