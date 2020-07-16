using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace PersonDB
{
    public class DBClass
    {

        private readonly string conString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Contact;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly SqlConnection con; // create connection

        public DBClass()
        {
            con = new SqlConnection(conString);
        }

        private DataTable CreateUITable() {
            DataTable person = new DataTable(); // Create new UI Table called person

            person.Clear();  // Clear UI Table in Visual Studio

            //Create Columns for Visual Studio Table
            person.Columns.Add("id");
            person.Columns.Add("first name");
            person.Columns.Add("last name");

            return person;
        }
        private DataTable ReadDATA(DataTable person)
        {
            string query = @"Select * From Person order by ID"; //Create Query 

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader(); //  Execute  Query of the Server

            //Reading form Server
            while (reader.Read())
            {
                // read data from Colums in Server and add to the person table in visual studio
                person.Rows.Add(
                    reader["ID"],
                    reader["FirstName"],
                    reader["LastName"]
                    );
            }
            reader.Close(); // Close the Data Reader


            return person;
        }

        public DataTable ShowPerson()
        {
            
            con.Open(); // Open Connection to Server

            DataTable person = CreateUITable();

            person = ReadDATA(person);

            con.Close(); // Close Connection to Server

            return person;
        }
    }
}
