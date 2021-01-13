using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebAPI.Entities;

namespace ContactWebAPI.DBOperation
{
    public class SkillsDB
    {
        static List<SkillsEntity> _skills = new List<SkillsEntity>();
        public static List<SkillsEntity> GetAllSkills() => _skills;
        public static SkillsEntity GetSkillByName(string name) =>
            _skills.FirstOrDefault(m => m.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
        public static void CreateSkills(SkillsEntity skills) => _skills.Add(skills);
        public static string UpdateSkillsBySkillName(string skill, SkillsEntity skills)
        {
            var detailIndex = _skills.FindIndex(x => x.Name.Equals(skill,StringComparison.OrdinalIgnoreCase));
            if (detailIndex > -1)
            {
                _skills[detailIndex] = skills;
                return "Skills Updated Successfully";
            }
            else
            {
                return $"Unable to find the detail for Mobile Number:{skill} to Edit";
            }
        }
        public static string DeleteSkillByName(string name)
        {
            var detailIndex = _skills.FindIndex(x => x.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
            if (detailIndex > -1)
            {
                _skills.RemoveAt(detailIndex);
                return "Skill Deleted Successfully";
            }
            else
                return $"Unable to find the detail for Skill:{name} to Delete";
        }
    }
}
