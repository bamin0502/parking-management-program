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
    public partial class rPark : Form
    {
        private OracleConnection odpConn = new OracleConnection();
        DBClass dbc = new DBClass();
        String id;
        string data;
        private int allseats = 26;
        private int restseats = 23;
        private void loadC(string i)

        {
            if (i != null)
            {
                odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                odpConn.Open();
                string strqry = "select * from carinform where u_id=:u_id";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = i.Trim();
                OracleDataReader odr = OraCmd.ExecuteReader();
                while (odr.Read())
                {
                    textBox4.Text = Convert.ToString(odr.GetValue(0));
                }
                odr.Close();
                odpConn.Close();
                data = null;
            }
            else
            {
                MessageBox.Show("사용자의 정확한 이름을 넣어주세요");
                textBox8.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
            }
        }
        private void loadU(string i)
        {
            if (i != null)
            {
                odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                odpConn.Open();
                string strqry = "select * from userinform where u_id=:u_id";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = i.Trim();
                OracleDataReader odr = OraCmd.ExecuteReader();
                while (odr.Read())
                {
                    textBox8.Text = Convert.ToString(odr.GetValue(2));
                    textBox2.Text = Convert.ToString(odr.GetValue(3));
                }
                odr.Close();
                odpConn.Close();
                data = null;
            }
            else 
            { 
                MessageBox.Show("사용자 차량의 번호를 정확히 넣어주세요");
                textBox8.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
            }
        }

        private void getCarInfo()
        {
           
                odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                odpConn.Open();
                string strqry = "select * from carinform where u_id=:u_id";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = id.Trim();
                OracleDataReader odr = OraCmd.ExecuteReader();
                while (odr.Read())
                {
                    textBox4.Text = Convert.ToString(odr.GetValue(0));
                }
                odr.Close();
                odpConn.Close();
        }
        public int list_search(String Find)
        {
            
            if (radioButton1.Checked)
            {
               
                odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                odpConn.Open();
                //string strqry = "select * from userinform where u_name=:u_name";
                string strqry = "select U.u_id, U.u_name, U.u_phone, E.s_code from userinform U, enroll E where E.u_id = U.u_id and U.u_name = :u_name";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                OraCmd.Parameters.Add("u_name", OracleDbType.Varchar2, 20).Value = Find;
                OracleDataReader odr = OraCmd.ExecuteReader();
                while (odr.Read())
                {
                    textBox8.Text= Convert.ToString(odr.GetValue(1));
                    textBox2.Text = Convert.ToString(odr.GetValue(2));
                    textBox3.Text = Convert.ToString(odr.GetValue(3));
                    data = Convert.ToString(odr.GetValue(0));
                }
               
                
                odr.Close();
                odpConn.Close();

                return 1;
            }
            if (radioButton2.Checked)
            {

                odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                odpConn.Open();
                string strqry = "select C.c_id, C.u_id, E.s_code from carinform C, enroll E where C.u_id = E.u_id and c_id=:c_id";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                OraCmd.Parameters.Add("c_id", OracleDbType.Varchar2, 20).Value = Find;
                OracleDataReader odr = OraCmd.ExecuteReader();
                while (odr.Read())
                {
                    textBox4.Text = Convert.ToString(odr.GetValue(0));
                    textBox3.Text = Convert.ToString(odr.GetValue(2));
                    data = Convert.ToString(odr.GetValue(1));
                }

                odr.Close();
                odpConn.Close();
                return 2;
            }
            return 0;

        }
        private void getUInfo()
        {

                odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
                odpConn.Open();
                string strqry = "select * from userinform where u_id=:u_id";
                OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

                OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = id.Trim();
                OracleDataReader odr = OraCmd.ExecuteReader();
                while (odr.Read())
                {
                    textBox8.Text = Convert.ToString(odr.GetValue(2));
                    textBox2.Text = Convert.ToString(odr.GetValue(3));
                }
                odr.Close();
                odpConn.Close();
        }
        private void getID()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from enroll where s_code=:s_code";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("s_code", OracleDbType.Varchar2, 20).Value = textBox3.Text.Trim();
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                id = Convert.ToString(odr.GetValue(1));  
            }
            odr.Close();
            odpConn.Close();
        }
        public rPark()
        {
            InitializeComponent();
            dbc.DBseat_Open();//*
            dbc.DB_Access();
        }
        private void changeButton()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from  enroll where u_id is null";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OracleDataReader odr = OraCmd.ExecuteReader();

            while (odr.Read())
            {

                string seatName;
                seatName = Convert.ToString(odr.GetValue(0));

                foreach (Button c in this.Controls.Find(seatName, true))
                    if (c.Name == seatName)
                    {
                        c.BackColor = System.Drawing.Color.Lime;
                    }
            }
            odr.Close();
            odpConn.Close();
        }
        private void changeButton1()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from  enroll where u_id is not null";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {

                string seatName;
                seatName = Convert.ToString(odr.GetValue(0));

                foreach (Button c in this.Controls.Find(seatName, true))
                    if (c.Name == seatName)
                    {
                        c.BackColor = System.Drawing.Color.Red;
                    }
            }
            odr.Close();
            odpConn.Close();
        }
        private void getResisterName()
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from register";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                textBox5.Text = Convert.ToString(odr.GetValue(1));
            }
            odr.Close();
            odpConn.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox7.Text = allseats.ToString();
            textBox6.Text = restseats.ToString();
            changeButton();
            changeButton1();
            getResisterName();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)// (관리자) 회원 조회
        {
            this.Visible = false;             // 추가
            rLookUp showrLookUp = new rLookUp();
            showrLookUp.StartPosition = FormStartPosition.Manual;
            showrLookUp.Location = new Point(50, 50);
            showrLookUp.ShowDialog();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)// (관리자) 수익 정산
        {
            this.Visible = false;             // 추가
            rCalculate showrCalculate = new rCalculate();
            showrCalculate.StartPosition = FormStartPosition.Manual;
            showrCalculate.Location = new Point(50, 50);

            showrCalculate.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e) // 관리자 정보
        {

            rInform showrInform = new rInform();

            showrInform.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)// 종료
        {
            Application.Exit();
        }

        private void Seats(object sender, EventArgs e)
        {
            textBox3.Text = ((Button)sender).Name;
            if (((Button)sender).BackColor == Color.Red)
            {
                getID();
                getUInfo();
                getCarInfo();

            }
            else
            {
                textBox3.Text = ((Button)sender).Name;
                textBox8.Text = "공석";
                textBox2.Text = "공석";
                textBox4.Text = "공석";
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("검색 미입력");      //검색 확인시 호출
            else
            {
                list_search(textBox1.Text.Trim());


                if (list_search(textBox1.Text.Trim()) == 1)
                {
                    loadC(data);
                }
                else if (list_search(textBox1.Text.Trim()) == 2)
                {
                    loadU(data);
                }
                else if (list_search(textBox1.Text.Trim()) == 0 || data == null)
                    MessageBox.Show("다시 검색해주세요");
            }
        }

        private void changed(object sender, EventArgs e)
        {
            if ((((Button)sender).BackColor == Color.Red))
                restseats--;
            else if ((((Button)sender).BackColor == Color.Lime))
                restseats++;
            textBox6.Text = restseats.ToString();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)//입퇴석확인
        {
            this.Visible = false;

            rCheckList showrCheckList = new rCheckList();
            showrCheckList.StartPosition = FormStartPosition.Manual;
            showrCheckList.Location = new Point(50, 50);
            showrCheckList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = allseats.ToString();
            textBox6.Text = restseats.ToString();
            changeButton();
            changeButton1();
            getResisterName();
        }
    }
}
