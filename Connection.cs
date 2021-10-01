using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionDll
{
    public class Connection
    {
        static int tableWidth = 165;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr=null ;


        public static void CreateConnection()
        {
            string constr = @"Data source=ZISHAN\SQLEXPRESS;initial catalog=RSystem;user=sa;password=pass@123";
            con = new SqlConnection();
            con.ConnectionString = constr;
            
        }
        public static bool Validate(string username, string password)
        {
            if (username == "Zishan" && password == "pass@123")
            {
                Console.WriteLine("Login Successfull!!!!!!!!");
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void ActiveRestaurants()
        {
            con.Open();
            string query = "select * from Restaurant where Status='Active'";
            cmd = new SqlCommand(query, con);

            dr=cmd.ExecuteReader();
            //cmd = new SqlCommand(query, con);

            PrintLine();
            PrintRow("RestaurantName", "OpeningTime", "ClosingTime", "PhoneNo", "Address", "Cuisine", "Status");
            PrintLine();
            while (dr.Read())
            {
                PrintRow(Convert.ToString(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToString(dr[3]), Convert.ToString(dr[4]), Convert.ToString(dr[5]), Convert.ToString(dr[6]));
            }
            PrintLine();

            con.Close();
        }
        //printing Line
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        //Printing Line Ends

        //printing row
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        //printing row end
        //Aling Center
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        //Allign Center ends

        //Search Restaurant Start
        public static void SearchRestaurant(string sname)
        {
            con.Open();
            string query = "select * from Restaurant where RestaurantName='" + sname + "'";
            cmd = new SqlCommand(query, con);
            dr=cmd.ExecuteReader();
            Console.Write("\tRestauratName\tOpeningTime\tClosingTime\tPhoneNo\tAddress\tCuisine\tStatus\n");
            while (dr.Read())
            {
                Console.WriteLine();
                Console.Write("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\n", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
            }
            con.Close();
        }
        //End of Search

        //Add Restaurant start
        public static void AddRestaurant(string Restnm, string RestOpen, string RestClose,string RestPhno, string RestAddr, string RestCn, string RestSts)
        {
            con.Open();
            string query = "insert into Restaurant values('"+Restnm+"','"+RestOpen+"','"+RestClose+"','"+RestPhno+"','"+RestAddr+"','"+RestCn+"','"+RestSts+"')";
            cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            try
            {
                //con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Data Inserted Successfully");
                con.Close();
            }

        }
        //End Add Restaurant

        //Update Restaurant Starts
        public static void UpdateRestaurant(string updName,string oldName)
        {
            con.Open();
            string query = "update Restaurant set RestaurantName='" + updName + "' where RestaurantName=" + oldName + "";
            cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();

            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Update Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Record Updated Successfully");
                con.Close();
            }

        }
        //Update Restaurant Ends

        //Delete Restaurant start
        public static void DeleteRestaurant(string dlName)
        {
            con.Open();
            string dlquery = "delete from Restaurant where RestaurantName=" + dlName + "";
            cmd = new SqlCommand(dlquery, con);
            //cmd.ExecuteNonQuery();

            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Deletion Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Record Deleted Successfully");
                con.Close();
            }

        }

        //Delete Restaurant Ends
        
    }
}
