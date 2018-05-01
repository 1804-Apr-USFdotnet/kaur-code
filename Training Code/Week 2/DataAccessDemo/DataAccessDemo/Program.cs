using System;
using System.Data;//1. ADO.Net Library
using System.Data.SqlClient;//2. Add the provider
using System.Configuration;
using System.Data.OleDb;
using System.Collections;

namespace DataAccessDemo
{
    class Program
    {
        //1. Make a connection
        static SqlConnection con;
        //2. Fire the query
        static SqlCommand cmd;
        //or 2. DataAdapter
        static SqlDataAdapter da;
        //3. Exceute the query and store the result
        static SqlDataReader dr;
        static DataSet ds=null;
        static string conStr = ConfigurationManager.ConnectionStrings["AdvWorks"].ToString(); 
        //"Data Source=DESKTOP-3EEE01S;Initial Catalog=AdventureWorks2017;Integrated Security=True";
         static string query = "select * from Sales.Customers";
        //static string query = "uspGetEmployeeManagers";
        #region Connected Architecture
        static void ConnectedDemo()
        {
           
            int id = 78;
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    //1.1 open the connection
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("@BusinessEntityID", id);
                    cmd.Parameters.Add(parameter);
                    dr = cmd.ExecuteReader();
                    Console.WriteLine("Output of Sales.Customers");
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["BusinessEntityID"] + " " + dr["firstName"] + " " + dr["lastName"]);
                        //Console.WriteLine(dr[0]+" ||"+dr[1]+"  || "+dr[2]+"|| "+dr["city"]+" || "+dr["country"]+ " || "+dr["name"]);
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

        #region DisconnectedArchitecture
        static void DisconnectedDemo()
        {
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    using (da = new SqlDataAdapter(query, con))
                    {
                        ds = new DataSet();// temporary database
                        //open conn=> fire query=> bring results=> close the conn
                        int rows = da.Fill(ds, "Customers");
                        if (rows != 0)
                        {
                            foreach (DataRow row in ds.Tables["Customers"].Rows)
                            {
                                Console.WriteLine(row["contactname"] + " || " + row["city"]);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        static void Main(string[] args)
        {
            //ConnectedDemo();
            DisconnectedDemo();

        }
    }
}
