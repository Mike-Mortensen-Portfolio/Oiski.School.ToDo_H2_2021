using System;
using System.Collections.Generic;
using System.Text;
using Oiski.Common.Repository;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    /// <summary>
    /// Defines a container that can store <typeparamref name="T"/> <see langword="objects"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMyContainerEntity<T> : IMyRepository<T, string>
    {
        /// <summary>
        /// The collection of <typeparamref name="T"/> <see langword="objects"/> stored in the <see cref="IMyContainerEntity{T}"/>
        /// </summary>
        IReadOnlyList<T> Entries { get; }
    }
}