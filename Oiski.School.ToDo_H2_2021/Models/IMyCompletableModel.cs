using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Models
{
    /// <summary>
    /// Defines an open model for completable <see langword="objects"/>
    /// </summary>
    public interface IMyCompletableModel
    {
        int ID { get; }
        string Name { get; set; }
        string Description { get; set; }
        EntryStatus Status { get; set; }
    }
}