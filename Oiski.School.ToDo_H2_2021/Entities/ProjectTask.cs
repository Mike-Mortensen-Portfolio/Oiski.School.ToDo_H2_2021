using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    internal class ProjectTask : ProjectTaskModel, IMyTask
    {
        public int ID { get; }

        public void BuildEntity ( string _data )
        {
            throw new NotImplementedException ();
        }

        public string SaveEntity ()
        {
            throw new NotImplementedException ();
        }
    }
}