using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.DAL.Initializator
{
    public static class Constants
    {

        /// Users
        public const string ADMIN = "admin"; // role "admin"
        public const string ADMINID = "adminId"; // role "admin"

        public const string STUDENT = "student"; // role "student"
        public const string STUDENTID = "studentId"; // student


        /// Table name
        public const string TABLE_DISCIPLINES = "Disciplines"; // 
        public const string TABLE_STUDDISCS = "StudDiscs"; // 
        public const string TABLE_STUDENTS = "Students"; // 
        public const string TABLE_TEACHERS = "Teachers"; // 

        /// Path
        public const string SECRET_FILE = "wwwroot/SecretsFiles";
    }
}
