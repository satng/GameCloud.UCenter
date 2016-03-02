﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCenter.Common.Models
{
    [Serializable]
    public class AppAccountVerificationInfo
    {
        public string AppId;
        public string AppKey;
        public ulong AccountId;
        public string AccountName;
        public string AccountToken;
        public bool GetAppData;
    }
}
