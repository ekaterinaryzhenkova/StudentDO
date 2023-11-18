using Microsoft.Data.SqlClient;

namespace HomeWork3
{
    internal class OrderingsRepository
    {
        private const string ConnectionString =
      @"Server=localhost\sqlexpress;Database=HomeWork1DB;Trusted_Connection=True;Encrypt=False;";
        private const string GetOrderinsSQL = @"SELECT * FROM Orderins";
        private const string GetOrderinSQL = @"SELECT * FROM Orderins WHERE Id = '{0}'";
        private const string AddOrderinSQL = @"INSERT INTO Orderins (Id, Name, PhoneNumber) VALUES ('{0}', '{1}', '{2}')";
        private const string DeleteOrderinSQL =
            @"DELETE FROM Orderins WHERE Id = '{0}'";
        private const string UpdateOrderinSQL = @"UPDATE Orderins SET Name = '{0}', PhoneNumber = '{1}' WHERE Id = '{2}'";

        public void UpdateOrderin(string name, string phone, Guid userId)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(UpdateOrderinSQL, name, phone, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
        }

        public void DeleteOrderin(Guid userId)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(DeleteOrderinSQL, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
        }

        public void AddOrderin(Guid userId, string name, string number)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(AddOrderinSQL, userId, name, number);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }

        public string GetOrderinsFromDB()
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand(GetOrderinsSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["Date"];
                result += " ";
                result += sqlDataReader["ClientId"];
                result += "\n";
            }

            return result;
        }

        public string GetOrderin(Guid userId)
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(GetOrderinSQL, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["Date"];
                result += " ";
                result += sqlDataReader["ClientId"];
            }

            return result;
        }
    }
}
