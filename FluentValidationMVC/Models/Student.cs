﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentValidationMVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public DateTime StudentDOB { get; set; }

        public string StudentEmailID { get; set; }

        public decimal StudentFees { get; set; }

        public string StudentAddress { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}