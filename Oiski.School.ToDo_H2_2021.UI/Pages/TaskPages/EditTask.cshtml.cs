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
        /// <summary>
        /// The project model containing the values of the <see cref="IMyTask"/> to be edited
        /// </summary>
        [BindProperty]
        public ProjectTaskModel Task { get; private set; }
        /// <summary>
        /// The project containing the <see cref="IMyTask"/> to edit
        /// </summary>
        public IMyProject Project { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID">The ID that identifies the <see cref="IMyProject"/> <see langword="object"/> that contains the <see cref="IMyTask"/> to edit</param>
        /// <param name="taskID">The ID that identifies the <see cref="IMyTask"/> <see langword="object"/> to edit</param>
        /// <returns>The result of the Get Request</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task">The model containing the updated values for the edited <see cref="IMyTask"/></param>
        /// <param name="project">The model containing the ID to identify the <see cref="IMyProject"/> containing the <see cref="IMyTask"/> to edit</param>
        /// <returns>The result of the Post Request</returns>
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
