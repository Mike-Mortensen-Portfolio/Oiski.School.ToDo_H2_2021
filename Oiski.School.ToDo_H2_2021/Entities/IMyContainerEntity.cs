using System;
using System.Collections.Generic;
using System.Text;
using Oiski.Common.Repository;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    public interface IMyContainerEntity<T> : IMyRepository<T, string>
    {
        IReadOnlyList<T> Entries { get; }
    }
}