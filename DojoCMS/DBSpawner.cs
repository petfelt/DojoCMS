using System;

namespace DojoCMS {
    public class DBSpawner{
        public string dbName;
        public DBSpawner(String name) 
        {
            dbName = name;
        }

        public void startDatabase() 
        {
            createDb();
            genTables();
        }
        public void genTables() 
        {
            String toCreate = String.Format("USE {0}; CREATE TABLE User("
                + "id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                + "name VARCHAR(30) NOT NULL,"
                + "email VARCHAR(60) NOT NULL,"
                + "password VARCHAR(50) NOT NULL,"
                + "created_at TIMESTAMP);", dbName);
            DbConnection.DbConnector.Query(toCreate);
            toCreate = String.Format("USE {0}; CREATE TABLE Post("
                + "id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                + "created_by INT UNSIGNED NOT NULL,"
                + "post VARCHAR(500) NOT NULL,"
                + "created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,"
                + "updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP);", dbName);
            DbConnection.DbConnector.Query(toCreate);
            toCreate = String.Format("USE {0}; CREATE TABLE Comment("
                + "id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                + "posted_by INT UNSIGNED NOT NULL,"
                + "comment_for INT UNSIGNED NOT NULL,"
                + "comment VARCHAR(200) NOT NULL,"
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