using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    /// <summary>
    /// Represents a 'To Do' task <see langword="object"/> that can be completed
    /// </summary>
    internal class ProjectTask : ProjectTaskModel, IMyTask
    {
        /// <summary>
        /// Build this <see cref="IMyTask"/> based on the <paramref name="_data"/> provided
        /// </summary>
        /// <param name="_data">The comma seperated <see langword="string"/> <see langword="value"/> that contains the data to build from</param>
        public void BuildEntity ( string _data )
        {
            string[] data = _data.Split (",");

            if ( int.TryParse (data[ 0 ].Replace ("TaskID", string.Empty), out int _id) && int.TryParse (data[ 3 ], out int _status) )
            {
                ID = _id;
                Name = data[ 1 ];
                Description = data[ 2 ];
                Status = ( EntryStatus ) _status;
            }
        }

        /// <summary>
        /// Save the current state of this <see cref="IMyTask"/>
        /// </summary>
        /// <returns>A comma seperated <see langword="string"/> containing the data for this <see cref="IMyTask"/></returns>
        public string SaveEntity ()
        {
            return $"TaskID{ID},{Name},{Description},{( int ) Status}";
        }
    }
}