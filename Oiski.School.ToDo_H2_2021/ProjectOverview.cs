using Oiski.Common.Files;
using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Oiski.School.ToDo_H2_2021
{
    /// <summary>
    /// Represents a project manager that can maintain and minipulate <see cref="IMyProject"/> <see langword="objects"/>
    /// </summary>
    public class ProjectOverview : IMyContainerEntity<IMyProject>
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="ProjectOverview"/>
        /// </summary>
        private ProjectOverview ()
        {
            projects = new List<IMyProject> ();
            if ( !Directory.Exists (folderPath) )
            {
                projectFolder = Directory.CreateDirectory (folderPath);
            }
            else
            {
                projectFolder = new DirectoryInfo (folderPath);
            }

            projects = GetEnumerable ().ToList ();
        }

        /// <summary>
        /// The folder that contains the <see cref="IMyProject"/> storage files
        /// </summary>
        private readonly DirectoryInfo projectFolder;
        /// <summary>
        /// The full path to the <see cref="projectFolder"/>
        /// </summary>
        private readonly string folderPath = $"{Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)}\\Projects";

        private static ProjectOverview source;
        /// <summary>
        /// The <see cref="ProjectOverview"/> source link
        /// </summary>
        public static ProjectOverview Source
        {
            get
            {
                if ( source == null )
                {
                    source = new ProjectOverview ();
                }

                return source;
            }
        }

        /// <summary>
        /// The collection of <see cref="IMyProject"/> <see langword="objects"/>
        /// </summary>
        private readonly List<IMyProject> projects;
        /// <summary>
        /// A read only collection of <see cref="IMyProject"/> <see langword="objects"/>
        /// </summary>
        public IReadOnlyList<IMyProject> Entries
        {
            get
            {
                return projects;
            }
        }

        public bool DeleteData<IDType> ( IMyRepositoryEntity<IDType, string> _entity )
        {
            IMyProject project = GetDataByIdentifier (_entity.ID);
            if ( project != null )
            {
                FileInfo file = projectFolder.GetFiles ($"{project.ID}").FirstOrDefault ();

                if ( file != null )
                {
                    projects.Remove (projects.Find (item => item.ID == project.ID));
                    file.Delete ();
                    return true;
                }
            }

            return false;
        }

        public IMyProject GetDataByIdentifier<IDType> ( IDType _id )
        {
            IMyProject project = new Project (string.Empty);
            FileInfo fileInfo = projectFolder.GetFiles (Common.Generics.Converter.CastGeneric<IDType, int> (_id).ToString ()).FirstOrDefault ();

            if ( fileInfo != null )
            {
                FileHandler file = new FileHandler (fileInfo.FullName);

                if ( !string.IsNullOrEmpty (file.ReadLines ()[ 0 ]) )
                {
                    project.BuildEntity (file.ReadAll ());
                    return project;
                }
            }

            return null;
        }

        public IEnumerable<IMyProject> GetEnumerable ()
        {
            List<IMyProject> projects = new List<IMyProject> ();

            foreach ( FileInfo data in projectFolder.GetFiles () )
            {
                FileHandler file = new FileHandler (data.FullName);
                if ( !string.IsNullOrEmpty (file.ReadLines ()[ 0 ]) )
                {
                    IMyProject project = new Project (string.Empty);
                    project.BuildEntity (file.ReadAll ());
                }
            }

            return projects;
        }

        public bool InsertData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            if ( GetDataByIdentifier (_data.ID) == null )
            {
                FileHandler file = new FileHandler ($"{folderPath}\\{_data.ID}.csv");
                file.Write (_data.SaveEntity ());

                projects.Add (GetDataByIdentifier (_data.ID));

                return true;
            }

            return false;
        }

        public bool UpdateData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            IMyProject project = GetDataByIdentifier (_data.ID);
            if ( project != null )
            {
                FileHandler file = new FileHandler ($"{folderPath}\\{project.ID}.csv");
                file.Write (_data.SaveEntity ());

                return true;
            }

            return false;
        }
    }
}