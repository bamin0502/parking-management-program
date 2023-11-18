
namespace WindowsFormsApp1
{
    partial class uInfrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.carSize = new System.Windows.Forms.TextBox();
            this.carName = new System.Windows.Forms.TextBox();
            this.passwd = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.carKind = new System.Windows.Forms.TextBox();
            this.userId = new System.Windows.Forms.TextBox();
            this.passwordck = new System.Windows.Forms.TextBox();
            this.pNum = new System.Windows.Forms.TextBox();
            this.carNum = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 533);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "확인";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 533);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "취소";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.carSize);
            this.groupBox1.Controls.Add(this.carName);
            this.groupBox1.Controls.Add(this.passwd);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.carKind);
            this.groupBox1.Controls.Add(this.userId);
            this.groupBox1.Controls.Add(this.passwordck);
            this.groupBox1.Controls.Add(this.pNum);
            this.groupBox1.Controls.Add(this.carNum);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 502);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "회원 정보";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 58;
            this.button1.Text = "중복 확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(244, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 12);
            this.label12.TabIndex = 57;
            this.label12.Text = "※ 중복이면 뜰 메세지";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(204, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 12);
            this.label11.TabIndex = 56;
            this.label11.Text = "※ 틀리면 오류라고 뜰 메세지";
            // 
            // carSize
            // 
            this.carSize.Location = new System.Drawing.Point(127, 448);
            this.carSize.Name = "carSize";
            this.carSize.Size = new System.Drawing.Size(242, 21);
            this.carSize.TabIndex = 46;
            // 
            // carName
            // 
            this.carName.Location = new System.Drawing.Point(127, 404);
            this.carName.Name = "carName";
            this.carName.Size = new System.Drawing.Size(242, 21);
            this.carName.TabIndex = 47;
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(127, 134);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(242, 21);
            this.passwd.TabIndex = 49;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(127, 281);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(242, 21);
            this.email.TabIndex = 48;
            // 
            // carKind
            // 
            this.carKind.Location = new System.Drawing.Point(127, 363);
            this.carKind.Name = "carKind";
            this.carKind.Size = new System.Drawing.Size(242, 21);
            this.carKind.TabIndex = 50;
            // 
            // userId
            // 
            this.userId.Location = new System.Drawing.Point(127, 67);
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(148, 21);
            this.userId.TabIndex = 52;
            // 
            // passwordck
            // 
            this.passwordck.Location = new System.Drawing.Point(127, 176);
            this.passwordck.Name = "passwordck";
            this.passwordck.Size = new System.Drawing.Size(242, 21);
            this.passwordck.TabIndex = 54;
            // 
            // pNum
            // 
            this.pNum.Location = new System.Drawing.Point(127, 240);
            this.pNum.Name = "pNum";
            this.pNum.Size = new System.Drawing.Size(242, 21);
            this.pNum.TabIndex = 51;
            // 
            // carNum
            // 
            this.carNum.Location = new System.Drawing.Point(127, 323);
            this.carNum.Name = "carNum";
            this.carNum.Size = new System.Drawing.Size(242, 21);
            this.carNum.TabIndex = 53;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(127, 30);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(148, 21);
            this.name.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "차량 크기";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "차량 이름";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 12);
            this.label10.TabIndex = 40;
            this.label10.Text = "비밀번호 확인";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 366);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "차량 종류";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "비밀번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "차량번호";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "이메일";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "전화번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "이름";
            // 
            // uInfrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "uInfrom";
            this.Text = "사용자 회원정보";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox carSize;
        private System.Windows.Forms.TextBox carName;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox carKind;
        private System.Windows.Forms.TextBox userId;
        private System.Windows.Forms.TextBox passwordck;
        private System.Windows.Forms.TextBox pNum;
        private System.Windows.Forms.TextBox carNum;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}