﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityLogin
    {
        public int iduser { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime birth { get; set; }
        public string email { get; set; }
    }
}