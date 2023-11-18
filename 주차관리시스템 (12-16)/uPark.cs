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
    public partial class uPark : Form
    {
        
        private OracleConnection odpConn = new OracleConnection();
        private String strCommand;
        private int allseats = 26;
        private int restseats = 23;
        public string getstrCommand
        { get { return strCommand; } }
        public uPark()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 1000;
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
                        c.Enabled = true;
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
                        c.Enabled = false;
                        c.BackColor = System.Drawing.Color.Red;
                    }
            }
            odr.Close();
            odpConn.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            
            all_s.Text = allseats.ToString();
            rest_s.Text = restseats.ToString();
            changeButton();
            changeButton1();
        }
        private void button2_Click(object sender, EventArgs e)//회원가입
        {
            strCommand = "추가";
            uInfrom showuSign = new uInfrom(this);
            showuSign.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)//회원수정
        {
            strCommand = "수정";
            uLogin login = new uLogin(this);
            login.ShowDialog();
        }
       
        private void button1_Click(object sender, EventArgs e)//정산하기
        {
            string t = label4.Text;
            strCommand = "정산";
            uLogin login = new uLogin(this);
            login.ShowDialog();
        }
        private void Seats(object sender, EventArgs e)
        {
            object data = sender;
            uParkButton frm = new uParkButton(data);
            frm.ShowDialog();
            
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label4.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh mm");
            changeButton();
            changeButton1();
        }

        private void Changed(object sender, EventArgs e)
        {
            if ((((Button)sender).Enabled == false))
                restseats--;
            else if ((((Button)sender).Enabled == true))
                restseats++;
            rest_s.Text = restseats.ToString();
        }
    }
}
