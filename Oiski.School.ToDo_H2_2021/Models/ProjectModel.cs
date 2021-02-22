using Oiski.School.ToDo_H2_2021.Entities;
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public EntryStatus Status { get; set; }
    }
}