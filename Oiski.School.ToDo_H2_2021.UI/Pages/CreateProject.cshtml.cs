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
        public ProjectModel Project { get; private set; }
        public void OnGet ()
        {
        }
        public IActionResult OnPost ( ProjectModel project )
        {
            if ( ModelState.IsValid )
            {
                IMyProject newProject = ProjectOverview.ProjectFactory.CreateProject (project.Name);
                newProject.Description = project.Description;

                ProjectOverview.Source.InsertData (newProject);

                return Redirect ($"/ProjectDetails/{newProject.ID}");
            }

            Project = project;

            return Page ();
        }
    }
}
