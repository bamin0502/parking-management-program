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
    public partial class uParkButton : Form
    {
        String USERID;
        String Pw;

        private OracleConnection odpConn = new OracleConnection();
        DBClass dbc = new DBClass();
        object data;
        public bool userUpadate()
        {
            String sqlstr = "select * from userinform where u_id =" + "'" + ID.Text.Trim() + "'";
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            dbc.DA.Fill(dbc.DS, "Login");

            dbc.Userinform = dbc.DS.Tables["Login"];

            if (dbc.Userinform.Rows.Count > 0)
            {
                foreach (DataRow row in dbc.DS.Tables["Login"].Rows)
                {
                    if (ID.Text.Trim() == row["u_id"].ToString() && PassWord.Text.Trim() == row["u_passwd"].ToString())
                    {
                        USERID = ID.Text.Trim();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool userUpadate2()
        {
            String sqlstr = "select * from enroll";
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            dbc.DA.Fill(dbc.DS, "Check");

            dbc.Userinform = dbc.DS.Tables["Check"];

            if (dbc.Userinform.Rows.Count > 0)
            {
                foreach (DataRow row in dbc.DS.Tables["Check"].Rows)
                {
                    if (USERID == row["u_id"].ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int updateEnroll()
        {
            string inTime = Time.Text.Trim();
            String u_ID = USERID.Trim();
            String seat = ((Button)data).Name.Trim();

            String sqlstr = "UPDATE enroll SET u_id= "+"'"+u_ID+"'"+", inTime="+"'" + inTime + "'" + "WHERE s_code = " + "'" + seat + "'";

                dbc.DCom.CommandText = sqlstr;
                return dbc.DCom.ExecuteNonQuery();
        }
        public uParkButton(object sender)
        {
            InitializeComponent();
            data = sender;
            dbc.DB_Open();
            dbc.DB_Access();
        }
        private void uParkButton_Load(object sender, EventArgs e)
        {
            choosedBox.Text = ((Button)data).Text;
            timer1.Start();
            timer1.Interval = 1000;
            Time.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        }

        private void button1_Click(object sender, EventArgs e) // 등록하기
        {
            if (userUpadate() == true && userUpadate2()== true)
            {
                updateEnroll();
                ((Button)data).Enabled = false;
                ((Button)data).BackColor = Color.Red;
            }else if (userUpadate() == true && userUpadate2() == false)
            {
                MessageBox.Show("등록된 회원입니다");
            }
            else  if (ID.Text.Trim() == "")
            {
                MessageBox.Show("아이디를 확인해주세요");
            }
            else if (PassWord.Text.Trim() == "")
            {
                MessageBox.Show("비밀번호를 확인해주세요");
            }
            else
            {
                MessageBox.Show("회원 정보 확인해주세요");
            }
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //뒤로가기
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text= System.DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        }
    }
}
