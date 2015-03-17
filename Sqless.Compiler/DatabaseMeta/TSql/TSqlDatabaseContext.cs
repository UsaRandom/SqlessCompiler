using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta;
using Sqless.Compiler.DatabaseMeta.TSql;
using Sqless.Compiler.DatabaseMeta.Types;

namespace Sqless.Compiler.DatabaseMeta.Context
{
class TSqlDatabaseContext : IDatabaseContext
{
	public TSqlDatabaseContext(string connectionString)
	{
		m_connectionString = connectionString;
		m_databaseMetas = new Dictionary<string, SqlDatabaseMeta>();
		m_typeRelationshipMap = new TSqlRDMSSqlTypeRelationshipMap();

		//check to see if connection string has a default database...

	}


	public ISqlDatabaseMeta GetDatabaseMeta(string databaseName)
	{
		databaseName = databaseName.ToLower();

		SqlDatabaseMeta databaseMeta;

		//check to see if we already have the database info.
		if(!m_databaseMetas.TryGetValue(databaseName, out databaseMeta))
		{
			databaseMeta = new SqlDatabaseMeta(databaseName);

			FillSchemaMetas(databaseMeta);
			FillTableMetas(databaseMeta);

			FillInColumns(databaseMeta);
		}

		return databaseMeta;
	}



	private void FillSchemaMetas(SqlDatabaseMeta database)
	{
		database.Schemas = new List<ISqlSchemaMeta>();

		var conn = new SqlConnection(m_connectionString);

		using (var cmd = new SqlCommand("SELECT SCHEMA_NAME FROM " + database.Name + ".INFORMATION_SCHEMA.SCHEMATA"))
		{
			conn.Open();
			cmd.Connection = conn;
			
			var reader = cmd.ExecuteReader();

			while(reader.Read())
			{
				 database.Schemas.Add(new SqlSchemaMeta(reader.GetString(0)));
			}
			conn.Close();
		}

	}

	private void FillTableMetas(SqlDatabaseMeta database)
	{
		database.Tables = new List<ISqlTableMeta>();

		var conn = new SqlConnection(m_connectionString);

		using (var cmd = new SqlCommand("SELECT TABLE_SCHEMA ,TABLE_NAME FROM " + database.Name + ".INFORMATION_SCHEMA.TABLES"))
		{
			conn.Open();
			cmd.Connection = conn;
			
			var reader = cmd.ExecuteReader();

			while(reader.Read())
			{
				ISqlSchemaMeta schema = database.Schemas.Single(s => s.Name == reader.GetString(0));
				database.Tables.Add(new SqlTableMeta(database, schema, reader.GetString(1)));
			}
			conn.Close();
		}
		
	}  

	private void FillInColumns(SqlDatabaseMeta databaseMeta)
	{
		var conn = new SqlConnection(m_connectionString);

		using(var cmd = new SqlCommand("SELECT [TABLE_SCHEMA], [TABLE_NAME], [COLUMN_NAME], [IS_NULLABLE] ,[DATA_TYPE],[CHARACTER_MAXIMUM_LENGTH] FROM "+databaseMeta.Name+".[INFORMATION_SCHEMA].[COLUMNS]"))
		{
			conn.Open();
			cmd.Connection = conn;
						
			var reader = cmd.ExecuteReader();

			while(reader.Read())
			{
				var table = (SqlTableMeta)databaseMeta.Schemas.Single(s => s.Name == reader.GetString(0))
												.Tables.Single(t => t.Name == reader.GetString(1));

				FillColumnWithDataType(table, reader.GetString(2), reader.GetString(4), reader.GetString(3));



			}
			conn.Close();
		}
	}

	public void FillColumnWithDataType(ISqlTableMeta table, string name, string typeString, string nullableString)
	{
		bool isNullable = nullableString == "YES";
		
		ISqlDataType type = m_typeRelationshipMap.GetSqlDataType(typeString, 0, isNullable);

		table.Columns.Add(new SqlColumnMeta<ISqlDataType>(name, type, table));


	}

	private string m_connectionString;

	private IRDMSSqlTypeRelationshipMap m_typeRelationshipMap;
	private IDictionary<string, SqlDatabaseMeta> m_databaseMetas; 
}
}
