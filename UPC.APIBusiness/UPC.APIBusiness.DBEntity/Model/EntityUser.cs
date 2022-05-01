using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser
    {
        public int iduser { get; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime birth { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
