using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    public interface IMyProject : IMyCompletableModel, IMyContainerEntity<IMyTask>, IMyRepositoryEntity<int, string>
    {
    }
}