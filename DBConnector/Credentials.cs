using System;
using System.Collections.Generic;
using System.Text;

namespace DBConnector
{
    public enum SSLMode
    {
        Disabled,
        Preferred,
        Required,
        VerifyCA,
        VerifyIdentity
    }

    public class Credentials
    {
        public string? Server;
        public string? DataBase;
        public string? UserName;
        public string? Password;
        public string? Charset;
        public int? Port;
        public SSLMode? SslMode;
        public int? ConnectionTimeout;
        public bool? Pooling;
        public int? MinPoolSize;
        public int? MaxPoolSize;
    }
}
