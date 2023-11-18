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
    public partial class rCalculate : Form
    {
        DBClass dbc = new DBClass();
        string usersql;    //쿼리문 저장 변수
        int Price;
        String days;
        public rCalculate()
        {
            InitializeComponent();
            dbc.DB_Open();
            dbc.DB_Access();

        }

        public void list_search(String day)  // 검색과 정렬에 해당하는 SQL 작성 
        {   
            usersql = "select u_id,sum, outTime from paying where outTime Like '" + day + "%'";
            sql_execute(usersql, dbc.DS);
            fullCount();
        }
        public void sql_execute(String sqlstr, DataSet dsstr)    //사용자 함수 정의
        {
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            dbc.DA.Fill(dsstr, "payin");//<--
            dsstr.Tables["payin"].Clear();
            dbc.DA.Fill(dsstr, "payin");// 위에 클리어하고 다시한게 새로고침하면 늘어남

            DBGrid2.AutoResizeColumns();
            DBGrid2.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            DBGrid2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DBGrid2.AllowUserToAddRows = false;

            DBGrid2.DataSource = dsstr.Tables["payin"].DefaultView;
            user_header();     //함수 호출 
        }
        public void user_header()
        {
            DBGrid2.Columns[0].HeaderText = "유저 아이디";
            DBGrid2.Columns[1].HeaderText = "총액";
            DBGrid2.Columns[2].HeaderText = "계산일";
        }

        public void fullCount()
        {
            dbc.Userinform = dbc.DS.Tables["payin"];
            Price = 0;
            if (dbc.Userinform.Rows.Count > 0)
            {
                foreach (DataRow row in dbc.DS.Tables["payin"].Rows)
                {
                    string str;
                    str = row["sum"].ToString();
                    Price += int.Parse(str);
                }
            }
            End_price_value.Text = Price.ToString();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)// (관리자) 회원 조회
        {
            this.Visible = false;             // 추가

            rLookUp showrLookUp = new rLookUp();
            showrLookUp.StartPosition = FormStartPosition.Manual;
            showrLookUp.Location = new Point(50, 50);

            showrLookUp.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)// (관리자) 주차 자리관리
        {
            this.Visible = false;             // 추가

            rPark showrPark = new rPark();
            showrPark.StartPosition = FormStartPosition.Manual;
            showrPark.Location = new Point(50, 50);

            showrPark.ShowDialog();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)//  관리자 정보
        {
            rInform showrInform = new rInform();
            showrInform.ShowDialog();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)// 종료
        {
            Application.Exit();
        }

        private void rCalculate_Load(object sender, EventArgs e)
        {
            list_search(System.DateTime.Now.ToString("yyyy-MM-dd"));
            label2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            textBox1.Text = System.DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4);
            textBox2.Text = System.DateTime.Now.ToString("yyyy-MM-dd").Substring(5, 2);
            textBox3.Text = System.DateTime.Now.ToString("yyyy-MM-dd").Substring(8, 2);
        }
        private void button2_Click(object sender, EventArgs e)//일별 수익
        {
            days = textBox1.Text.Trim()+ "-"+ textBox2.Text.Trim() +"-" +textBox3.Text.Trim();

            list_search(days);
        }
        private void button1_Click(object sender, EventArgs e)//월수익
        {
            days = textBox1.Text.Trim() + "-" + textBox2.Text.Trim();

            list_search(days);
        }

        private void toolStripButton7_Click(object sender, EventArgs e) //입퇴석 확인
        {
            this.Visible = false;
            rCheckList showrCheckList = new rCheckList();
            showrCheckList.StartPosition = FormStartPosition.Manual;
            showrCheckList.Location = new Point(50, 50);
            showrCheckList.ShowDialog();
        }
    }
}

