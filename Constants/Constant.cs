using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TovutiBackend.Constants
{
    public class Constant
    {
        //PATHS
        public static readonly string PATH_TOVUTI = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/TOVUTI";
        public static readonly string DIR_LOGS = PATH_TOVUTI + "/LOGS/log.txt";
        public static readonly string DIR_SCRIPTS = PATH_TOVUTI + "/SCRIPTS/tovuti-script.sql";
        public static readonly string DIR_DATABASE = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TOVUTI\\DATABASE\\";
        //MESSAGES
        public static readonly string MESSAGE_CREATE_SUCC = " WAS CREATED SUCCESSFULLY";
        public static readonly string MESSAGE_DELETE_SUCC = " WAS DELETED SUCCESSFULLY";
        public static readonly string MESSAGE_UPDATE_SUCC = " WAS UPDATED SUCCESSFULLY";
        public static readonly string MESSAGE_DELETE_FAIL = " SORRY FAILED TO CREATE DATA. PLEASE TRY AGAIN";
        public static readonly string MESSAGE_CREATE_FAIL = "SORRY FAILED TO CREATE DATA. PLEASE TRY AGAIN";
        public static readonly string MESSAGE_UPDATE_FAIL = "SORRY FAILED TO UPDATE DATA. PLEASE TRY AGAIN";
        public static readonly string MESSAGE_UNKOWN_ERROR = "SORRY AN UNKOWN ERROR OCCURED. TRY AGAIN";
        public static readonly string MESSAGE_ERROR = "AN ERROR OCCURED";



        //STATUS
        public static readonly string STATUS_SUCC = "1";
        public static readonly string STATUS_FAIL = "0";
        public static readonly string STATUS_ERROR = "-1";


        //NAMES
        public static readonly string APP_NAME = "TOVUTI";

    }
}