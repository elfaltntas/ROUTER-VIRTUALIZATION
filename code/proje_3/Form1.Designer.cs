namespace proje_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            serverip = new TextBox();
            label1 = new Label();
            portno = new TextBox();
            label2 = new Label();
            kadi = new TextBox();
            label3 = new Label();
            sifre = new TextBox();
            label4 = new Label();
            groupBox1 = new GroupBox();
            KAYDET = new Button();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label11 = new Label();
            label6 = new Label();
            consolesifre = new TextBox();
            cihazisim = new TextBox();
            groupBox2 = new GroupBox();
            textBox5 = new TextBox();
            OutputTextBox = new TextBox();
            groupBox3 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            gonder = new Button();
            gondertext = new TextBox();
            tabPage3 = new TabPage();
            label9 = new Label();
            label8 = new Label();
            saat = new TextBox();
            isimm = new TextBox();
            kayıt = new Button();
            tabPage4 = new TabPage();
            textBox1 = new TextBox();
            comboBox2 = new ComboBox();
            kayıt1 = new Button();
            int0text = new TextBox();
            tabPage5 = new TabPage();
            dhcpsil = new Button();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label10 = new Label();
            label7 = new Label();
            textBox9 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            dhcpbutton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // serverip
            // 
            serverip.Location = new Point(117, 26);
            serverip.Margin = new Padding(2);
            serverip.Name = "serverip";
            serverip.Size = new Size(121, 27);
            serverip.TabIndex = 0;
            serverip.Text = "192.168.100.63";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 28);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(21, 20);
            label1.TabIndex = 1;
            label1.Text = "İP";
            // 
            // portno
            // 
            portno.Location = new Point(117, 70);
            portno.Margin = new Padding(2);
            portno.Name = "portno";
            portno.Size = new Size(121, 27);
            portno.TabIndex = 0;
            portno.Text = "22";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 72);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 1;
            label2.Text = "PORT";
            // 
            // kadi
            // 
            kadi.Location = new Point(386, 30);
            kadi.Margin = new Padding(2);
            kadi.Name = "kadi";
            kadi.Size = new Size(146, 27);
            kadi.TabIndex = 0;
            kadi.Text = "ali";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(251, 30);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 1;
            label3.Text = "USERNAME";
            // 
            // sifre
            // 
            sifre.Location = new Point(386, 72);
            sifre.Margin = new Padding(2);
            sifre.Name = "sifre";
            sifre.Size = new Size(146, 27);
            sifre.TabIndex = 0;
            sifre.Text = "veli";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(248, 74);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 1;
            label4.Text = "PASSWORD";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(KAYDET);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(serverip);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(consolesifre);
            groupBox1.Controls.Add(cihazisim);
            groupBox1.Controls.Add(portno);
            groupBox1.Controls.Add(kadi);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(sifre);
            groupBox1.Location = new Point(22, 16);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(556, 208);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "SHH BİLGİLERİ";
            // 
            // KAYDET
            // 
            KAYDET.Location = new Point(251, 160);
            KAYDET.Margin = new Padding(2);
            KAYDET.Name = "KAYDET";
            KAYDET.Size = new Size(280, 27);
            KAYDET.TabIndex = 6;
            KAYDET.Text = "KAYDET";
            KAYDET.UseVisualStyleBackColor = true;
            KAYDET.Click += KAYDET_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ROUTER", "SWİTCH" });
            comboBox1.Location = new Point(386, 108);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(146, 28);
            comboBox1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(244, 114);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 1;
            label5.Text = "CİHAZ TÜRÜ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(20, 160);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(102, 20);
            label11.TabIndex = 1;
            label11.Text = "ENABLE ŞİFRE";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 114);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 1;
            label6.Text = "CİHAZ İSİM";
            // 
            // consolesifre
            // 
            consolesifre.Location = new Point(133, 160);
            consolesifre.Margin = new Padding(2);
            consolesifre.Name = "consolesifre";
            consolesifre.Size = new Size(105, 27);
            consolesifre.TabIndex = 0;
            consolesifre.Text = "ali";
            // 
            // cihazisim
            // 
            cihazisim.Location = new Point(117, 112);
            cihazisim.Margin = new Padding(2);
            cihazisim.Name = "cihazisim";
            cihazisim.Size = new Size(121, 27);
            cihazisim.TabIndex = 0;
            cihazisim.Text = "R1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox5);
            groupBox2.Location = new Point(22, 526);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(556, 110);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "OLAY TAKİP";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(20, 31);
            textBox5.Margin = new Padding(2);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(512, 68);
            textBox5.TabIndex = 3;
            // 
            // OutputTextBox
            // 
            OutputTextBox.Location = new Point(23, 14);
            OutputTextBox.Margin = new Padding(2);
            OutputTextBox.Multiline = true;
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ScrollBars = ScrollBars.Vertical;
            OutputTextBox.Size = new Size(559, 504);
            OutputTextBox.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.AutoSize = true;
            groupBox3.Location = new Point(22, 229);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(556, 293);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "CİHAZLARIM";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(10, 10);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(606, 701);
            tabControl1.TabIndex = 10;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(598, 668);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "GİRİŞ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(gonder);
            tabPage2.Controls.Add(gondertext);
            tabPage2.Controls.Add(OutputTextBox);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(598, 668);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "CLL";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // gonder
            // 
            gonder.Location = new Point(433, 537);
            gonder.Margin = new Padding(2);
            gonder.Name = "gonder";
            gonder.Size = new Size(149, 27);
            gonder.TabIndex = 5;
            gonder.Text = "GÖNDER";
            gonder.UseVisualStyleBackColor = true;
            gonder.Click += gonder_Click;
            // 
            // gondertext
            // 
            gondertext.Location = new Point(23, 539);
            gondertext.Margin = new Padding(2);
            gondertext.Name = "gondertext";
            gondertext.Size = new Size(362, 27);
            gondertext.TabIndex = 4;
            gondertext.KeyDown += gondertext_KeyDown;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(saat);
            tabPage3.Controls.Add(isimm);
            tabPage3.Controls.Add(kayıt);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(598, 668);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "TEMEL AYARLAR";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(53, 18);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(44, 20);
            label9.TabIndex = 2;
            label9.Text = "SAAT";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(53, 58);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 2;
            label8.Text = "CİHAZ İSMİ";
            // 
            // saat
            // 
            saat.Location = new Point(157, 18);
            saat.Margin = new Padding(2);
            saat.Name = "saat";
            saat.Size = new Size(186, 27);
            saat.TabIndex = 1;
            // 
            // isimm
            // 
            isimm.Location = new Point(155, 58);
            isimm.Margin = new Padding(2);
            isimm.Name = "isimm";
            isimm.Size = new Size(186, 27);
            isimm.TabIndex = 1;
            // 
            // kayıt
            // 
            kayıt.Location = new Point(487, 557);
            kayıt.Margin = new Padding(2);
            kayıt.Name = "kayıt";
            kayıt.Size = new Size(90, 27);
            kayıt.TabIndex = 0;
            kayıt.Text = "KAYDET";
            kayıt.UseVisualStyleBackColor = true;
            kayıt.Click += kayıt_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(textBox1);
            tabPage4.Controls.Add(comboBox2);
            tabPage4.Controls.Add(kayıt1);
            tabPage4.Controls.Add(int0text);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(2);
            tabPage4.Size = new Size(598, 668);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "ARA YÜZLER";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 180);
            textBox1.Margin = new Padding(2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(446, 384);
            textBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(80, 24);
            comboBox2.Margin = new Padding(2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(177, 28);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // kayıt1
            // 
            kayıt1.Location = new Point(259, 587);
            kayıt1.Margin = new Padding(2);
            kayıt1.Name = "kayıt1";
            kayıt1.Size = new Size(90, 27);
            kayıt1.TabIndex = 2;
            kayıt1.Text = "KAYDET";
            kayıt1.UseVisualStyleBackColor = true;
            kayıt1.Click += kayıt1_Click;
            // 
            // int0text
            // 
            int0text.Location = new Point(287, 24);
            int0text.Margin = new Padding(2);
            int0text.Name = "int0text";
            int0text.Size = new Size(239, 27);
            int0text.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(dhcpsil);
            tabPage5.Controls.Add(comboBox4);
            tabPage5.Controls.Add(comboBox3);
            tabPage5.Controls.Add(label14);
            tabPage5.Controls.Add(label13);
            tabPage5.Controls.Add(label12);
            tabPage5.Controls.Add(label10);
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(textBox9);
            tabPage5.Controls.Add(textBox7);
            tabPage5.Controls.Add(textBox6);
            tabPage5.Controls.Add(textBox4);
            tabPage5.Controls.Add(textBox3);
            tabPage5.Controls.Add(textBox2);
            tabPage5.Controls.Add(dhcpbutton);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(598, 668);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "DHCP-SERVER";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // dhcpsil
            // 
            dhcpsil.Location = new Point(452, 129);
            dhcpsil.Name = "dhcpsil";
            dhcpsil.Size = new Size(94, 29);
            dhcpsil.TabIndex = 4;
            dhcpsil.Text = "SİL";
            dhcpsil.UseVisualStyleBackColor = true;
            dhcpsil.Click += dhcpsil_Click;
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.Simple;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(22, 308);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(542, 108);
            comboBox4.TabIndex = 3;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.Simple;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(439, 30);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(125, 108);
            comboBox3.TabIndex = 3;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(22, 208);
            label14.Name = "label14";
            label14.Size = new Size(132, 20);
            label14.TabIndex = 2;
            label14.Text = "EXCLUDED ADRES";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 162);
            label13.Name = "label13";
            label13.Size = new Size(96, 20);
            label13.TabIndex = 2;
            label13.Text = "DNS-SERVER";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 116);
            label12.Name = "label12";
            label12.Size = new Size(127, 20);
            label12.TabIndex = 2;
            label12.Text = "DEFAULT ROUTER";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 76);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 2;
            label10.Text = "NETWORK";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 33);
            label7.Name = "label7";
            label7.Size = new Size(92, 20);
            label7.TabIndex = 2;
            label7.Text = "POOL NAME";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(33, 456);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(531, 124);
            textBox9.TabIndex = 1;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(173, 205);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(222, 27);
            textBox7.TabIndex = 1;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(173, 159);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(222, 27);
            textBox6.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(173, 113);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(222, 27);
            textBox4.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(173, 73);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(222, 27);
            textBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(173, 30);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(222, 27);
            textBox2.TabIndex = 1;
            // 
            // dhcpbutton
            // 
            dhcpbutton.Location = new Point(483, 600);
            dhcpbutton.Name = "dhcpbutton";
            dhcpbutton.Size = new Size(94, 29);
            dhcpbutton.TabIndex = 0;
            dhcpbutton.Text = "KAYDET";
            dhcpbutton.UseVisualStyleBackColor = true;
            dhcpbutton.Click += dhcpbutton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 720);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CİHAZ KAYIT";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox serverip;
        private Label label1;
        private TextBox portno;
        private Label label2;
        private TextBox kadi;
        private Label label3;
        private TextBox sifre;
        private Label label4;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private TextBox cihazisim;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button KAYDET;
        private TextBox OutputTextBox;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button gonder;
        private TextBox gondertext;
        private Button kayıt;
        private Label label8;
        private TextBox isimm;
        private Label label9;
        private TextBox saat;
        private TabPage tabPage4;
        private TextBox int0text;
        private Button kayıt1;
        private TextBox textBox5;
        private Label label11;
        private TextBox consolesifre;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private TabPage tabPage5;
        private Label label13;
        private Label label12;
        private Label label10;
        private Label label7;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Button dhcpbutton;
        private Label label14;
        private TextBox textBox7;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private TextBox textBox9;
        private Button dhcpsil;
    }
}
