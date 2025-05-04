using System.Data;
using Microsoft.Data.SqlClient;
using MMSDotNetTrainingBatch1.ConsoleApp3;

//Data Source = Server Name
//Initial Catalog = Database Name
//User ID = Login
//Password = sa@123

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
//{
//    DataSource = ".",
//    InitialCatalog = "MMSDotNetTrainingBatch1",
//    UserID = "sa",
//    Password = "sa@123",
//    TrustServerCertificate = true
//};

//SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=MMSDotNetTrainingBatch1; User ID= sa; Password=sa@123;TrustServerCertificate=True;");

//SqlConnection connectin = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//connectin.Open();

//string query = "select * from Tbl_Homework";
//SqlCommand cmd = new SqlCommand(query, connectin);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);

//connectin.Close();

HomeworkService service = new HomeworkService();

//service.Detail(1);
//service.Read();
service.Delete();

Console.ReadLine();