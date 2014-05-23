using Art.Data.Domain.Access.Initializers;
using Art.Data.Domain.Access.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access
{
   public class SqlServerDataProvider:IDataProvider
    {
        public void InitDatabase(string sqlCommandFile)
        {
            string[] sqlCommands;
            if (string.IsNullOrEmpty(sqlCommandFile))
            {
                sqlCommands = new string[0];
            }
            else
            {
                sqlCommands = ParseCommands(sqlCommandFile);
            } 
            var migrate = new System.Data.Entity.MigrateDatabaseToLatestVersion<ArtDbContext, Configuration>();
            Database.SetInitializer(migrate);
            //Database.SetInitializer(new ArtCreateDatabaseIfNotExists(sqlCommands));  
            
            //Database.SetInitializer<ArtDbContext>(null);
        }

        private string[] ParseCommands(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException(string.Format("Specified file doesn't exist - {0}", filePath));
            }

            var statements = new List<string>();
            using (var stream = File.OpenRead(filePath))
            using (var reader = new StreamReader(stream))
            {
                var statement = string.Empty;

                while ((statement = ReadNextStatementFromStream(reader)) != null)
                {
                    statements.Add(statement);
                }
            }

            return statements.ToArray();
        }

        private string ReadNextStatementFromStream(StreamReader reader)
        {
            var sb = new StringBuilder();

            string lineOfText;

            while (true)
            {
                lineOfText = reader.ReadLine();
                if (lineOfText == null)
                {
                    break;
                }

                if (lineOfText.TrimEnd().ToUpper() == "GO")
                {
                    break;
                }

                sb.Append(lineOfText + Environment.NewLine);
            }

            if (sb.Length == 0)
            {
                return null; 
            }

            return sb.ToString();
        }

    }
}
