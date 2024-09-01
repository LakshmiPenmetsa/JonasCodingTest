﻿using System;

namespace WebApi.Models
{
    public class EmployeeCreateInfo
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string OccuptionName { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastModified { get; set; }
    }
}