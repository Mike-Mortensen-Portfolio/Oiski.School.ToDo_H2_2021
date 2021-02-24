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
    public class CreateProjectModel : PageModel
    {
        /// <summary>
        /// The model containing the values for the <see cref="IMyProject"/> <see langword="object"/>
        /// </summary>
        public ProjectModel Project { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project">The model containing the values used to create a new <see cref="IMyProject"/></param> <see  langword="object"/>
        /// <returns>The result of the Post Request</returns>
        public IActionResult OnPost ( ProjectModel project )
        {
            if ( ModelState.IsValid )
            {
                IMyProject newProject = ProjectOverview.ProjectFactory.CreateProject (project.Name);
                newProject.Description = project.Description;

                ProjectOverview.Source.InsertData (newProject);

                return Redirect ($"/ProjectPages/ProjectDetails/{newProject.ID}");
            }

            Project = project;

            return Page ();
        }
    }
}
