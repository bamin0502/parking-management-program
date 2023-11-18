using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;//ADO.Net 개체 참조

namespace WindowsFormsApp1
{
    public partial class uInfrom : Form
    {
        private OracleConnection odpConn = new OracleConnection();
        private bool idcheck = false;
        private bool passwdcheck = false;
        DBClass dbc = new DBClass();
        rLookUp rlook;
        uPark upark;
        uLogin ulogin;
        public uInfrom(rLookUp rLookUp)
        {
            InitializeComponent();
            dbc.DB_Open();//*
            dbc.DB_Access();
            rlook = rLookUp;
        }
        public uInfrom(uPark uPark)
        {
            InitializeComponent();
            dbc.DB_Open();//*
            dbc.DB_Access();
            upark = uPark;
        }
        public uInfrom(uLogin uLogin)
        {
            InitializeComponent();
            dbc.DB_Open();//*
            dbc.DB_Access();
            ulogin = uLogin;
        }
        private int INSERTRowUser() //회원 추가 유저 정보
        {
            String Name = name.Text.Trim();
            String ID = userId.Text.Trim();
            String PassWord = passwd.Text.Trim();
            String PhoneNum = pNum.Text.Trim();
            String Email = email.Text.Trim();

            String sqlstr = "INSERT INTO userinform  VALUES (" + "'" + ID + "'" + ',' + "'" + PassWord + "'" + ',' + "'" + Name + "'" + ',' + "'" + PhoneNum + "'" + ',' + "'" + Email + "'" + ")";

            dbc.DCom.CommandText = sqlstr;
            return dbc.DCom.ExecuteNonQuery();
        }
        private int INSERTRowCar()//회원 추가 차 정보
        {
            String ID = userId.Text.Trim();
            String CarNum = carNum.Text.Trim();
            String CarKind = carKind.Text.Trim();
            String CarName = carName.Text.Trim();
            String CarSize = carSize.Text.Trim();
            
            
                String sqlstr1 = "INSERT INTO carinform  VALUES (" + "'" + CarNum + "'" + ',' + "'" + CarKind + "'" + ',' + "'" + CarName + "'" + ',' + "'" + CarSize + "'" + ',' + "'" + ID + "'" + ")";
                dbc.DCom.CommandText = sqlstr1;
                return dbc.DCom.ExecuteNonQuery();
            
          
        }
        
        private int UPDATERowUser() //회원 수정 유저 정보
        {
            String Name = name.Text.Trim();
            String ID = userId.Text.Trim();
            String PassWord = passwd.Text.Trim();
            String PhoneNum = pNum.Text.Trim();
            String Email = email.Text.Trim();

            String sqlstr = "UPDATE userinform SET u_passwd=" + "'" + PassWord + "'" + ", u_name ="+ "'" + Name + "'" + ", u_phone = " + "'" + PhoneNum + "'" + ", u_email = " +"'"+ Email + "'" + "WHERE u_id = " + "'" + ID + "'";

            dbc.DCom.CommandText = sqlstr;
            return dbc.DCom.ExecuteNonQuery();
        }
        private int UPDATERowCar() //회원 수정 차 정보
        {

            String ID = userId.Text.Trim();
            String CarNum = carNum.Text.Trim();
            String CarKind = carKind.Text.Trim();
            String CarName = carName.Text.Trim();
            String CarSize = carSize.Text.Trim();

            String sqlstr = "UPDATE carinform SET c_id=" + "'" + CarNum + "'" + ", c_kind =" + "'" + CarKind + "'" + ", c_name = " + "'" + CarName + "'" + ", c_size = " + "'" + CarSize + "'" + "WHERE u_id = " + "'" + ID + "'";
            if (ID == null)
                MessageBox.Show("차량번호를 기입해주세요");
            dbc.DCom.CommandText = sqlstr;
            return dbc.DCom.ExecuteNonQuery();
        }
        private int DELETERowUser() //회원 수정 유저 정보
        {
            String ID = userId.Text.Trim();

            String sqlstr = "DELETE FROM userinform WHERE u_id=" + "'" + ID + "'";

            dbc.DCom.CommandText = sqlstr;
            return dbc.DCom.ExecuteNonQuery();
        }
        private int DELETERowCar() //회원 삭제 차 정보
        {
            String ID = userId.Text.Trim();

            String sqlstr = "DELETE FROM carinform WHERE u_id=" +"'"+ ID +"'";

            dbc.DCom.CommandText = sqlstr;
            return dbc.DCom.ExecuteNonQuery();
        }

        private void createUserInform() // 회원 추가 때
        {
            if (passwd.Text != passwordck.Text) // 비밀번호 확인
            {
                label11.ForeColor = Color.Red;
                label11.Text = "비밀번호가 일치하지 않습니다";
                passwdcheck = false;
            }
            else if (passwd.Text == "")
            {

                label11.ForeColor = Color.Red;
                label11.Text = "      비밀번호를 입력해주세요";
                passwdcheck = false;
            }
            else
            {
                passwdcheck = true;
            }

            if (userId.Text == "") // 아이디 공백시
            {
                label12.ForeColor = Color.Red;
                label12.Text = "아이디를 입력해주세요";
            }

            if (passwdcheck == true && idcheck == true) // 아이디 비번 다 확인함
            {
                INSERTRowUser();
                INSERTRowCar();
                Close();
            }
            else if (idcheck == false && passwdcheck == true)
            {
                MessageBox.Show("아이디를 확인해주세요");
            }
            else if (idcheck == true && passwdcheck == false)
            {
                MessageBox.Show("비밀번호를 확인해주세요");
            }
            else
            {
                MessageBox.Show("회원 정보 기입란들을 확인해주세요");
            }
        }
        private void FixorDelete() //수정 혹은 삭제
        {
            if (passwd.Text != passwordck.Text) // 비밀번호 확인
            {
                label11.ForeColor = Color.Red;
                label11.Text = "비밀번호가 일치하지 않습니다";
            }
            else
            {
                passwdcheck = true;
            }
            if (passwdcheck== true)
            {
                if (button2.Text == "업데이트"|| button2.Text == "수정")
                {
                    UPDATERowUser();
                    UPDATERowCar();
                    this.Close();
                }
                else if(button2.Text == "삭제")
                {
                    DELETERowCar();
                    DELETERowUser();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("비밀번호를 확인해주세요");
            }
        }

        private void initialTextBoxes() //첨 시작 유저정보 (rLook)
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from userinform where u_id=:u_id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("u_id",OracleDbType.Varchar2,20).Value = rlook.getuserID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                userId.Text = Convert.ToString(odr.GetValue(0));
                passwd.Text = Convert.ToString(odr.GetValue(1));
                name.Text = Convert.ToString(odr.GetValue(2));
                pNum.Text = Convert.ToString(odr.GetValue(3));
                email.Text = Convert.ToString(odr.GetValue(4));
            }
            odr.Close();
            odpConn.Close();
        }
        private void initialTextBoxes2() //첨 시작 차 정보 (rLook)
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from carinform where u_id=:u_id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = rlook.getuserID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                carNum.Text = Convert.ToString(odr.GetValue(0));
                carKind.Text = Convert.ToString(odr.GetValue(1));
                carName.Text = Convert.ToString(odr.GetValue(2));
                carSize.Text = Convert.ToString(odr.GetValue(3));
                userId.Text = Convert.ToString(odr.GetValue(4));
            }
            odr.Close();
            odpConn.Close();
        }
        private void initialTextBoxes3() //첨 시작 유저정보 (ulogin)
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from userinform where u_id=:u_id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = ulogin.getUSERID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                userId.Text = Convert.ToString(odr.GetValue(0));
                passwd.Text = Convert.ToString(odr.GetValue(1));
                name.Text = Convert.ToString(odr.GetValue(2));
                pNum.Text = Convert.ToString(odr.GetValue(3));
                email.Text = Convert.ToString(odr.GetValue(4));
            }
            odr.Close();
            odpConn.Close();
        }
        private void initialTextBoxes4() //첨 시작 차 정보 (ulogin)
        {
            odpConn.ConnectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME =xe) ) );";
            odpConn.Open();
            string strqry = "select * from carinform where u_id=:u_id";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("u_id", OracleDbType.Varchar2, 20).Value = ulogin.getUSERID;
            OracleDataReader odr = OraCmd.ExecuteReader();
            while (odr.Read())
            {
                carNum.Text = Convert.ToString(odr.GetValue(0));
                carKind.Text = Convert.ToString(odr.GetValue(1));
                carName.Text = Convert.ToString(odr.GetValue(2));
                carSize.Text = Convert.ToString(odr.GetValue(3));
                userId.Text = Convert.ToString(odr.GetValue(4));
            }
            odr.Close();
            odpConn.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label12.Text = ""; //아이디 중복확인
            label11.Text = ""; //비밀번호 체크

            if (rlook != null) { 
                if (rlook.getstrCommand == "삭제") //rLookUp 속성
                {
                    button2.Text = "삭제";
                    userId.Enabled = false;
                    button1.Enabled = false;
                    initialTextBoxes();
                    initialTextBoxes2();
                }
                else if (rlook.getstrCommand == "업데이트")
                {
                    button2.Text = "업데이트";
                    userId.Enabled = false;
                    name.Enabled = false;
                    button1.Enabled = false;
                    initialTextBoxes();
                    initialTextBoxes2();
                }
                else button2.Text = "추가";
            }
            else if(upark != null)
            {
                    button2.Text = "추가";
            }
            else
            {
                button2.Text = "수정";
                userId.Enabled = false;
                name.Enabled = false;
                button1.Enabled = false;
                initialTextBoxes3();
                initialTextBoxes4();
            }
        }

        private void button2_Click(object sender, EventArgs e) //확인 클릭시
        {
            if (rlook != null) { //rlook 할당 해올 떄
                if (button2.Text == "추가")
                {
                    createUserInform();
                    rlook.list_search("", "");
                }
                else if (button2.Text == "삭제")
                {
                    FixorDelete();
                    rlook.list_search("", "");
                }
                else
                {
                    FixorDelete();
                    rlook.list_search("", "");
                }
            }
            else if (ulogin != null) //ulogin 할당 해올 떄
            {
                    FixorDelete();          
            }
            else {
                if (button2.Text == "추가") //upark 할당 해올 떄
                {
                    createUserInform();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //취소
        {
            Close();
        }
        public bool isValidID(string Text)
        {

            dbc.DA.Fill(dbc.DS,"Table1");

            dbc.Userinform = dbc.DS.Tables["Table1"];

            if (dbc.Userinform.Rows.Count > 0)
            { 
                foreach (DataRow row in dbc.DS.Tables["Table1"].Rows)
                {
                    if (Text == row["u_id"].ToString())
                    {
                        return false;
                    }      
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e) //중복 확인
        {

                if (!isValidID(userId.Text))
                {
                    label12.ForeColor = Color.Red;
                    label12.Text = "아이디가 중복됩니다"; //아이디 중복확인
                }
                else if(userId.Text == "")
                {
                    label12.ForeColor = Color.Red;
                    label12.Text = "아이디를 입력해주세요"; //아이디 중복확인
                }
                else
                {
                    label12.ForeColor = Color.Green;
                    label12.Text = "사용 가능한 아이디 입니다";
                    idcheck = true; // 중복확인 끝나면 true
                }
        }
    }
}
