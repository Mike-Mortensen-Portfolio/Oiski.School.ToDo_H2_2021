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
    public class EditProjectModel : PageModel
    {
        /// <summary>
        /// The model containing the values of the <see cref="IMyProject"/> to edit
        /// </summary>
        [BindProperty]
        public ProjectModel Project { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The ID used to identify the <see cref="IMyProject"/> to edit</param>
        /// <returns>The result of the Get Request</returns>
        public IActionResult OnGet ( int? id )
        {
            if ( id == null )
            {
                return NotFound ();
            }

            Project = ProjectOverview.Source.GetDataByIdentifier (id.Value) as ProjectModel;

            if ( Project == null )
            {
                return NotFound ();
            }

            return Page ();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project">The <see cref="ProjectModel"/> that contains the changed values of the <see cref="IMyProject"/> <see langword="object"/> that was edited</param>
        /// <returns></returns>
        public IActionResult OnPost ( ProjectModel project )
        {
            if ( ModelState.IsValid )
            {
                IMyProject Project = ProjectOverview.Source.GetDataByIdentifier (project.ID);
                Project.Name = project.Name;
                Project.Description = project.Description;
                Project.Status = project.Status;

                ProjectOverview.Source.UpdateData (Project);

                return Redirect ($"/ProjectPages/ProjectDetails/{Project.ID}");
            }

            Project = ProjectOverview.Source.GetDataByIdentifier (project.ID) as ProjectModel;

            return Page ();
        }
    }
}
