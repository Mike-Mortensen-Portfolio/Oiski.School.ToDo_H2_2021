using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oiski.School.ToDo_H2_2021.Entities;

namespace Oiski.School.ToDo_H2_2021.UI.Pages
{
    public class ProjectsModel : PageModel
    {
        public List<IMyProject> Projects { get; private set; }

        public void OnGet ()
        {
            Projects = ProjectOverview.Source.GetEnumerable ().ToList ();
        }
    }
}
