using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLDH
{
    public class cPublic
    {
        static string strCon;

        public static string StrCon
        {
            get { return cPublic.strCon; }
            set { cPublic.strCon = value; }
        }
        static cPublic()
        {
            strCon = @"Data Source=ADMIN\SQLEXPRESS02;Initial Catalog=QLDH;Integrated Security=True";
        }
        public SqlConnection Conn = new SqlConnection(StrCon);
        public bool KT_TrungKhoaChinh(string pTable, string pColumn1, string pColumn2, string pKey1, string pKey2)
        {
            string selectString = "select * from " + pTable + " where " + pColumn1 + " = '" + pKey1 + "' and " + pColumn2 + " = '" + pKey2 + "'";
            SqlCommand cmd = new SqlCommand(selectString, Conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Close();
                return true;
            }
            else
            {
                rdr.Close();
                return false;
            }
        }
        public bool KT_TrungKhoaChinh(string pTable, string pColumn, string pKey)
        {
            string selectString = "select * from " + pTable + " where " + pColumn + " = '" + pKey + "'";
            SqlCommand cmd = new SqlCommand(selectString, Conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Close();
                return true;
            }
            else
            {
                rdr.Close();
                return false;
            }
        }
        public string TaoMa(string Table, string Column)
        {
            string ma = string.Empty;
            string strConn = "select * from " + Table;
            SqlDataAdapter da = new SqlDataAdapter(strConn, Conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int max = 0;
            foreach (DataRow dr in dt.Rows)
            {
                int x = int.Parse(dr[Column].ToString().Substring(2, 3));
                if (x > max)
                    max = x;
            }
            ma = (++max).ToString("000");
            return ma;
        }
    }
}
