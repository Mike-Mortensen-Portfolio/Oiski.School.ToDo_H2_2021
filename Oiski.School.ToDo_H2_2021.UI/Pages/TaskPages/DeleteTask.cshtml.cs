using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.ToDo_H2_2021.Entities;
using Oiski.School.ToDo_H2_2021.Models;

namespace Oiski.School.ToDo_H2_2021.UI.Pages.TaskPages
{
    public class DeleteTaskModel : PageModel
    {
        public ProjectTaskModel Task { get; private set; }
        public IMyProject Project { get; private set; }
        public string Name { get; private set; }

        public IActionResult OnGet ( int? projectID, int? taskID )
        {
            if ( projectID == null || taskID == null )
            {
                return NotFound ();
            }

            Project = ProjectOverview.Source.GetDataByIdentifier (projectID.Value);
            IMyTask task = Project?.GetDataByIdentifier (taskID.Value);

            Task = new ProjectTaskModel ();
            Name = task.Name;
            Task.ID = task.ID;

            if ( Task == null )
            {
                return NotFound ();
            }

            return Page ();
        }

        public IActionResult OnPost ( ProjectModel project, ProjectTaskModel task )
        {
            Project = ProjectOverview.Source.GetDataByIdentifier (project.ID);
            IMyTask taskToDelete = Project?.GetDataByIdentifier (task.ID);

            if ( taskToDelete != null && task.Name == taskToDelete.Name )
            {
                Project.DeleteData (taskToDelete);
                return Redirect ($"/ProjectPages/ProjectDetails/{Project.ID}");
            }

            Project = ProjectOverview.Source.GetDataByIdentifier (project.ID);

            Name = taskToDelete.Name;
            task.Name = null;
            Task = task;

            return Page ();
        }
    }
}
