using System;
using MySql.Data.MySqlClient;   
namespace DojoCMS {
    public class DBSpawner{
        public string dbName;
        private readonly DbConnector dbConnection;
        public DBSpawner(String name, DbConnector connect) 
        {
            dbName = name;
            dbConnection = connect;
        }

        public void startDatabase() 
        {
            createDb();
            genTables();
        }
        public void genTables() 
        {
            String toCreate = String.Format("USE {0}; CREATE TABLE Users("
                + "id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                + "name VARCHAR(30) NOT NULL,"
                + "email VARCHAR(60) NOT NULL,"
                + "password VARCHAR(50) NOT NULL,"
                + "created_at TIMESTAMP);", dbName);
                
            string test = DbConnector.Execute(toCreate);
            toCreate = String.Format("USE {0}; CREATE TABLE Posts("
                + "id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                + "userid INT UNSIGNED NOT NULL,"
                + "post TEXT NOT NULL,"
                + "created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,"
                + "updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP);", dbName);
            DbConnection.DbConnector.Query(toCreate);
            toCreate = String.Format("USE {0}; CREATE TABLE Comments("
                + "id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                + "userid INT UNSIGNED NOT NULL,"
                + "postid INT UNSIGNED NOT NULL,"
                + "comment TEXT NOT NULL,"
                + "created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,"
                + "updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP);", dbName);
            DbConnection.DbConnector.Query(toCreate);
        }

        public void createDb() 
        {
            var queryString = String.Format("CREATE DATABASE {0};", dbName);
            var output = DbConnection.DbConnector.Query(queryString);
        }
    }
}