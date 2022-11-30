using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DBConnector
{
    
    public class MySQLCredentials : Credentials , IConnectionString
    {
        public string GetConnectionString()
        {
            StringBuilder str = new StringBuilder();

            if (Server != null) str.AppendFormat("Server={0};", Server);
            if (DataBase != null) str.AppendFormat("Database={0};", DataBase);
            if (Port != null) str.AppendFormat("Port={0}", Port);
            if (UserName != null) str.AppendFormat("Uid={0};", UserName);
            if (Password != null) str.AppendFormat("Pwd={0};", Password);
            if (Charset != null) str.AppendFormat("CharSet={0};", Charset.ToLower());
            if (ConnectionTimeout != null) str.AppendFormat("Connection Timeout={0};", ConnectionTimeout);

            if (SslMode != null)
            {
                string format = "SslMode={0};";
                switch (SslMode)
                {
                    case SSLMode.Disabled:
                        str.AppendFormat(format, "Disabled");
                        break;

                    case SSLMode.Preferred:
                        str.AppendFormat(format, "Preferred");
                        break;

                    case SSLMode.Required:
                        str.AppendFormat(format, "Required");
                        break;

                    case SSLMode.VerifyCA:
                        throw new NotImplementedException();

                    case SSLMode.VerifyIdentity:
                        throw new NotImplementedException();
                }
            }

            if (Pooling != null) str.AppendFormat("Pooling={0};", Pooling.Value ? "True" : "False");
            if (MinPoolSize != null) str.AppendFormat("MinimumPoolSize={0};", MinPoolSize);
            if (MaxPoolSize != null) str.AppendFormat("MaximumPoolSize={0};", MaxPoolSize);

            return str.ToString();
        }
    }
}
