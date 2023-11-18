using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class uLogin : Form
    {
        DBClass dbc = new DBClass();
        uPark upark;
        String USERID;
        public String getUSERID
        { get { return USERID; } }
        public uLogin(uPark uPark)
        {
            InitializeComponent();
            dbc.DB_Open();//*
            dbc.DB_Access();
            upark = uPark;
        }
        private void button2_Click(object sender, EventArgs e)//취소
        {
            Close();
        }
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
                    if (ID.Text.Trim() == row["u_id"].ToString()&& PassWord.Text.Trim()==row["u_passwd"].ToString())
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
                        return true;
                    }
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)//확인
        {
            if (upark.getstrCommand == "정산")
            {
                if (userUpadate() == true && userUpadate2() == true)
                {
                    string u_id = ID.Text.Trim();
                    Price price = new Price(u_id);
                    price.ShowDialog();
                    Close();
                }
                else if (userUpadate() == true && userUpadate2() == false)
                {
                    MessageBox.Show("등록된 회원이 아닙니다");
                }
                else if (ID.Text.Trim() == "")
                {
                    MessageBox.Show("아이디를 확인해주세요");
                }
                else if (PassWord.Text.Trim() == "")
                {
                    MessageBox.Show("비밀번호를 확인해주세요");
                }
                else
                {
                    MessageBox.Show("회원 정보를 다시 확인해주세요");
                }
            }else if (upark.getstrCommand == "수정")
                {
                   if (userUpadate() == true)
                    {
                        uInfrom upark = new uInfrom(this);
                        upark.ShowDialog();
                    Close();
                    }
                    else if (ID.Text.Trim() == "")
                    {
                        MessageBox.Show("아이디를 확인해주세요");
                    }
                    else if (PassWord.Text.Trim() == "")
                    {
                        MessageBox.Show("비밀번호를 확인해주세요");
                    }
                    else
                    {
                        MessageBox.Show("회원 정보를 다시 확인해주세요");
                    }
                }
        }
    }
}
