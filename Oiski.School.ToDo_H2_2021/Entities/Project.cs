using Oiski.Common.Files;
using Oiski.Common.Generics;
using Oiski.Common.Repository;
using Oiski.School.ToDo_H2_2021.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Entities
{
    /// <summary>
    /// Represents an <see cref="IMyProject"/> entity that can be completed and can hold <see cref="IMyTask"/> <see langword="objects"/>
    /// </summary>
    internal class Project : ProjectModel, IMyProject
    {
        internal Project()
        {
            ID = projectCount++;
            Name = string.Empty;
            Description = string.Empty;
            Status = EntryStatus.Open;

            Collection = new List<IMyTask>();
        }

        public Project(int _id) : this()
        {
            ID = _id;
        }

        /// <summary>
        /// Initialize a new instance of type <see cref="Project"/> where the name is set
        /// </summary>
        /// <param name="_name"></param>
        public Project(string _name) : this()
        {
            Name = _name;
            filePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Projects\\{ID}.csv";
            file = new FileHandler(filePath);
        }

        /// <summary>
        /// Represents the amount of <see cref="Project"/> <see langword="objects"/> currently stored (<i>Used to assign ID's</i>)
        /// </summary>
        private static int projectCount = 0;
        /// <summary>
        /// The <see cref="FileHandler"/> that manages the <see cref="File"/> that contains info about the <see cref="Project"/> and the collection of <see cref="IMyTask"/> <see langword="objects"/> currently stored
        /// </summary>
        private FileHandler file;
        /// <summary>
        /// The <strong>full path</strong> to the <see cref="File"/> that contains info about the <see cref="Project"/> and the collection of <see cref="IMyTask"/> <see langword="objects"/> currently stored
        /// </summary>
        private string filePath;

        public IReadOnlyList<IMyTask> Entries
        {
            get
            {
                return Collection;
            }
        }

        public new int ID
        {
            get
            {
                return base.ID;
            }

            private set
            {
                base.ID = value;
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

        public void BuildEntity(string _data)
        {
            string[] data = _data.Split($"{Environment.NewLine}");

            string[] projectData = data[0].Split(",");

            if (projectData.Length == 4 && int.TryParse(projectData[0].Replace(((IMyProject)this).IDKey, string.Empty), out int _id) && int.TryParse(projectData[3], out int _status))
            {
                ID = _id;
                Name = projectData[1];
                Description = projectData[2];
                Status = (EntryStatus)_status;

                filePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Projects\\{ID}.csv";
                file = new FileHandler(filePath);

                for (int i = 1; i < data.Length - 1; i++)
                {
                    IMyTask task = ProjectOverview.TaskFactory.CreateDefaultTask();
                    if (!string.IsNullOrEmpty(data[i]))
                    {
                        task.BuildEntity(data[i]);
                        Collection.Add(task);
                    }
                }

                return;
            }

            throw new InvalidDataException($"One or more fields couldn't be retrieved from: {_data}");
        }

        public bool DeleteData<IDType>(IMyRepositoryEntity<IDType, string> _entity)
        {
            if (GetDataByIdentifier(_entity.ID) != null)
            {
                file.DeleteLine(file.GetLineNumber(file.FindLine($"{((IMyTask)_entity).IDKey}{_entity.ID}")));
                Collection.Remove(Collection.Find(item => item.ID == Common.Generics.Converter.CastGeneric<IDType, int>(_entity.ID)));
                return true;
            }

            return false;
        }

        public IMyTask GetDataByIdentifier<IDType>(IDType _id)
        {
            IMyTask task = ProjectOverview.TaskFactory.CreateDefaultTask();
            string data = file.FindLine($"{task.IDKey}{Common.Generics.Converter.CastGeneric<IDType, int>(_id)}");

            if (data != null)
            {
                task.BuildEntity(data);
                return task;
            }

            return null;
        }

        public IEnumerable<IMyTask> GetEnumerable()
        {
            List<IMyTask> tasks = new List<IMyTask>();

            string[] lines = file.ReadLines();
            for (int i = 1; i < lines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(lines[i]))
                {
                    IMyTask task = ProjectOverview.TaskFactory.CreateDefaultTask();
                    task.BuildEntity(lines[i]);

                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public bool InsertData<IDType>(IMyRepositoryEntity<IDType, string> _data)
        {
            if (GetDataByIdentifier(_data.ID) == null)
            {
                file.WriteLine(_data.SaveEntity(), true);
                IMyTask task = GetDataByIdentifier(_data.ID);
                Collection.Add(task);

                return true;
            }

            return false;
        }

        public string SaveEntity()
        {
            file.InsertLine($"{((IMyProject)this).IDKey}{ID},{Name},{Description},{(int)Status}", 0);

            int index = 1;

            foreach (IMyTask task in Entries)
            {
                file.InsertLine(task.SaveEntity(), index);
                index++;
            }

            return file.ReadAll();
        }

        public bool UpdateData<IDType>(IMyRepositoryEntity<IDType, string> _data)
        {
            if (!string.IsNullOrWhiteSpace(file.FindLine($"{((IMyTask)_data).IDKey}{_data.ID}")))
            {
                file.UpdateLine(_data.SaveEntity(), file.GetLineNumber(file.FindLine($"TaskID{Common.Generics.Converter.CastGeneric<IDType, int>(_data.ID)}")));

                IMyTask task = GetDataByIdentifier(_data.ID);

                Collection[Collection.IndexOf(Collection.Find(item => item.ID == task.ID))] = task;
                return true;
            }

            return false;
        }
    }
}