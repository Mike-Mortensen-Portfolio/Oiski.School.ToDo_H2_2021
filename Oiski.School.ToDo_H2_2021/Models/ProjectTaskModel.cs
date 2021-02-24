using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Models
{
    /// <summary>
    /// Defines an open model for a 'To Do' task <see langword="object"/>
    /// </summary>
    public class ProjectTaskModel : IMyCompletableModel
    {
        public int ID { get; set; }
        [Required (ErrorMessage = "A task must have a name!")]
        public string Name { get; set; }
        [MaxLength (93, ErrorMessage = "No more than 93 characters allowed!")]
        public string Description { get; set; }
        public EntryStatus Status { get; set; }
    }
}