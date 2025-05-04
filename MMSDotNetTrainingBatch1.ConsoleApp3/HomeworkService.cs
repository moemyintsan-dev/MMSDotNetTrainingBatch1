using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MMSDotNetTrainingBatch1.ConsoleApp3
{
    internal class HomeworkService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MMSDotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            SqlConnection connectin = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connectin.Open();

            string query = "select * from Tbl_Homework";
            SqlCommand cmd = new SqlCommand(query, connectin);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connectin.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataColumn dc = dt.Columns["No"];

                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine("--------------");
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine("--------------");
            }
        }
        public void Detail(int no)
        {
            SqlConnection connectin = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connectin.Open();

            string query = $"select * from Tbl_Homework where No = @No";
            SqlCommand cmd = new SqlCommand(query, connectin);
            cmd.Parameters.AddWithValue("@No", no);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connectin.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["No"]);
            Console.WriteLine(dr["Name"]);
            Console.WriteLine(dr["GitHubUserName"]);
            Console.WriteLine("--------------");
        }

        public void Create()
        {
            Console.Write("Enter Name");
            string name = Console.ReadLine();

            Console.Write("Enter GitHubUserName");
            string githubUserName = Console.ReadLine();

            Console.Write("Enter GitHubRepoLink");
            string githubRepoLink = Console.ReadLine();

            SqlConnection connectin = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connectin.Open();

            string query = $@"INSERT INTO [dbo].[Tbl_Homework]
           ([Name]
           ,[GitHubUserName]
           ,[GitHubRepoLink])
     VALUES
           ('@Name'
           ,'@GitHubUserName'
           ,'@GitHubRepoLink')";

            SqlCommand cmd = new SqlCommand(query, connectin);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
            cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);

            int result = cmd.ExecuteNonQuery();

            connectin.Close();
        }

        public void Update()
        {
            Console.Write("Enter Id:");
            string id = Console.ReadLine();

            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Enter GitHubUserName:");
            string githubUserName = Console.ReadLine();

            Console.Write("Enter GitHubRepoLink:");
            string githubRepoLink = Console.ReadLine();

            SqlConnection connectin = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connectin.Open();

            string query = $@"UPDATE [dbo].[Tbl_Homework]
    SET [Name] = @Name
      ,[GitHubUserName] = @GitHubUserName
      ,[GitHubRepoLink] = @GitHubRepoLink
    WHERE No = @Id";

            SqlCommand cmd = new SqlCommand(query, connectin);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
            cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);

            int result = cmd.ExecuteNonQuery();
            connectin.Close();
        }
        public void Delete()
        {
            Console.Write("Enter Id:");
            string id = Console.ReadLine();

            SqlConnection connectin = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connectin.Open();

            string query = $@"DELETE FROM [dbo].[Tbl_Homework]
      WHERE No = @Id";

            SqlCommand cmd = new SqlCommand(query, connectin);
            cmd.Parameters.AddWithValue("@Id", id);
           
            int result = cmd.ExecuteNonQuery();
            connectin.Close();
        }
    }
}
