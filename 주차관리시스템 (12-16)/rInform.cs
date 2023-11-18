using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class rInform : Form
    {
        DBClass dbc = new DBClass();
        public rInform()
        {
            InitializeComponent();
            dbc.DB_Open();//*
            dbc.DB_Access();
        }
        private OracleConnection odpConn = new OracleConnection();
        private void register()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from register";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("r_code", OracleDbType.Varchar2, 20).Value = 1;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                rName.Text = Convert.ToString(odr.GetValue(1));
                rPhoneNum.Text = Convert.ToString(odr.GetValue(2));
                rEmail.Text = Convert.ToString(odr.GetValue(3));
                rNotice.Text = Convert.ToString(odr.GetValue(4));
            }
            odr.Close();
            odpConn.Close();
        }
        private int rUpdate()
        {
            String Name = rName.Text.Trim();
            String PhoneNum = rPhoneNum.Text.Trim();
            String Email = rEmail.Text.Trim();
            String Notice = rNotice.Text.Trim();

            String sqlstr = "UPDATE register SET r_name =" + "'" + Name + "'" + ", r_phone = " + "'" + PhoneNum + "'" + ", r_email = " + "'" + Email + "'" + ", r_notice = " + "'" + Notice + "'" + "WHERE r_code = " + "'" + 1 + "'";

            dbc.DCom.CommandText = sqlstr;
            return dbc.DCom.ExecuteNonQuery();
        }
        private void rInform_Load(object sender, EventArgs e)
        {
            register();
        }

        private void button2_Click(object sender, EventArgs e)// 취소
        {
            Close();        
        }

        private void button1_Click(object sender, EventArgs e) //확인
        {
            rUpdate();
            Close();
        }
    }
}
