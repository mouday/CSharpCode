using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Readini
{
    //如数据库服务器配置文件：

    //DBServer.ini

    //[Server]
    //Name=localhost
    //[DB]
    //Name=NorthWind
    //[User]
    //Name=sa

    //此类包含两个函数，读取ini文件和写入ini文件
    //参考网络文章，由mouday封装测试，admin@mouday.com
    class ReadWriteini
    {
        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);


        #endregion

        #region 读Ini文件

        public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
        {
            //这里的NoText对应API函数的def参数，它的值由用户指定，
            //是当在配置文件中没有找到具体的Value时，就用NoText的值来代替。
            //NoText 可以为null或""
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion

        #region 写Ini文件

        public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}

