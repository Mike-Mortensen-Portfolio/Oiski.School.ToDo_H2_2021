using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    internal class Project : ProjectModel, IMyProject
    {
        public int ID { get; }
        public IReadOnlyList<IMyTask> Entries { get; }

        public void BuildEntity ( string _data )
        {
            throw new NotImplementedException ();
        }

        public bool DeleteData<IDType> ( IMyRepositoryEntity<IDType, string> _entity )
        {
            throw new NotImplementedException ();
        }

        public IMyTask GetDataByIdentifier<IDType> ( IDType _id )
        {
            throw new NotImplementedException ();
        }

        public IEnumerable<IMyTask> GetEnumerable ()
        {
            throw new NotImplementedException ();
        }

        public bool InsertData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            throw new NotImplementedException ();
        }

        public string SaveEntity ()
        {
            throw new NotImplementedException ();
        }

        public bool UpdateData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            throw new NotImplementedException ();
        }
    }
}