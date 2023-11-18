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
    public partial class rLookUp : Form
    {
        string usersql;    //쿼리문 저장 변수
        DBClass dbc = new DBClass();
        private String userID;
        public String getuserID
        { get { return userID; } }

        private String strCommand;
        public string getstrCommand
        { get { return strCommand; } }

        public rLookUp()
        {
            InitializeComponent();
            dbc.DB_Open();//*
            dbc.DB_Access();
        }

        public void list_search(String Find, String Sort)  // 검색과 정렬에 해당하는 SQL 작성 
        {
            if (Find == "" && Sort   == "")  //기본
            {
                usersql = "select U.u_id, U.u_name, U.u_phone, U.u_email, C.c_id, C.c_kind, C.c_name, C.c_size from userinform U, carinform C where U.u_id = C.u_id ORDER BY u_id ASC";
                sql_execute(usersql, dbc.DS);
            }
            else if (Find == "" && Sort != "")  //정렬
            {
                if (Sort == "name")
                { usersql = "select U.u_id, U.u_name, U.u_phone, U.u_email, C.c_id, C.c_kind, C.c_name, C.c_size from userinform U, carinform C where U.u_id = C.u_id ORDER BY u_name ASC"; }
                else if (Sort == "cNum")
                { usersql = "select U.u_id, U.u_name, U.u_phone, U.u_email, C.c_id, C.c_kind, C.c_name, C.c_size from userinform U, carinform C where U.u_id = C.u_id ORDER BY c_id ASC"; }
                else if (Sort == "pNum")
                { usersql = "select U.u_id, U.u_name, U.u_phone, U.u_email, C.c_id, C.c_kind, C.c_name, C.c_size from userinform U, carinform C where U.u_id = C.u_id ORDER BY u_phone ASC"; }
                

                sql_execute(usersql, dbc.DS);
            }
            else if (Find != "")  //검색
            {
                if (radioButton1.Checked)  //이름
                { usersql = "select U.u_id, U.u_name, U.u_phone, U.u_email, C.c_id, C.c_kind, C.c_name, C.c_size from userinform U, carinform C where U.u_id = C.u_id AND u_name Like '%" + Find + "%'"; }
                else if (radioButton2.Checked)  //차량 번호 검색
                { usersql = "select U.u_id, U.u_name, U.u_phone, U.u_email, C.c_id, C.c_kind, C.c_name, C.c_size from userinform U, carinform C where U.u_id = C.u_id AND c_id Like '%" + Find + "%'"; }

                sql_execute(usersql, dbc.DS);
                if (dbc.DS.Tables["Table"].Rows.Count == 0)
                {
                    MessageBox.Show("해당 회원이 없습니다");
                    usersql = "select U.u_id, U.u_name, U.u_phone, U.u_email, C.c_id, C.c_kind, C.c_name, C.c_size from userinform U, carinform C where U.u_id = C.u_id ORDER BY u_id ASC";
                    sql_execute(usersql, dbc.DS);
                }
            }
        }
        public void sql_execute(String sqlstr,DataSet dsstr)    //사용자 함수 정의
        {
            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            dbc.DA.Fill(dsstr, "Table");//<--
            dsstr.Tables["Table"].Clear();
            dbc.DA.Fill(dsstr, "Table");// 위에 클리어하고 다시한게 새로고침하면 늘어남

            DBGrid.AutoResizeColumns();
            DBGrid.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            DBGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DBGrid.AllowUserToAddRows = false;

            DBGrid.DataSource = dsstr.Tables["Table"].DefaultView;
            user_counter();
            user_header();     //함수 호출 

        }
        public void user_header()
        {
            DBGrid.Columns[0].HeaderText = "ID";
            DBGrid.Columns[1].HeaderText = "이름";
            DBGrid.Columns[2].HeaderText = "전화번호";
            DBGrid.Columns[3].HeaderText = "이메일";
            DBGrid.Columns[4].HeaderText = "차량 번호";
            DBGrid.Columns[5].HeaderText = "차량 종류";
            DBGrid.Columns[6].HeaderText = "차량 이름";
            DBGrid.Columns[7].HeaderText = "차량 크기";
        }
        public void user_counter()
        {
            int i;
            i = DBGrid.RowCount;
            label8.Text = "총 " + i;
        }

        private void button8_Click(object sender, EventArgs e) // 새로고침
        {
            list_search("", "");
            textBox1.Clear(); // 검색란 비우기
        }

        private void toolStripButton3_Click(object sender, EventArgs e)// (관리자) 주차 자리 조회
        {
            this.Visible = false;             // 추가

            rPark showrPark = new rPark();
            showrPark.StartPosition = FormStartPosition.Manual;
            showrPark.Location = new Point(50, 50);

            showrPark.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)// (관리자) 수익 정산
        {
            this.Visible = false;             // 추가

            rCalculate showrCalculate = new rCalculate();
            showrCalculate.StartPosition = FormStartPosition.Manual;
            showrCalculate.Location = new Point(50, 50);

            showrCalculate.ShowDialog();
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

        private void rLookUp_Load(object sender, EventArgs e) // 킬 때
        {
            list_search("", "");
        }

        private void button5_Click(object sender, EventArgs e)  // 회원 추가
        {
            strCommand = "추가";
            uInfrom showuSign = new uInfrom(this);
            showuSign.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e) //이름
        {
            list_search("", "name");
        }

        private void button3_Click(object sender, EventArgs e) //전화번호
        {
            list_search("", "pNum");
        }

        private void button4_Click(object sender, EventArgs e) //차량번호
        {
            list_search("", "cNum");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("검색 미입력");
            else
                list_search(textBox1.Text.Trim(), "");
        }

        private void button6_Click(object sender, EventArgs e) // 정보 수정
        {
            strCommand = "업데이트";
            userID = DBGrid.SelectedCells[0].Value.ToString();
            uInfrom showuSign = new uInfrom(this);
            showuSign.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e) // 정보 삭제
        {
            strCommand = "삭제";
            userID = DBGrid.SelectedCells[0].Value.ToString();
            uInfrom showuSign = new uInfrom(this);
            showuSign.ShowDialog();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)//입퇴석 확인
        {
            this.Visible = false;

            rCheckList showrCheckList = new rCheckList();
            showrCheckList.StartPosition = FormStartPosition.Manual;
            showrCheckList.Location = new Point(50, 50);
            showrCheckList.ShowDialog();
        }

        private void 회원추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "추가";
            uInfrom showuSign = new uInfrom(this);
            showuSign.ShowDialog();
        }

        private void 회원수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "업데이트";
            userID = DBGrid.SelectedCells[0].Value.ToString();
            uInfrom showuSign = new uInfrom(this);
            showuSign.ShowDialog();
        }

        private void 회원탈퇴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "삭제";
            userID = DBGrid.SelectedCells[0].Value.ToString();
            uInfrom showuSign = new uInfrom(this);
            showuSign.ShowDialog();
        }
    }
}
