using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021
{
    public class ProjectOverview : IMyContainerEntity<IMyProject>
    {
        private ProjectOverview ()
        {

        }

        private static ProjectOverview source;
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

        private List<IMyProject> projects;
        public IReadOnlyList<IMyProject> Entries
        {
            get
            {
                return projects;
            }
        }

        public bool DeleteData<IDType> ( IMyRepositoryEntity<IDType, string> _entity )
        {
            throw new NotImplementedException ();
        }

        public IMyProject GetDataByIdentifier<IDType> ( IDType _id )
        {
            throw new NotImplementedException ();
        }

        public IEnumerable<IMyProject> GetEnumerable ()
        {
            throw new NotImplementedException ();
        }

        public bool InsertData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            throw new NotImplementedException ();
        }

        public bool UpdateData<IDType> ( IMyRepositoryEntity<IDType, string> _data )
        {
            throw new NotImplementedException ();
        }
    }
}