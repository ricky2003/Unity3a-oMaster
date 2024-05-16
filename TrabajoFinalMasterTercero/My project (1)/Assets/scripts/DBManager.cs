using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using TMPro;

public class DBManager : MonoBehaviour
{
    private string dburi = "URI=file:mydb.sqlite";//ruta de nuetra base de datos
                                                  // private string SQL_COUNT_ELEMENTS = " SELECT count(*) FROM users;";
    private string SQL_CREATE = "CREATE TABLE IF NOT EXISTS Usuarios (" +
        "Id INTEGER UNIQUE NOT NULL PRIMARY KEY AUTOINCREMENT" +
        ",UserName VARCHAR(50) NOT NULL" +
        ",Password VARCHAR(50) NOT NULL);";
    private int numeroData = 100;
    private IDbConnection dbConnection;
    public saltoaotrapantalla salto;

    // Start is called before the first frame update
    void Start()
    {
        //conexion a la base de datos
        Debug.Log("Start");
        dbConnection = CreateAndOpenDataBase();
        //SetInputUserAndPasword(dbConnection, user,password);

        dbConnection.Close();
        Debug.Log("End");
    }

    private IDbConnection CreateAndOpenDataBase()
    {
        IDbConnection dbConnection = new SqliteConnection(dburi);
        dbConnection.Open();
        IDbCommand dbcmd = dbConnection.CreateCommand();//creamos un nuevo comando
        dbcmd.CommandText = SQL_CREATE;//comando de sql que se hace para crear la tabla de datos
                                       //dbcmd.ExecuteReader();

        //guardar en la base de datos
        //salto.username;

        return dbConnection;
    }

    /*public void SetInputUserAndPasword(IDbConnection dbConnection)
    {
        string command = "INSERT INTO Usuarios(UserName,Password) VALUES";
        command += $"('ricardo','ricardo';),";
        command = command.Remove(command.Length - 1, 1);
        command += ";";
        Debug.Log(command);
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = command;
        dbCommand.ExecuteNonQuery();

    }*/

    public SqliteDataReader Select(string _select)
    {
        dbConnection.Open();
        IDbCommand dbcmd = dbConnection.CreateCommand();//creamos un nuevo comando
        dbcmd.CommandText = "SELECT * FROM " + _select;
        SqliteDataReader resultado = (SqliteDataReader)dbcmd.ExecuteReader();
        return resultado;
    }
}

