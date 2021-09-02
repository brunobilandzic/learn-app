using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class LearningTaskDto : LearningTaskMinDto
    {
        
        public List<LectureLearningTaskDto> Lectures { get; set; }
    }
}