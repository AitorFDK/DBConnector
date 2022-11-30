using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DBConnector
{
    public class DB
    {
        private MySqlConnection _connection { get; set; }

        public DB(IConnectionString credentials) : this(credentials.GetConnectionString())
        {

        }

        public DB(string credentials)
        {
            _connection = new MySqlConnection(credentials);
            _connection.Open();
        }

        public ConnectionState GetConnectionState() => _connection.State;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MySqlDataReader ExecuteReader(string sql, List<MySqlParameter> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(sql, _connection);

            if (parameters != null)
                foreach (MySqlParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }

            return command.ExecuteReader();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteScalar(string sql, List<MySqlParameter> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(sql, _connection);

            if (parameters != null)
                foreach (MySqlParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }

            return int.Parse(command.ExecuteScalar().ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, List<MySqlParameter> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(sql, _connection);

            if (parameters != null)
                foreach (MySqlParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }

            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// Closes and Dispose the connection to the Data Base
        /// </summary>
        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
