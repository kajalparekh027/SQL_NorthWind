using System.Data.SqlClient;

string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";

SqlConnection Connection = new(ConnectionString);
Connection.Open();

SqlCommand Command = new("select * from categories", Connection);

var Result = Command.ExecuteReader();

while (Result.Read()) {
    var CatName = Result.GetValue(1).ToString();
    var CatDesc = Result.GetValue(2).ToString();
    System.Console.WriteLine(CatName.PadRight(15) + ": " + CatDesc);
}

Connection.Close();

Connection.Open();
Command.CommandText = "insert into categories (categoryname, description) " +
    " values ('Shoes', 'Nice shoes')";

Command.ExecuteNonQuery();
Connection.Close();