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
        /// <summary>
        /// The model containing the values to build a new <see cref="IMyTask"/> from
        /// </summary>
        public ProjectTaskModel Task { get; private set; }

        /// <summary>
        /// The <see cref="IMyProject"/> to add the <see cref="IMyTasks"/> to
        /// </summary>
        public IMyProject Project { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The ID of the <see cref="IMyProject"/> to add the <see cref="IMyTask"/> to</param>
        /// <returns>The result of the Get Request</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task">The model that contains the values to build an <see cref="IMyTask"/> <see langword="object"/> from</param>
        /// <param name="project">The model containing the ID and name of the <see cref="IMyProject"/> the <see cref="IMyTask"/> should be added to</param>
        /// <returns>The result of the Post Request</returns>
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
