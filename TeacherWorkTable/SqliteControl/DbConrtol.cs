using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;

namespace TeacherWorkTable
{
    public static class DbControl
    {
        //查询获取摄像头信息列表
        public static ArrayList GetCamerasByDB()
        {
            ArrayList clist = new ArrayList();
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "SELECT * FROM CAMERA";
            cmd.Connection = cn;
            SQLiteDataReader sr = cmd.ExecuteReader();
            while (sr.Read())
            {
                string[] camera = new string[6];
                camera[0] = sr.GetInt32(0).ToString();
                camera[1] = sr.GetString(1);
                camera[2] = sr.GetString(2);
                camera[3] = sr.GetString(3);
                camera[4] = sr.GetString(4);
                camera[5] = sr.GetInt32(5).ToString();
                clist.Add(camera);
            }
            return clist;
        }
        public static int GetCameraNumByDB()
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
            ArrayList clist = new ArrayList();
            SQLiteCommand cmd_count = new SQLiteCommand();
            cmd_count.Connection = cn;
            cmd_count.CommandText = "SELECT COUNT(*) FROM CAMERA";
            SQLiteDataReader sr = cmd_count.ExecuteReader();
            sr.Read();
            int DataNum = sr.GetInt32(0);
            return DataNum;
        }
        public static string[] SelectCameraById(int id)
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;
            string cmd_text = String.Format("SELECT * FROM CAMERA WHERE ID = {0}", id);
            cmd.CommandText = cmd_text;
            string[] camera = new string[3];
            try
            {
                SQLiteDataReader sr = cmd.ExecuteReader();
                sr.Read();
                camera[0] = sr.GetString(2);
                camera[1] = sr.GetString(3);
                camera[2] = sr.GetString(4);
            }
            catch (Exception ex) { System.Console.WriteLine(ex); return null; }
            return camera;
        }
        //添加摄像头数据
        public static bool SetCameraToDB(int id, string alias, string ip, string name, string pwd)
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }

            SQLiteCommand cmd_insert = new SQLiteCommand();
            cmd_insert.Connection = cn;
            string cmd_text = String.Format("INSERT INTO CAMERA VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}')", id, alias, ip, name, pwd, 0, DateTime.Now.ToString().Replace('/', '-'), DateTime.Now.ToString().Replace('/', '-'));
            cmd_insert.CommandText = cmd_text;
            try
            {
                cmd_insert.ExecuteNonQuery();
            }
            catch (Exception ex) { 
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\Release\access.log", true, Encoding.UTF8))
                {
                    string strLog = DateTime.Now.ToString().Replace('/', '-') + " - error - " + ex.ToString();
                    file.WriteLine(strLog);
                    file.Close();
                }
                return false;
            }
            return true;
        }
        //更新摄像头数据
        public static bool UpdateCameraDB(int id, string alias, string ip, string name, string pwd)
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;
            string cmd_text = String.Format("UPDATE CAMERA SET ALIAS = '{0}', IP = '{1}', CNAME = '{2}', CPWD = '{3}', UPDATE_TIME = '{4}' WHERE ID = {5}", alias, ip, name, pwd, DateTime.Now.ToString().Replace('/', '-'), id);
            cmd.CommandText = cmd_text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { System.Console.WriteLine(ex); return false; }
            return true;
        }

        public static bool DeleteCameraDB(int id)
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;
            string cmd_text = String.Format("DELETE FROM CAMERA WHERE ID = {0}", id);
            cmd.CommandText = cmd_text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { System.Console.WriteLine(ex); return false; }
            return true;
        }

        public static string[] GetUseCameraDB()
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;
            string cmd_text = String.Format("SELECT * FROM CAMERA WHERE USETAG = 1");
            cmd.CommandText = cmd_text;
            string[] camera = new string[4];
            try
            {
                SQLiteDataReader sr = cmd.ExecuteReader();
                sr.Read();
                camera[0] = sr.GetInt32(0).ToString();
                camera[1] = sr.GetString(2);
                camera[2] = sr.GetString(3);
                camera[3] = sr.GetString(4);
            }catch(Exception ex) { System.Console.WriteLine(ex); return null; }
            return camera;
        }

        public static bool SwitchCameraDB(int id)
        {
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
            }
            SQLiteCommand cmd_pre = new SQLiteCommand();
            cmd_pre.Connection = cn;
            string cmd_text = String.Format("UPDATE CAMERA SET USETAG = 0, UPDATE_TIME = '{0}' WHERE USETAG = 1", DateTime.Now.ToString().Replace('/', '-'));
            cmd_pre.CommandText = cmd_text;
            try
            {
                cmd_pre.ExecuteNonQuery();
            }
            catch (Exception ex) { System.Console.WriteLine(ex); return false; }

            SQLiteCommand cmd_lat = new SQLiteCommand();
            cmd_lat.Connection = cn;
            cmd_text = String.Format("UPDATE CAMERA SET USETAG = 1, UPDATE_TIME = '{0}' WHERE ID = {1}", DateTime.Now.ToString().Replace('/', '-'), id);
            cmd_lat.CommandText = cmd_text;
            try
            {
                cmd_lat.ExecuteNonQuery();
            }
            catch (Exception ex) { System.Console.WriteLine(ex); return false; }
            return true;
        }

        private static SQLiteConnection cn = new SQLiteConnection("data source = ../Release/teacher.db");
    }

}
