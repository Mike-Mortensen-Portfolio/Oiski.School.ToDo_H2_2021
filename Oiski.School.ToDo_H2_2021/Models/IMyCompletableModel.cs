using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Models
{
    public interface IMyCompletableModel
    {
        string Name { get; set; }
        string Description { get; set; }
        EntryStatus Status { get; set; }
    }
}