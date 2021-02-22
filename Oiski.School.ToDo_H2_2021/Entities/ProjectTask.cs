using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    /// <summary>
    /// Represents a 'To Do' task <see langword="object"/> that can be completed
    /// </summary>
    internal class ProjectTask : ProjectTaskModel, IMyTask
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="ProjectTask"/> where the name is set
        /// </summary>
        /// <param name="_name"></param>
        public ProjectTask ( string _name )
        {
            ID = taskCount++;
            Name = _name;
            Description = string.Empty;
            Status = EntryStatus.Open;
        }

        /// <summary>
        /// Represents the amount of <see cref="ProjectTask"/> <see langword="objects"/> currently stored (<i>Used to assign ID's</i>)
        /// </summary>
        private static int taskCount = 0;

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

        string IMyTask.IDKey { get; } = "TaskID";

        /// <summary>
        /// Build this <see cref="IMyTask"/> based on the <paramref name="_data"/> provided
        /// </summary>
        /// <param name="_data">The comma seperated <see langword="string"/> <see langword="value"/> that contains the data to build from</param>
        public void BuildEntity ( string _data )
        {
            string[] data = _data.Split (",");

            if ( data.Length != 4 && int.TryParse (data[ 0 ].Replace (( ( IMyTask ) this ).IDKey, string.Empty), out int _id) && int.TryParse (data[ 3 ], out int _status) )
            {
                ID = _id;
                Name = data[ 1 ];
                Description = data[ 2 ];
                Status = ( EntryStatus ) _status;
                return;
            }

            throw new InvalidDataException ($"One or more fields couldn't be retrieved from: {_data}");
        }

        /// <summary>
        /// Save the current state of this <see cref="IMyTask"/>
        /// </summary>
        /// <returns>A comma seperated <see langword="string"/> containing the data for this <see cref="IMyTask"/></returns>
        public string SaveEntity ()
        {
            return $"{( ( IMyTask ) this ).IDKey}{ID},{Name},{Description},{( int ) Status}";
        }
    }
}