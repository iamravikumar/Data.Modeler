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

using Data.Modeler.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Modeler.Providers.SQLServer.SourceBuilders
{
    /// <summary>
    /// Schemas
    /// </summary>
    /// <seealso cref="ISourceBuilder"/>
    public class Schemas : ISourceBuilder
    {
        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order => 5;

        /// <summary>
        /// Provider name associated with the schema generator
        /// </summary>
        public DbProviderFactory Provider => SqlClientFactory.Instance;

        /// <summary>
        /// Fills the source.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="dataSource">The data source.</param>
        /// <exception cref="ArgumentNullException">dataSource</exception>
        public void FillSource(IEnumerable<dynamic> values, ISource dataSource)
        {
            if (dataSource == null)
                throw new ArgumentNullException(nameof(dataSource));
            if (values == null || !values.Any())
                return;
            foreach (dynamic Item in values)
            {
                dataSource.Schemas.Add(Item.Name);
            }
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <returns>The command to get the source</returns>
        public string GetCommand()
        {
            return @"SELECT name as [Name] FROM sys.schemas WHERE schema_id < 16384 AND schema_id > 4";
        }
    }
}