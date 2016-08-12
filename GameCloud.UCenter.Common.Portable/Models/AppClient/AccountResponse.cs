﻿// Copyright(c) Cragon.All rights reserved.

namespace GameCloud.UCenter
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class AccountResponse
    {
        [DataMember]
        public string AccountId { get; set; }

        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public AccountStatus AccountStatus { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string SuperPassword { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public DateTime LastLoginDateTime { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ProfileImage { get; set; }

        [DataMember]
        public string ProfileThumbnail { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public string IdentityNum { get; set; }

        [DataMember]
        public string PhoneNum { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}