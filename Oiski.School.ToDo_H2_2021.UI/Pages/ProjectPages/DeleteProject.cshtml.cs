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
        public ProjectModel Project { get; private set; }
        public string Name { get; private set; }

        public IActionResult OnGet ( int? id )
        {
            if ( id == null )
            {
                return NotFound ();
            }

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

        public IActionResult OnPost ( ProjectModel project )
        {
            IMyProject projectToDelete = ProjectOverview.Source.GetDataByIdentifier (project.ID);

            if ( project.Name == projectToDelete.Name )
            {
                ProjectOverview.Source.DeleteData (projectToDelete);
                return Redirect ($"/ProjectPages/Projects");
            }

            
            Name = projectToDelete.Name;
            project.Name = null;
            Project = project;

            return Page ();
        }
    }
}
