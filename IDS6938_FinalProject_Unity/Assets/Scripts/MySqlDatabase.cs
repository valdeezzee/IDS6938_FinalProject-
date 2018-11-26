/*
 * 
 * Jonathan Valderrama
 * This script will be used to connect to a mysql server
 * You can send, update, recieve and delete entries and any other dataa collections functions
 * we would like add in the future.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using MySql.Data;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Globalization;

public class MySqlDatabase : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
        Initialize();
    }

    private void OnApplicationQuit()
    {
        CloseConnection();
        // set the proper values that you want to set when the application ends
        // should be the same for when you end the simulation
        UpdateEntry("endTime", GetCurrentTime());
    }

    
    void Update()
    {
        #region TESTING FUNCTIONS
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    Insert();
        //}

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    UpdateEntry(GetLastInsertID(cmd));
        //}

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    DeleteEntry(GetLastInsertID(cmd));
        //}

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    CheckForEntry(GetLastInsertID(cmd));
        //}

        if (Input.GetKeyDown(KeyCode.P))
        {
            print(OpenConnection());
        }
        #endregion
    }

    public string GetCurrentTime()
    {
        // mysql expects time in format hour:minute:second
        return DateTime.Now.ToString(@"HH:mm:ss", new CultureInfo("en-US"));
    }

    public string GetCurrentDate()
    {
        //mysql expects date in format year/month/day
        return DateTime.Now.ToString(@"yyy/MM/dd", new CultureInfo("en-US"));
    }


    // initializes the connectionString and a msql connection
    public void Initialize()
    {
        connectionString = "Server=" + ip + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";SslMode=none" + ";";
        con = new MySqlConnection(connectionString);
    }

    // Opens a connectins to the server
    public bool OpenConnection()
    {
        try
        {            
            con.Open();
            //Debug.Log("Connection Successful!");
            return true;
        }
        catch (MySqlException e)
        {
            switch(e.Number)
            {
                case 0:
                    Debug.Log("Cannot connect to Server");
                    break;
                case 1045:
                    Debug.Log("Invalid username/password, please try again");
                    break;
            }
            return false;
        }
    }
    
    // Closes the connection to the server
    public bool CloseConnection()
    {
        try
        {
            if (con != null)
            {
                if (con.State.ToString() != "Closed")
                {
                    con.Close();
                    //Debug.Log("Mysql Connection Closed");
                }
                con.Dispose();
            }
            return true;
        }
        catch (MySqlException e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

    // This will be the initial insert when you start a simulation
    public void Insert()
    {
        try
        {
            if (OpenConnection())
            {
                // TODO: Change the command text to desired strings needed
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO " + tableName + "(id,trainerID,traineeID,date,startTime,endTime) VALUES (NULL, @trainerID, @traineeID, @date, @startTime, @endTime)";
                //cmd.Parameters.AddWithValue("@trainerID", MainMenuStatus.trainerID);
                //cmd.Parameters.AddWithValue("@traineeID", MainMenuStatus.traineeID);
                //cmd.Parameters.AddWithValue("@date", GetCurrentDate());
                //cmd.Parameters.AddWithValue("@startTime", GetCurrentTime());
                //cmd.Parameters.AddWithValue("@endTime", null);

                cmdSuccessful = cmd.ExecuteNonQuery();
                int id = GetLastInsertID(cmd);

                //Debug.Log("Entry Successfull: " + cmdSuccessful + " ID: " + id);

                CloseConnection();
            }            
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        
    }

    // Possible more generic insert function

    // Updates an entry with given id
    // This will be used to add data to a column when needed
    public void UpdateEntry(string whatToUpdate, string dataToUpdate, int id = -1)
    {
        try
        {
            if (OpenConnection())
            {
                id = id != -1 ? id : GetLastInsertID(cmd);
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE " + tableName + " SET " + whatToUpdate + " = @dataToUpdate WHERE id = '" + id + "'";
                cmd.Parameters.AddWithValue("@dataToUpdate", dataToUpdate);
                cmdSuccessful = cmd.ExecuteNonQuery();

                //Debug.Log("Update Successfull " + cmdSuccessful + " ID: " + id);

                CloseConnection();
            }            
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }


    // Deletes an entry from the database table with given id
    public void DeleteEntry(string whereToDelete = "",int id = -1)
    {
        try
        {
            if (OpenConnection())
            {
                id = id != -1 ? id : GetLastInsertID(cmd);
                // DELETE
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM " + tableName + " WHERE id = '" + id + "'";
                cmdSuccessful = cmd.ExecuteNonQuery();

                //Debug.Log("Entry Deleted " + cmdSuccessful + " ID: " + id);

                CloseConnection();
            }            
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
        
    }

    // Checks to see if an entry exists with a given id
    public void CheckForEntry(string whereToCheck = "", int id = -1)
    {
        try
        {
            if (OpenConnection())
            {
                id = id != -1 ? id : GetLastInsertID(cmd);
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM " + tableName + " WHERE id = '" + id + "'";//"SELECT COUNT(*) FROM sessions WHERE trainerID = 'jon'"
                cmdSuccessful = Convert.ToInt32(cmd.ExecuteScalar());

                //Debug.Log("Entry Exists " + cmdSuccessful + " ID: " + id);

                CloseConnection();
            }            
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
    }

    // returns the ID for the last entry you inserted
    // This will most likey be they id when you start the sim
    public int GetLastInsertID(MySqlCommand cmd)
    {
        cmd = con.CreateCommand();
        cmd.CommandText = "SELECT LAST_INSERT_ID()";
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    // if these variable have not been defined want to be changed, use this function.
    // it is use to create important string values that will be used to connect to the mysql server
    public void SetConnectionVariables(string IP, string DB, string USR, string PW)
    {
        ip = IP;
        database = DB;
        user = USR;
        password = PW;        
    }

    public void SetTable(string TN)
    {
        tableName = TN;
    }

    public string GetConnectionState()
    {
        return con.State.ToString();
    }

    public string GetConnectionString()
    {
        return connectionString;
    }

    #region Variables
    public string ip, database, user, password, tableName; // you can set these up in the inspector or call SetConnectionVariables()   

    private string connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader reader = null;
    private int cmdSuccessful = 0;
    private int id;

    private MD5 _md5Hash;
    #endregion

    

    public class Tests
    {
        // Used for setting up your test.  It is called once fefore each test case
        // If you have 5 methods annotated with [Test] then Setup runs 5 times.
        [SetUp]
        public void Setup()
        {
            mysqlGO = new GameObject("MySql").AddComponent<MySqlDatabase>();
            mysqlGO.SetConnectionVariables(ip, database, user, password);
            mysqlGO.SetTable(tableName);
            mysqlGO.Initialize();

            if (mysqlGO.OpenConnection())
            {
                //dataTest
                cmd = mysqlGO.con.CreateCommand();
                cmd.CommandText = "INSERT INTO " + tableName + " (id,trainerID,traineeID,date,startTime,endTime) VALUES (NULL, @trainerID, @traineeID, @date, @startTime, @endTime)";
                cmd.Parameters.AddWithValue("@trainerID", "jon");
                cmd.Parameters.AddWithValue("@traineeID", "christoper");
                cmd.Parameters.AddWithValue("@date", "2018-05-10");
                cmd.Parameters.AddWithValue("@startTime", "11:14:00");
                cmd.Parameters.AddWithValue("@endTime", "10:15:00");

                //id = mysqlGO.GetLastInsertID(cmd);
                cmdSuccessful = cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void Test3_UpdateEntry()
        {
            id = mysqlGO.GetLastInsertID(cmd);
            // UPDATE
            cmd = mysqlGO.con.CreateCommand();
            cmd.CommandText = "UPDATE " + tableName + " SET date = '2020-04-24' WHERE id = '" + id + "'";
            cmdSuccessful = cmd.ExecuteNonQuery();

            Debug.Log("Update Successful: " + cmdSuccessful + " ID: " + id);
            Assert.IsTrue(cmdSuccessful > 0);

        }

        [Test]
        public void Test4_CheckForEntry()
        {
            id = mysqlGO.GetLastInsertID(cmd);
            // CHECK FOR ENTRY
            cmd = mysqlGO.con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM " + tableName + " WHERE id = '" + id + "'";
            cmdSuccessful = Convert.ToInt32(cmd.ExecuteScalar());

            Debug.Log("Entry Exists: " + cmdSuccessful + " ID: " + id);
            Assert.IsTrue(cmdSuccessful > 0);
        }

        // TearDonw methods are called once after each test case.
        [TearDown]
        public void TearDown()
        {
            id = mysqlGO.GetLastInsertID(cmd);

            // DELETE
            cmd = mysqlGO.con.CreateCommand();
            cmd.CommandText = "DELETE FROM " + tableName + " WHERE id = '" + id + "'";
            cmdSuccessful = cmd.ExecuteNonQuery();

            Debug.Log("Entry Deleted " + cmdSuccessful + " ID: " + id);

            mysqlGO.CloseConnection();
        }

        #region Variables
        private MySqlDatabase mysqlGO;
        
        private string connectionString;
        private MySqlConnection con = null;
        private MySqlCommand cmd = null;
        private MySqlDataReader reader = null;

        private string ip = "10.190.97.171";
        private string database = "dhs";
        private string user = "e2i";
        private string password = "1234";
        private string tableName = "dataTest";
        private int cmdSuccessful = 0;
        private int id;
        #endregion

    }
}
