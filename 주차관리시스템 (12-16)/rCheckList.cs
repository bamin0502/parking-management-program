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
    public partial class rCheckList : Form
    {
        DBClass dbc = new DBClass();
        string usersql;    //쿼리문 저장 변수
        String days;
        public rCheckList()
        {
            InitializeComponent();
            dbc.DB_Open();
            dbc.DB_Access();
        }
        public void list_search(String day,String search)  // 검색과 정렬에 해당하는 SQL 작성 
        {
            if (day != "" && search == "")
            {
                usersql = "select U.u_name, U.u_id, U.u_phone, C.c_id, P.p_code, P.intime, P.outtime from userinform U, carinform C, paying P where U.u_id = C.u_id and U.u_id = P.u_id and P.outtime Like '" + day + "%'";
            }
            else
            {
                if (radioButton1.Checked)  //이름
                { usersql = "select U.u_name, U.u_id, U.u_phone, C.c_id, P.intime, P.outtime from userinform U, carinform C, paying P where U.u_id = C.u_id and U.u_id = P.u_id and U.u_name Like '%" + search + "%'"; }
                else if (radioButton2.Checked)  //차량 번호 검색
                { usersql = "select U.u_name, U.u_id, U.u_phone, C.c_id, P.intime, P.outtime from userinform U, carinform C, paying P where U.u_id = C.u_id and U.u_id = P.u_id and C.c_id Like '%" + search + "%'"; }
            }
            sql_execute(usersql, dbc.DS);
            if (dbc.DS.Tables["record"].Rows.Count == 0)
            {
                MessageBox.Show("해당 회원이 없습니다");
                day = System.DateTime.Now.ToString("yyyy-MM-dd");
                usersql = "select U.u_name, U.u_id, U.u_phone, C.c_id, P.intime, P.outtime from userinform U, carinform C, paying P where U.u_id = C.u_id and U.u_id = P.u_id and P.outtime Like '" + day + "%'";
                sql_execute(usersql, dbc.DS);
            }
        }
        public void sql_execute(String sqlstr, DataSet dsstr)    //사용자 함수 정의
        {
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            dbc.DA.Fill(dsstr, "record");//<--
            dsstr.Tables["record"].Clear();
            dbc.DA.Fill(dsstr, "record");// 위에 클리어하고 다시한게 새로고침하면 늘어남

            DBGrid2.AutoResizeColumns();
            DBGrid2.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            DBGrid2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DBGrid2.AllowUserToAddRows = false;

            DBGrid2.DataSource = dsstr.Tables["record"].DefaultView;
            user_header();     //함수 호출 

        }
        public void user_header()
        {
            DBGrid2.Columns[0].HeaderText = "이름";
            DBGrid2.Columns[1].HeaderText = "유저 아이디";
            DBGrid2.Columns[2].HeaderText = "전화번호";
            DBGrid2.Columns[3].HeaderText = "차 번호";
            DBGrid2.Columns[4].HeaderText = "입석 시간";
            DBGrid2.Columns[5].HeaderText = "퇴석 시간";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)// (관리자) 회원 조회
        {
            this.Visible = false;             // 추가

            rLookUp  showrLookUp = new rLookUp();
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
            usersql = "select U.u_name, U.u_id, U.u_phone, C.c_id, P.intime, P.outtime from userinform U, carinform C, paying P where U.u_id = C.u_id and U.u_id = P.u_id and P.outtime Like '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "%'";
            sql_execute(usersql, dbc.DS);
            //list_search(System.DateTime.Now.ToString("yyyy-MM-dd"),"");
            label2.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            textBox1.Text = System.DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4);
            textBox2.Text = System.DateTime.Now.ToString("yyyy-MM-dd").Substring(5, 2);
            textBox3.Text = System.DateTime.Now.ToString("yyyy-MM-dd").Substring(8, 2);
        }
        private void button2_Click(object sender, EventArgs e)//일별 수익
        {
            days = textBox1.Text.Trim()+ "-"+ textBox2.Text.Trim() +"-" +textBox3.Text.Trim();

            list_search(days,"");
        }


        private void button1_Click(object sender, EventArgs e)//월수익
        {
            days = textBox1.Text.Trim() + "-" + textBox2.Text.Trim();

            list_search(days,"");
        }

        private void toolStripButton4_Click(object sender, EventArgs e) // 수익 정산
        {
            this.Visible = false;

            rCalculate showcalculate = new rCalculate();
            showcalculate.StartPosition = FormStartPosition.Manual;
            showcalculate.Location = new Point(50, 50);
            showcalculate.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //검색 확인버튼
        {
            if (textBox4.Text.Trim() == "")
                MessageBox.Show("검색 미입력");
            else
                list_search("", textBox4.Text.Trim());
        }
    }
}

