using Oiski.Common.Files;
using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    /// <summary>
    /// Represents an <see cref="IMyProject"/> entity that can be completed and can hold <see cref="IMyTask"/> <see langword="objects"/>
    /// </summary>
    internal class Project : ProjectModel, IMyProject
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="Project"/> where the name is set
        /// </summary>
        /// <param name="_name"></param>
        public Project ( string _name )
        {
            ID = projectCount++;
            Name = _name;
            Description = string.Empty;
            Status = EntryStatus.Open;
            Collection = new List<IMyTask> ();
            filePath = $"{Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)}\\Projects\\{ID}.csv";
            file = new FileHandler (filePath);
        }

        /// <summary>
        /// Represents the amount of <see cref="Project"/> <see langword="objects"/> currently stored (<i>Used to assign ID's</i>)
        /// </summary>
        private static int projectCount = 0;
        /// <summary>
        /// The <see cref="FileHandler"/> that manages the <see cref="File"/> that contains info about the <see cref="Project"/> and the collection of <see cref="IMyTask"/> <see langword="objects"/> currently stored
        /// </summary>
        private readonly FileHandler file;
        /// <summary>
        /// The <strong>full path</strong> to the <see cref="File"/> that contains info about the <see cref="Project"/> and the collection of <see cref="IMyTask"/> <see langword="objects"/> currently stored
        /// </summary>
        private readonly string filePath;

        public IReadOnlyList<IMyTask> Entries
        {
            get
            {
                return Collection;
            }
        }

        int IMyCompletableModel.ID
        {
            get
            {
                return ID;
            }
        }

        int IMyRepositoryEntity<int, string>.ID
        {
            get
            {
                return ID;
            }
        }

        string IMyProject.IDKey { get; } = "ProjectID";

        public void BuildEntity ( string _data )
        {
            string[] data = _data.Split ("\n");

            string[] projectData = data[ 0 ].Split (",");

            if ( projectData.Length != 4 && int.TryParse (projectData[ 0 ].Replace (( ( IMyProject ) this ).IDKey, string.Empty), out int _id) && int.TryParse (data[ 3 ], out int _status) )
            {
                ID = _id;
                Name = data[ 1 ];
                Description = data[ 2 ];
                Status = ( EntryStatus ) _status;

                for ( int i = 5; i < data.Length; i++ )
                {
                    IMyTask task = new ProjectTask (string.Empty);
                    task.BuildEntity (data[ i ]);
                    Collection.Add (task);
                }

                return;
            }

            throw new InvalidDataException ($"One or more fields couldn't be retrieved from: {_data}");
        }

        public bool DeleteData<IDType> ( IMyRepositoryEntity<IDType, string> _entity )
        {
            if ( GetDataByIdentifier (_entity.ID) != null )
            {
                file.DeleteLine (file.GetLineNumber (file.FindLine (_entity.ID.ToString ())));
                return true;
            }

            return false;
        }

        public IMyTask GetDataByIdentifier<IDType> ( IDType _id )
        {
            IMyTask task = new ProjectTask (string.Empty);
            string data = file.FindLine ($"{task.IDKey}{Common.Generics.Converter.CastGeneric<IDType, int> (_id)}");

            if ( data != null )
            {
                task.BuildEntity (data);
                return task;
            }

            return null;
        }

        public IEnumerable<IMyTask> GetEnumerable ()
        {
            List<IMyTask> tasks = new List<IMyTask> ();

            foreach ( string data in file.ReadLines () )
            {
                if ( !string.IsNullOrEmpty (data) )
                {
                    IMyTask task = new ProjectTask (string.Empty);
                    task.BuildEntity (data);

                    tasks.Add (task);
                }
            }

            return tasks;
        }

        public bool InsertData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            if ( GetDataByIdentifier (_data.ID) == null )
            {
                file.WriteLine (_data.SaveEntity (), true);

                return true;
            }

            return false;
        }

        public string SaveEntity ()
        {
            file.InsertLine ($"{( ( IMyProject ) this ).IDKey}{ID},{Name},{Description},{( int ) Status}", 0);

            int index = 0;

            foreach ( IMyTask task in Entries )
            {
                file.InsertLine (task.SaveEntity (), index);
                index++;
            }

            return file.ReadAll ();
        }

        public bool UpdateData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            if ( !string.IsNullOrWhiteSpace (file.FindLine ($"{( ( IMyTask ) _data ).IDKey}{_data.ID}")) )
            {
                file.UpdateLine (_data.SaveEntity (), file.GetLineNumber (file.FindLine ($"TaskID{Common.Generics.Converter.CastGeneric<IDType, int> (_data.ID)}")));
                return true;
            }

            return false;
        }
    }
}