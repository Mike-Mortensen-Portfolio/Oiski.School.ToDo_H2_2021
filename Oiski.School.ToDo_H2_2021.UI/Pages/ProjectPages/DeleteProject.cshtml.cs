using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.ToDo_H2_2021.Entities;
using Oiski.School.ToDo_H2_2021.Models;

namespace Oiski.School.ToDo_H2_2021.UI.Pages
{
    public class DeleteProjectModel : PageModel
    {
        /// <summary>
        /// The model conatining the name and ID for the <see cref="IMyProject"/> <see langword="object"/> that is about ot be deleted
        /// </summary>
        public ProjectModel Project { get; private set; }
        /// <summary>
        /// The validation <see langword="string"/> <see langword="value"/> to compare against the <see cref="ProjectModel.Name"/>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The ID that identifies the <see cref="IMyProject"/> that should be deleted</param>
        /// <returns>THe result of the Get Request</returns>
        public IActionResult OnGet ( int? id )
        {
            if ( id == null )
            {
                return NotFound ();
            }

            /*
                Setting the values of the ProjectModel. (Only Name and ID are required)
             */
            Project = new ProjectModel ();
            IMyProject project = ProjectOverview.Source.GetDataByIdentifier (id.Value);
            Name = project.Name;
            Project.ID = project.ID;

            if ( Project == null )
            {
                return NotFound ();
            }

            return Page ();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project">The <see cref="ProjectModel"/> containing the name and the ID to identify the <see cref="IMyProject"/> <see langword="object"/> to delete</param>
        /// <returns>THe result of the Post Request</returns>
        public IActionResult OnPost ( ProjectModel project )
        {
            IMyProject projectToDelete = ProjectOverview.Source.GetDataByIdentifier (project.ID);

            /*
                Ensuring that the name of the project and the project model are equal -> Then deleting the entity
             */
            if ( project.Name == projectToDelete.Name )
            {
                ProjectOverview.Source.DeleteData (projectToDelete);
                return Redirect ($"/ProjectPages/Projects");
            }

            /*
                Resettting the values so the ensure that they are set before attempting to render the page
             */
            Name = projectToDelete.Name;
            project.Name = null;
            Project = project;

            return Page ();
        }
    }
}
