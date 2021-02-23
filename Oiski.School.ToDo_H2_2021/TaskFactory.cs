using Oiski.School.ToDo_H2_2021.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Oiski.School.ToDo_H2_2021.Models;

namespace Oiski.School.ToDo_H2_2021
{
    public class TaskFactory
    {
        internal TaskFactory ()
        {

        }

        /// <summary>
        /// Create a new <see cref="IMyTask"/> with it's default values
        /// </summary>
        /// <returns>The newly created <see cref="IMyTask"/> <see langword="object"/></returns>
        public IMyTask CreateDefaultTask ()
        {
            return new ProjectTask (string.Empty);
        }

        /// <summary>
        /// Create a new <see cref="IMyTask"/> where the name is set
        /// </summary>
        /// <param name="_name">The name of the task</param>
        /// <returns>The newly created <see cref="IMyTask"/> <see langword="object"/></returns>
        public IMyTask CreateTask ( string _name )
        {
            return new ProjectTask (_name);
        }

        /// <summary>
        /// Create a new <see cref="IMyTask"/> where the name and description are set
        /// </summary>
        /// <param name="_name">The name of the task</param>
        /// <param name="_description">A brief <see langword="string"/> that describes the task</param>
        /// <returns>The newly created <see cref="IMyTask"/> <see langword="object"/></returns>
        public IMyTask CreateTask ( string _name, string _description )
        {
            return new ProjectTask (_name)
            {
                Description = _description
            };
        }

        public IMyTask CreateTask ( ProjectTaskModel _model )
        {
            return new ProjectTask (_model.ID)
            {
                Description = _model.Description,
                Name = _model.Name,
                Status = _model.Status
            };
        }
    }
}
