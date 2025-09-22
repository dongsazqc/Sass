using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FaceGetTenant_CLB
{

    public static class CoreDataUtils
    {
        public static string tenantUrlApi = "";
        public static string versionWinform = "";
        public static string connectionString = "";
        public static string rabbitmqHost = "";
        public static bool IsNullEmpty(this string value)
        {
            if (value == null)
                return true;
            var value2 = value.Replace(" ", "");
            if (value2 == "" || value2 == Guid.Empty.ToString() || value2 == Guid.Empty.ToString())
                return true;
            else
                return false;
        }
        public static string GetConnString()
        {
            string conStr = connectionString;
            //conStr = "server=masterpro06.hosco.com.vn,1489;user id=svn_kythuat;password=hn123;database=HOSCODB_GYMMASTER2018_DEV_2020;";
            if (conStr == "")
                conStr = "server=masterpro20.hosco.com.vn,1433;user id=HOSCODB_GYMMASTER2018_DEV_2020;password=123456aa@;database=HOSCODB_GYMMASTER2018_DEV_2020;";
            return conStr;
        }

        public static string getMACAddress()
        {
            var macAddr =
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();
            return macAddr;
        }
        public static List<FileInfo> GetAllFiles(string folderPath)
        {
            List<FileInfo> lstFile = new List<FileInfo>();
            DirectoryInfo dinfo = new DirectoryInfo(folderPath);
            if (!dinfo.Exists)
                return lstFile;
            DirectoryInfo[] dirs = dinfo.GetDirectories();
            FileInfo[] lstF = dinfo.GetFiles();
            if (lstF != null && lstF.Length > 0)
            {
                foreach (var fi in lstF)
                {
                    lstFile.Add(fi);
                }
            }
            foreach (var dir in dirs)
            {
                var lstF2 = CoreDataUtils.GetAllFiles(dir.FullName);
                if (lstF2 != null && lstF2.Count > 0)
                {
                    foreach (var fi in lstF2)
                    {
                        lstFile.Add(fi);
                    }
                }
            }
            return lstFile;
        }
    }

}
