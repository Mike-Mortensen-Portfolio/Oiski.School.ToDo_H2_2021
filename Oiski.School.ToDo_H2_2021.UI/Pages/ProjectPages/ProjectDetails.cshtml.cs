using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.ToDo_H2_2021.Entities;

namespace Oiski.School.ToDo_H2_2021.UI.Pages
{
    public class ProjectDetailsModel : PageModel
    {
        /// <summary>
        /// Contains the <see cref="IMyProject"/> <see langword="object"/> to display on the page
        /// </summary>
        public IMyProject Project { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The ID that indentifies the <see cref="IMyProject"/> <see langword="object"/> to display</param>
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
    }
}
