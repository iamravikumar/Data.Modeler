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

using BigBook;
using Data.Modeler.Providers.BaseClasses;
using Data.Modeler.Providers.Enums;
using Data.Modeler.Providers.Interfaces;
using System;
using System.Data;

namespace Data.Modeler.Providers
{
    /// <summary>
    /// StoredProcedure class
    /// </summary>
    public class StoredProcedure : TableBase, IFunction
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="schema">The schema.</param>
        /// <param name="definition">Definition of the stored procedure</param>
        /// <param name="source">Source</param>
        public StoredProcedure(string name, string schema, string definition, ISource source)
            : base(name, schema, source)
        {
            Definition = definition;
        }

        /// <summary>
        /// Definition of the stored procedure
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Adds a check constraint to the table.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="definition">The definition.</param>
        /// <returns>The check constraint added to the table</returns>
        public override ICheckConstraint? AddCheckConstraint(string name, string definition) => null;

        /// <summary>
        /// Adds a column
        /// </summary>
        /// <typeparam name="T">Column type</typeparam>
        /// <param name="columnName">Column Name</param>
        /// <param name="columnType">Data type</param>
        /// <param name="length">Data length</param>
        /// <param name="nullable">Nullable?</param>
        /// <param name="identity">Identity?</param>
        /// <param name="index">Index?</param>
        /// <param name="primaryKey">Primary key?</param>
        /// <param name="unique">Unique?</param>
        /// <param name="foreignKeyTable">Foreign key table</param>
        /// <param name="foreignKeyColumn">Foreign key column</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="computedColumnSpecification">The computed column specification.</param>
        /// <param name="onDeleteCascade">On Delete Cascade</param>
        /// <param name="onUpdateCascade">On Update Cascade</param>
        /// <param name="onDeleteSetNull">On Delete Set Null</param>
        /// <returns></returns>
        public override IColumn AddColumn<T>(string columnName, DbType columnType, int length = 0,
            bool nullable = true, bool identity = false, bool index = false,
            bool primaryKey = false, bool unique = false, string foreignKeyTable = "",
            string foreignKeyColumn = "", T defaultValue = default, string computedColumnSpecification = "",
            bool onDeleteCascade = false, bool onUpdateCascade = false, bool onDeleteSetNull = false)
        {
            return Columns.AddAndReturn(new Column<T>(columnName,
                columnType,
                length,
                nullable,
                identity,
                index,
                primaryKey,
                unique,
                foreignKeyTable,
                foreignKeyColumn,
                defaultValue,
                computedColumnSpecification,
                onDeleteCascade,
                onUpdateCascade,
                onDeleteSetNull,
                this));
        }

        /// <summary>
        /// Adds a foreign key
        /// </summary>
        /// <param name="columnName">Column name</param>
        /// <param name="foreignKeyTable">Foreign key table</param>
        /// <param name="foreignKeyColumn">Foreign key column</param>
        public override void AddForeignKey(string columnName, string foreignKeyTable, string foreignKeyColumn)
        {
        }

        /// <summary>
        /// Adds a trigger to the table
        /// </summary>
        /// <param name="name">Name of the trigger</param>
        /// <param name="definition">Definition of the trigger</param>
        /// <param name="type">Trigger type</param>
        /// <returns>The trigger specified</returns>
        public override ITrigger? AddTrigger(string name, string definition, TriggerType type) => null;

        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The copy of this instance.</returns>
        public override ITable Copy(ISource source) => new StoredProcedure(Name, Schema, Definition, source);

        /// <summary>
        /// Copies the specified instance
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The copy</returns>
        IFunction IFunction.Copy(ISource source) => new StoredProcedure(Name, Schema, Definition, source);

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
            return (obj is StoredProcedure Item)
                && Definition == Item.Definition
                && Name == Item.Name;
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