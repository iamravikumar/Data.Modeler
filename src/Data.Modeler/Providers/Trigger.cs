﻿/*
Copyright 2017 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Data.Modeler.Providers.Enums;
using Data.Modeler.Providers.Interfaces;
using System;

namespace Data.Modeler.Providers
{
    /// <summary>
    /// Trigger class
    /// </summary>
    public class Trigger : ITrigger
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="definition">Definition</param>
        /// <param name="type">Type</param>
        /// <param name="parentTable">Parent table</param>
        public Trigger(string name, string definition, TriggerType type, ITable parentTable)
        {
            Name = name;
            Definition = definition;
            Type = type;
            ParentTable = parentTable;
        }

        /// <summary>
        /// Definition of the trigger
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Name of the trigger
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parent table
        /// </summary>
        public ITable ParentTable { get; set; }

        /// <summary>
        /// Trigger type
        /// </summary>
        public TriggerType Type { get; set; }

        /// <summary>
        /// Copies this instance
        /// </summary>
        /// <param name="parentTable">The new parent table.</param>
        /// <returns>The copy</returns>
        public ITrigger Copy(ITable parentTable) => new Trigger(Name, Definition, Type, parentTable);

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is Trigger Item)
                && Definition == Item.Definition
                && Name == Item.Name
                && Type == Item.Type;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data
        /// structures like a hash table.
        /// </returns>
        public override int GetHashCode() => Name.GetHashCode(StringComparison.InvariantCulture);
    }
}