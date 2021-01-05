using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Team.SurveyApp.Abstractions.Entity;

namespace Team.SurveyApp.Dapper.Extensions
{
    internal static class ConnectionExtensions
    {
        private static IEnumerable<Type> _acceptedNonPrimitiveTypes = new Type[]
        {
            typeof(DateTime),
            typeof(string)
        };

        public static TEntity Insert<TEntity>(this IDbConnection connection, TEntity entity)
        {
            var entityType = typeof(TEntity);
            var entityHasId = entity is IHaveId;

            var props = entityType.StorableProperties()
                .Where(p => p.Name != "Id")
                .Select(p => p.Name);

            var fields = string.Join(", ", props.Select(p => $"[{p}]"));
            var parameters = string.Join(", ", props.Select(p => $"@{p}"));

            var outputId = entityHasId ? "OUTPUT INSERTED.Id" : string.Empty;

            var query = $@"INSERT INTO {entityType.Name} ({fields}) {outputId} VALUES ({parameters})";

            if (entityHasId)
            {
                (entity as IHaveId).Id = connection.QuerySingle<int>(query, entity);
            }
            else
            {
                connection.Execute(query, entity);
            }

            return entity;
        }

        public static TEntity Get<TEntity>(this IDbConnection connection, int id)
        {
            var tableName = typeof(TEntity).Name;

            return connection.QuerySingle<TEntity>($"SELECT * FROM {tableName} WHERE Id = @Id", new { Id = id });
        }
    }
}
