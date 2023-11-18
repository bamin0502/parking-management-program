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
    public partial class Price : Form
    {

        private OracleConnection odpConn = new OracleConnection();
        DBClass dbc = new DBClass();
        string ID;
        String outTime;
        String inT;
        String s_code;
        Random random = new Random();
        string billnum;
        object data;
        String register;
        private void getSeat()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from enroll where u_id=:u_id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = ID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                s_code = Convert.ToString(odr.GetValue(0));

            }
            odr.Close();
            odpConn.Close();
        }
        
        private void getIntime()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from enroll where u_id=:u_id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = ID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                inT = Convert.ToString(odr.GetValue(2));
            }
            odr.Close();
            odpConn.Close();
        }
        private void getRegisterNotice()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from register";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
             
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                register = Convert.ToString(odr.GetValue(0));
                textBox2.Text= Convert.ToString(odr.GetValue(4));
            }
            odr.Close();
            odpConn.Close();
        }
        private int InsertPay() //회원 추가 유저 정보
        {
            String p_code = billnum.Trim();
            String u_id = ID.Trim();
   
            int sum = Convert.ToInt32(label18.Text.Trim());
            String s_c = s_code.Trim();
            String inTime = inT.Trim();
            String oTime = outTime.Trim();
            //string regist = Convert.ToString(1);
            String sqlstr1 = "INSERT INTO paying  VALUES (" + "'" + p_code + "'" + ',' + "'" + u_id + "'" + ',' + "'" + sum + "'" + ',' + "'" + s_c + "'" +','+"'"+ inTime+"'"+','+"'"+ oTime+"'" + ',' + "'"+register+"')";
            MessageBox.Show("영수증 번호 :" + p_code.Trim());
            dbc.DCom.CommandText = sqlstr1;
            return dbc.DCom.ExecuteNonQuery();
        }
        private string GetBillCode()
        {
            string num = null;

            int[] a = new int[5];
            int ran = 0;
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }
            for (int i = 0; i < a.Length; i++)
            {
                int temp = a[i];
                ran = random.Next(0, 5);
                a[i] = a[ran];
                a[ran] = temp;
                num += a[i].ToString();
            }
            return num;
        }
        private void FillinUser()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from userinform where u_id=:u_id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = ID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                label15.Text = Convert.ToString(odr.GetValue(2));

            }
            odr.Close();
            odpConn.Close();
        }
        private void FillinRegister()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from register where r_code=:r_code";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("r_code", OracleDbType.Varchar2, 20).Value = 1;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                label8.Text = Convert.ToString(odr.GetValue(1));
                label11.Text = Convert.ToString(odr.GetValue(2));
            }
            odr.Close();
            odpConn.Close();
        }
        private void FillinPay()
        {
            int a1 = Convert.ToInt32(label16.Text.Trim().Substring(11, 2));//등록시간
            int b1 = Convert.ToInt32(label21.Text.Trim().Substring(11, 2));//나가는시간

            int a2 = Convert.ToInt32(label16.Text.Trim().Substring(14, 2));//등록분
            int b2 = Convert.ToInt32(label21.Text.Trim().Substring(14, 2));//나가는분

            int sumTime = (b1*60+b2)-(a1*60+a2);

            if (sumTime < 60)
            {
                label18.Text = "2000"; //기본료
            }
            else
            {
                label18.Text = Convert.ToString(2000 + 50 * (sumTime - 60));
            }

            int c1 = Convert.ToInt32(label18.Text.Trim());

            label6.Text = Convert.ToString(c1 * 0.95);
            label17.Text = Convert.ToString(c1 * 0.05);
        }

        private int UpdateSeat()
        {
            String u_ID = ID.Trim();
            String seat = s_code;

            String sqlstr = "UPDATE enroll SET u_id= null WHERE s_code = " + "'" + seat + "'";

            dbc.DCom.CommandText = sqlstr;
            return dbc.DCom.ExecuteNonQuery();
        }
       
        public Price(string data)
        {
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 1000;
            dbc.DB_Open();//*
            dbc.DB_Access();
            ID = data;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            outTime = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            billnum = GetBillCode();
            getIntime();
            getSeat();
            label16.Text = inT;
            label21.Text = outTime;
            label15.Text = ID;
            FillinRegister();
            FillinUser();
            FillinPay();
            getRegisterNotice();
            label2.Text = billnum;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateSeat();
            InsertPay();        
            
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tt.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
