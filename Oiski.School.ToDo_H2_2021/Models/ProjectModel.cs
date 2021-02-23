using Microsoft.AspNetCore.Mvc;
using Oiski.School.ToDo_H2_2021.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Models
{
    /// <summary>
    /// Represents an open model that can hold data on a project <see langword="object"/>
    /// </summary>
    public class ProjectModel : IMyChangableCollectionModel<IMyTask>, IMyCompletableModel
    {
        public int ID { get; set; }
        public List<IMyTask> Collection { get; set; }
        [Required (ErrorMessage = "A project must have a name!")]
        public string Name { get; set; }
        [MaxLength (200, ErrorMessage = "No more than 200 characters allowed!")]
        public string Description { get; set; }
        public EntryStatus Status { get; set; }
    }
}