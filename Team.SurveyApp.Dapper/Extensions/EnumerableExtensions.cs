using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static Dapper.SqlMapper;

namespace Team.SurveyApp.Dapper.Extensions
{
    internal static class EnumerableExtensions
    {
        public static ICustomQueryParameter ToTableValuedParameter<TEntry>(this IEnumerable<TEntry> collection, string name)
        {
            var entryType = typeof(TEntry);
            var dataTable = new DataTable();
            var entryProperties = entryType.StorableProperties();
            foreach (var entryProperty in entryProperties)
            {
                dataTable.Columns.Add(entryProperty.Name, entryProperty.PropertyType);
            }

            foreach (var item in collection)
            {
                var row = dataTable.NewRow();
                foreach (var entryProperty in entryProperties)
                {
                    row[entryProperty.Name] = entryProperty.GetValue(item);
                }
                dataTable.Rows.Add(row);
            }

            return dataTable.AsTableValuedParameter(name);
        }
    }
}
