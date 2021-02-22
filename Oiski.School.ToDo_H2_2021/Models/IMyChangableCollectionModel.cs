using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.School.ToDo_H2_2021.Models
{
    /// <summary>
    /// Represents an open model with a changeable <typeparamref name="T"/> collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMyChangableCollectionModel<T>
    {
        int ID { get; }
        /// <summary>
        /// The swapable collection of <typeparamref name="T"/> <see langword="objects"/>
        /// </summary>
        List<T> Collection { get; set; }
    }
}