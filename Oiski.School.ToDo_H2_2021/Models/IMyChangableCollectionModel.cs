using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Models
{
    public interface IMyChangableCollectionModel<T>
    {
        int ID { get; }
        List<T> Collection { get; set; }
    }
}