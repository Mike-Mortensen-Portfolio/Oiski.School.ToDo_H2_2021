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
    public class CreateTaskModel : PageModel
    {
        public ProjectTaskModel Task { get; private set; }

        public IMyProject Project { get; private set; }

        public IActionResult OnGet ( int? id )
        {
            if ( id == null )
            {
                return NotFound ();
            }

            Project = ProjectOverview.Source.GetDataByIdentifier (id.Value);

            if ( Project == null )
            {
                return NotFound ();
            }

            return Page ();
        }

        public IActionResult OnPost ( ProjectTaskModel task, ProjectModel project )
        {
            if ( ModelState.IsValid )
            {
                IMyTask newTask = ProjectOverview.TaskFactory.CreateTask (task.Name, task.Description);

                ProjectOverview.Source.GetDataByIdentifier (project.ID).InsertData (newTask);

                return Redirect ($"/ProjectPages/ProjectDetails/{project.ID}");
            }

            Task = task;

            Project = ProjectOverview.Source.GetDataByIdentifier (project.ID);

            return Page ();
        }
    }
}
