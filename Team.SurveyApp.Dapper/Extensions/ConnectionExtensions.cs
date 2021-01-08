using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Team.SurveyApp.Abstractions.Entity;
using Team.SurveyApp.Exceptions;
using Team.SurveyApp.Values;

namespace Team.SurveyApp.Dapper.Extensions
{
    internal class EmailTypeHandler : SqlMapper.TypeHandler<Email>
    {
        public override Email Parse(object value) => (string)value;

        public override void SetValue(IDbDataParameter parameter, Email value) => parameter.Value = value.ToString();
    }

    internal static class ConnectionExtensions
    {
        static ConnectionExtensions()
        {
            SqlMapper.AddTypeHandler(new EmailTypeHandler());
        }

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

        public static void Update<TEntity>(this IDbConnection connection, TEntity entity, IEnumerable<string> except = null)
            where TEntity : IHaveId
        {
            var entityType = typeof(TEntity);
            var ignore = except ?? Enumerable.Empty<string>();

            var props = entityType.StorableProperties()
                .Where(p => p.Name != "Id" && !except.Contains(p.Name))
                .Select(p => p.Name);
            
            if(entity is IHaveUpdatedTimeStamp)
            {
                (entity as IHaveUpdatedTimeStamp).Updated = DateTime.Now;
            }

            var updatePart = $"UPDATE {entityType.Name} SET";
            var fieldsPart = string.Join(", ", props.Select(p => $"{p} = @{p}"));
            var wherePart = $"WHERE Id = @Id";

            var sql = @$"{updatePart}
{fieldsPart}
{wherePart}";

            connection.Execute(sql, entity);
        }

        public static TEntity Get<TEntity>(this IDbConnection connection, int id)
            where TEntity : IHaveId
        {
            var tableName = typeof(TEntity).Name;

            try
            {
                return connection.QuerySingle<TEntity>($"SELECT * FROM {tableName} WHERE Id = @Id", new { Id = id });
            }
            catch (InvalidOperationException)
            {
                throw new EntryNotFoundException($"{tableName} with Id {id} not found.");
            }
        }
    }
}
