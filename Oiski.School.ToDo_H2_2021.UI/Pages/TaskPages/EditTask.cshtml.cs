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
    public class EditTaskModel : PageModel
    {
        [BindProperty]
        public ProjectTaskModel Task { get; private set; }
        public IMyProject Project { get; private set; }

        public IActionResult OnGet ( int? projectID, int? taskID )
        {
            if ( projectID == null && taskID == null )
            {
                return NotFound ();
            }
            Project = ProjectOverview.Source.GetDataByIdentifier (projectID.Value);
            Task = Project?.GetDataByIdentifier (taskID.Value) as ProjectTaskModel;

            if ( Task == null )
            {
                return NotFound ();
            }

            return Page ();
        }

        public IActionResult OnPost ( ProjectTaskModel task, ProjectModel project )
        {
            if ( ModelState.IsValid )
            {
                Project = ProjectOverview.Source.GetDataByIdentifier (project.ID);

                IMyTask updatedTask = ProjectOverview.TaskFactory.CreateTask (task);

                Project.UpdateData (updatedTask);

                return Redirect ($"/ProjectPages/ProjectDetails/{Project.ID}");
            }

            Task = task;

            Project = ProjectOverview.Source.GetDataByIdentifier (project.ID);

            return Page ();
        }
    }
}
