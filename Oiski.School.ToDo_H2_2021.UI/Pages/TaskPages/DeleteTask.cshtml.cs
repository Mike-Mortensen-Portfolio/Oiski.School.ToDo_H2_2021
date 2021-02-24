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
        /// <summary>
        /// The model containing the values to identify the <see cref="IMyTask"/> <see langword="object"/> to be deleted
        /// </summary>
        public ProjectTaskModel Task { get; private set; }
        /// <summary>
        /// The <see cref="IMyProject"/> that contains the <see cref="IMyTask"/> that should be deleted
        /// </summary>
        public IMyProject Project { get; private set; }
        /// <summary>
        /// The validation <see langword="string"/> <see langword="value"/> to compare against the <see cref="ProjectTaskModel"/>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID">The ID of the <see cref="IMyProject"/> that contains the <see cref="IMyTask"/> that should be deleted</param>
        /// <param name="taskID">The ID of the <see cref="IMyTask"/> that should be deleted</param>
        /// <returns>The result of the Get Request</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project">The model containing the name and ID of the <see cref="IMyProject"/> containing the <see cref="IMyTask"/> that should be deleted</param>
        /// <param name="task">The model that contains the ID and name of the <see cref="IMyTask"/> that should be deleted</param>
        /// <returns>The result of the Post Request</returns>
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
