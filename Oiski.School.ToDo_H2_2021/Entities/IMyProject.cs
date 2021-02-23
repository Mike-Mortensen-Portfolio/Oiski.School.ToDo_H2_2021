using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    /// <summary>
    /// Represents a project <see langword="object"/> that can store <see cref="IMyTask"/> <see langword="objects"/>
    /// </summary>
    public interface IMyProject : IMyCompletableModel, IMyContainerEntity<IMyTask>, IMyRepositoryEntity<int, string>
    {
        new int ID { get; }

        /// <summary>
        /// The <i>key</i> that identifies the <see cref="ID"/> when calling <see cref="IMyRepositoryEntity{IDType, SaveType}.SaveEntity"/> and/or <see cref="IMyRepositoryEntity{IDType, SaveType}.BuildEntity(SaveType)"/>
        /// </summary>
        internal string IDKey { get; }
    }
}