﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkforceManagement.DTO.Models
{
    public class SkillDto
    {
        public int SkillId { get; set; }

        public int EmployeeId { get; set; }

        public string SkillName { get; set; }

        public string SkillKnowledge { get; set; }
    }

    public class SkillConfig
    {
        public string Count { get; set; }
    }
}
