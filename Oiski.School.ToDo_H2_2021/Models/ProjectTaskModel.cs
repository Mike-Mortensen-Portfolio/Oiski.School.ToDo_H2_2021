using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Models
{
    public class ProjectTaskModel : IMyCompletableModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EntryStatus Status { get; set; }
    }
}