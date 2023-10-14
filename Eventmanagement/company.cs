using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventmanagement
{
    public partial class company : MaterialForm
    {
        string email= userinput.email != null ? userinput.email : userregistration.email;
        string connectionstring = "Server=localhost\\SQLEXPRESS;Database=csharpproject;Trusted_Connection=True";
        public company()
        {
            InitializeComponent();


            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            try
            {
                string query = "SELECT companyname FROM vendors";
                SqlCommand command = new SqlCommand(query,connection);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) { 
                    comboBox1.Items.Add(reader.GetString(0));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void company_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string companyname = comboBox1.SelectedItem.ToString();

            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            try
            {
                string query = "SELECT * FROM items WHERE companyname=@compname";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@compname", companyname);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    int dbballon, dbtable, dbchair, dbcooler, dbcake, dbcanopy, dbpoll;
                    dbballon = reader.GetInt32(0);
                    dbtable = reader.GetInt32(1);
                    dbchair = reader.GetInt32(2);
                    dbcooler = reader.GetInt32(3);
                    dbcake = reader.GetInt32(4);
                    dbcanopy = reader.GetInt32(5);
                    dbpoll = reader.GetInt32(6);

                    reader.Close();

                    if(order.ballon > dbballon || order.table > dbtable || order.chair > dbchair || order.cooler > dbcooler || order.cake > dbcake || order.canopy > dbcanopy || order.poll > dbpoll)
                    {
                        MessageBox.Show("Company cannot satisfy all your orders");
                    }
                    else
                    {
                        int newBallon = dbballon - order.ballon;
                        int newTable = dbtable - order.table;
                        int newChair = dbchair - order.chair;
                        int newCooler = dbcooler - order.cooler;
                        int newCake = dbcake - order.cake;
                        int newCanopy = dbcanopy - order.canopy;
                        int newPoll = dbpoll - order.poll;

                        string updateQuery = "UPDATE items SET ballons=@newBallon, tables=@newTable, chairs=@newChair, coolers=@newCooler, cakes=@newCake, Canopies=@newCanopy, polls=@newPoll WHERE companyname=@companyname";
                        SqlCommand command2 = new SqlCommand(updateQuery, connection);
                        command2.Parameters.AddWithValue("@newBallon", newBallon);
                        command2.Parameters.AddWithValue("@newTable", newTable);
                        command2.Parameters.AddWithValue("@newChair", newChair);
                        command2.Parameters.AddWithValue("@newCooler", newCooler);
                        command2.Parameters.AddWithValue("@newCake", newCake);
                        command2.Parameters.AddWithValue("@newCanopy", newCanopy);
                        command2.Parameters.AddWithValue("@newpoll", newPoll);
                        command2.Parameters.AddWithValue("@companyname", companyname);
                        command2.ExecuteNonQuery();

                        string query2 = "INSERT INTO orders (emailaddress, companyname, ballons, tables, chairs, coolers, cakes, Canopies, polls) VALUES (@email, @company, @ballon, @table, @chair, @cooler, @cake, @canopy, @poll)";
                        SqlCommand conn = new SqlCommand(query2, connection);
                        conn.Parameters.AddWithValue("@email", email);
                        conn.Parameters.AddWithValue("@company", companyname);
                        conn.Parameters.AddWithValue("@ballon", order.ballon);
                        conn.Parameters.AddWithValue("@table", order.table);
                        conn.Parameters.AddWithValue("@chair", order.chair);
                        conn.Parameters.AddWithValue("@cooler", order.cooler);
                        conn.Parameters.AddWithValue("@cake", order.cake);
                        conn.Parameters.AddWithValue("@canopy", order.canopy);
                        conn.Parameters.AddWithValue("@poll", order.poll);
                        conn.ExecuteNonQuery();

                        MessageBox.Show("Order successful");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            this.Close();
            order order1 = new order();
            order1.Show();
        }
    }
}
