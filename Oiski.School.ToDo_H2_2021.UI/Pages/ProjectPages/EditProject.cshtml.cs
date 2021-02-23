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
        [BindProperty]
        public ProjectModel Project { get; private set; }

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
