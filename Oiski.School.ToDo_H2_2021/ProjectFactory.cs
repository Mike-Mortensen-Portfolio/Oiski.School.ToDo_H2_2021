using Oiski.School.ToDo_H2_2021.Entities;
using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021
{
    /// <summary>
    /// Represents a factory that can create new instances of type <see cref="IMyProject"/> <see langword="objects"/>
    /// </summary>
    public class ProjectFactory
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="ProjectFactory"/>
        /// </summary>
        internal ProjectFactory ()
        {

        }

        /// <summary>
        /// Create a new <see cref="IMyProject"/> with it's default values (<i><strong>Note: </strong> This will not create a <see cref="FileHandler"/> on the <see cref="IMyProject"/></i>)
        /// </summary>
        /// <returns>The newly created <see cref="IMyProject"/> <see langword="object"/></returns>
        public IMyProject CreateDefaultProject ()
        {
            return new Project ();
        }

        /// <summary>
        /// Create a new <see cref="IMyProject"/> where the name is set
        /// </summary>
        /// <param name="_name">The name of the project</param>
        /// <returns>The newly created <see cref="IMyProject"/> <see langword="object"/></returns>
        public IMyProject CreateProject ( string _name )
        {
            return new Project (_name);
        }

        /// <summary>
        /// Create a new <see cref="IMyProject"/> where the name and description are set
        /// </summary>
        /// <param name="_name">The name of the project</param>
        /// <param name="_description">A brief <see langword="string"/> that describes the project</param>
        /// <returns>The newly created <see cref="IMyProject"/> <see langword="object"/></returns>
        public IMyProject CreateProject ( string _name, string _description )
        {
            return new Project (_name)
            {
                Description = _description
            };
        }

        public IMyProject CreateProject ( ProjectModel _model )
        {
            return new Project (_model.ID)
            {
                Collection = _model.Collection,
                Description = _model.Description,
                Name = _model.Name,
                Status = _model.Status
            };
        }
    }
}
