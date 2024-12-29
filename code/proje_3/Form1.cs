using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.DataFormats;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.LinkLabel;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.NetworkInformation;
namespace proje_3
{
    public partial class Form1 : Form
    {
        private SshManager sshManager;

        public Form1()
        {
            InitializeComponent();
            sshManager = new SshManager();
        }

        //cihaz bilgileri i�in listeler olu�turur
        List<string> cihazisimlist = new List<string>();
        List<string> sifrelerlist = new List<string>();
        List<string> kullaniciAdilist = new List<string>();
        List<string> hostliste = new List<string>();
        List<int> portliste = new List<int>();
        List<string> konsolsifrelist = new List<string>();

        List<string> interfaceNames = new List<string>();
        List<string> poolNames = new List<string>();
        List<string> excluded = new List<string>();


        string arayuz;
        string iptext;
        string sship;



        private void KAYDET_Click(object sender, EventArgs e) // giri� cihaz kay�t� i�in 
        {

            KaydetIsleminiYap();

        }
        private void KaydetIsleminiYap()
        {
            if (sshManager.Baglan(serverip.Text, kadi.Text, sifre.Text)) // yanl�� ba�lant� bilgileri ile cihaz eklenememesi i�in kontrol
            {
                textBox5.AppendText($"{cihazisim.Text} cihaz�n�z listeye ba�ar�yla eklenmi�tir.\r\n");  //###################################################
                sshManager.Kapat();
                // textbox lardan al�nan ver�leri l�stelere ekler 
                sship = serverip.Text; // cihaz ba�lant� ipsini tutma
                cihazisimlist.Add(cihazisim.Text);
                sifrelerlist.Add(sifre.Text);
                kullaniciAdilist.Add(kadi.Text);
                hostliste.Add(serverip.Text);
                portliste.Add(Int32.Parse(portno.Text));
                konsolsifrelist.Add(consolesifre.Text);

                //cihaz bilgilerinin bulundu�u grupbox� kaydedip i�indeki textleri siler.
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is System.Windows.Forms.TextBox)
                    {
                        ((System.Windows.Forms.TextBox)control).Text = string.Empty;
                    }
                }
                cihazlar�ekleme();
            }
            else
            {
                MessageBox.Show("Ba�lant� hatas�.");
            }

        }
        private void cihazlar�ekleme()
        {
            groupBox3.Controls.Clear();

            int x = 25; // X konumu
            int y = 30; // Y konumu

            // Grup kutular� ekleme d�ng�s�
            for (int i = 0; i < cihazisimlist.Count(); i++)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = cihazisimlist[i];
                groupBox.Location = new System.Drawing.Point(x, y); // Belirlenen konuma g�re yerle�tirme
                groupBox.Size = new System.Drawing.Size(151, 122); // Grup kutusu boyutu
                groupBox.Name = cihazisimlist[i];
                groupBox.Enabled = true;

                // PictureBox olu�turma ve ayarlama
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new System.Drawing.Point(20, 20); // PictureBox'�n konumu (GroupBox i�inde)
                pictureBox.Size = new System.Drawing.Size(100, 100); // PictureBox boyutu
                pictureBox.Name = cihazisimlist[i];
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.MouseDoubleClick += PictureBox_MouseDoubleClick;
                pictureBox.Image = Image.FromFile("D:/OKUL/BAU-PROJE-1/V�SUAL VODE BA�LANTI/PROJE/proje-9.HAFTA/proje_3/router.jpg"); // �rnek bir resim atamas� (projenizin kaynaklar�ndan bir resim se�in)

                // Grup kutusuna PictureBox ekleme
                groupBox.Controls.Add(pictureBox);

                // groupBox3'�n Controls koleksiyonuna grup kutusunu ekleme
                groupBox3.Controls.Add(groupBox);

                // Sonraki grup kutusunun konumunu g�ncelleme
                if (x == 347)
                {
                    x = 25;
                    y += 161;
                }
                else
                {
                    x += 161;
                }
                //x += 161; // X konumunu art�rarak bir sonraki grup kutusunu yan yana yerle�tirme
            }
            // Kaydet i�lemini ger�ekle�tiren kod
        }
        private void PictureBox_MouseDoubleClick(object? sender, MouseEventArgs e)
        {

            OutputTextBox.Clear(); // cll temizlik  #########################
            // resme iki kere t�kland���nda cihaz ismini listede arat�r ve indexsini bulur ve bu index numaras� ile cihaz�n t�m bilgilerini �eker
            PictureBox clickedPictureBox = (PictureBox)sender;
            string pictureBoxName = clickedPictureBox.Name;
            int s�ra = cihazisimlist.IndexOf(pictureBoxName);
            string host = hostliste[s�ra];
            string kullaniciAdi = kullaniciAdilist[s�ra];
            string sifre = sifrelerlist[s�ra];
            string konsole = konsolsifrelist[s�ra];

            if (sshManager.Baglan(host, kullaniciAdi, sifre))
            {
                textBox5.AppendText($"{cihazisimlist[s�ra]} Ba�lant� ba�ar�l�.\r\n");  //###################################################
            }
            else
            {
                MessageBox.Show("Ba�lant� hatas�.");
            }

            string cevap = sshManager.KomutGonderVeCevapAl($"terminal length 0\nen\n{konsole}");
            OutputTextBox.AppendText(cevap);
            arayuz = sshManager.KomutGonderVeCevapAl($"sh ip int brief"); // cihaz interface ipilerini cekip arayuz adl� de�ikene atar.

            comboBox2.Items.Clear(); // ##############################
            comboBox2.Text = "";
            int0text.Text = ""; // ########################
            interfaceNames.Clear(); // ###############################


            // interface isimlerini alma ve ekleme
            string[] lines = arayuz.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries); // aray�zeleri i�erisindeki veriyi parcalama

            foreach (string line in lines)
            {
                // Sat�r� bo�luk karakterlerine g�re b�leriz
                string[] parts = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // �lk par�a aray�z ad�n� i�erir
                string interfaceName = parts[0];

                // "Interface" kelimesini atlamak i�in kontrol ediyoruz
                int index = interfaceName.IndexOf('#');
                string cihazisim = "";

                if (index != -1)
                {
                    cihazisim = interfaceName.Substring(0, index + 1); // '#' dahil almak i�in index + 1
                }

                if (interfaceName != "Interface" && interfaceName != "sh" && interfaceName != cihazisim)
                {
                    interfaceNames.Add(interfaceName);
                }
            }

            foreach (string i in interfaceNames)
            {
                comboBox2.Items.Add(i);
            }

        }
        private void gonder_Click(object sender, EventArgs e) // ############################# cll direket komut g�nderme
        {
            string komut = gondertext.Text;
            if (gondertext.Text == "")
            {
                string normal = sshManager.CevapAl();
                cllkomut(normal);
            }
            else
            {
                // Komutu g�nder ve cevab� al
                string cevap = sshManager.KomutGonderVeCevapAl(komut);
                // Cevab� TextBox'a yazd�r
                gondertext.Text = "";
                cllkomut(cevap);
            }
        }
        private void kay�t_Click(object sender, EventArgs e) // ############################
        {
            if (saat.Text != "")
            {
                string saat1 = saat.Text;
                string komut = $"clock set {saat1}";
                //clock set 11:09:20 mar 7 2024

                string cevap = sshManager.KomutGonderVeCevapAl(komut);

                // Cevab� TextBox'a yazd�r
                cllkomut(cevap);
                saat.Text = "";
            }
            if (isimm.Text != "")
            {
                string isim = isimm.Text;
                string komut = $"conf t\n hostname {isim}\n end";

                // Komutu g�nder ve cevab� al
                string cevap = sshManager.KomutGonderVeCevapAl(komut);
                // Cevab� TextBox'a yazd�r
                cllkomut(cevap);
                isimm.Text = "";
            }

        }
        private void cllkomut(string cevap)  // komut takip ekran�na g�nderme ve en a�a�� inme
        {
            OutputTextBox.AppendText(cevap);
            OutputTextBox.SelectionStart = OutputTextBox.Text.Length;
            OutputTextBox.ScrollToCaret();
        }

        private void gondertext_KeyDown(object sender, KeyEventArgs e) // cll enter tu�una bas�ld���nda otomatik g�nderme
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tu�una bas�ld���nda yap�lmas�n� istedi�iniz i�lemleri burada ger�ekle�tirin
                // �rne�in:
                gonder_Click(sender, e);

                gondertext.Text = "";
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string secint = comboBox2.SelectedItem.ToString();
            string detay = sshManager.KomutGonderVeCevapAl($"show ip interface {secint}");
            //textBox1.Text = SubnetUzunluguToSubnetMask(24);
            string pattern = @"Internet address is (\d+\.\d+\.\d+\.\d+)/(\d+)";
            Match match = Regex.Match(detay, pattern);
            if (match.Success)
            {
                string ipAddressWithSubnetMask = match.Groups[1].Value + "/" + match.Groups[2].Value;
                int0text.Text = ipAddressWithSubnetMask;
                string[] ipsubnet = ipAddressWithSubnetMask.Split('/');
                iptext = ipsubnet[0];
                //textBox1.Text = iptext;
            }
            else
            {
                int0text.Text = "NO �P ADRESS";
            }

        }

        private void kay�t1_Click(object sender, EventArgs e)
        {

            if (iptext == sship)
            {
                DialogResult result = MessageBox.Show("De�i�tirmek istedi�iniz ip �zerinden ssh ba�lant�s� yap�lmaktad�r de�i�tirmeniz durumunda shh ba�lant�n�z kopacakt�r?", "Evet/Hay�r", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kullan�c�n�n se�imine g�re i�lem yapabilirsiniz
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("ip adresiniz de�i�tirildi Ba�lant� kopltu !");
                    string secimler = comboBox2.SelectedItem.ToString();

                    string ip = int0text.Text;
                    string[] ipandsub = ip.Split('/');
                    int subnet = Convert.ToInt32(ipandsub[1]);
                    string komut = $"conf t\n int {secimler}\n no sh\n ip address {ipandsub[0]} {SubnetUzunluguToSubnetMask(subnet)}\nend";
                    // Komutu g�nder ve cevab� al
                    string cevap = sshManager.KomutGonderVeCevapAl(komut);

                    // Cevab� TextBox'a yazd�r
                    cllkomut(cevap);

                    int hangiindex = hostliste.IndexOf(sship);
                    textBox1.Text = hangiindex.ToString();



                    cihazisimlist.RemoveAt(hangiindex);
                    sifrelerlist.RemoveAt(hangiindex);
                    kullaniciAdilist.RemoveAt(hangiindex);
                    hostliste.RemoveAt(hangiindex);
                    portliste.RemoveAt(hangiindex);
                    konsolsifrelist.RemoveAt(hangiindex);

                    cihazlar�ekleme();
                    //KAYDET_Click(object sender, EventArgs e);
                }
                else
                {
                    MessageBox.Show("ip adresi de�i�tirilmedi");
                }
            }
            else
            {
                string secimler = comboBox2.SelectedItem.ToString();

                string ip = int0text.Text;
                string[] ipandsub = ip.Split('/');
                int subnet = Convert.ToInt32(ipandsub[1]);
                string komut = $"conf t\n int {secimler}\n no sh\n ip address {ipandsub[0]} {SubnetUzunluguToSubnetMask(subnet)}\nend";
                string cevap = sshManager.KomutGonderVeCevapAl(komut);
                cllkomut(cevap);
            }
        }

        static string SubnetUzunluguToSubnetMask(int subnetUzunlugu)
        {
            // 32 bitlik bir subnet mask� temsil etmek i�in kullan�lan 32 bitlik bir unsigned integer
            uint mask = 0;

            // Belirtilen say�da biti ayarlay�n
            for (int i = 0; i < subnetUzunlugu; i++)
            {
                mask |= (uint)(1 << (31 - i));
            }

            // Subnet mask�n� d�rt par�aya ay�r�n ve "." ile birle�tirin
            string subnetMask = $"{(mask >> 24) & 255}.{(mask >> 16) & 255}.{(mask >> 8) & 255}.{mask & 255}";

            return subnetMask;
        }


        private void poolnamebul(string text)
        {

            // Regex pattern to match pool name declarations
            string pattern = @"ip dhcp pool (?<name>\w+)";

            // Match all occurrences of the pattern in the text
            MatchCollection matches = Regex.Matches(text, pattern);

            // Extract pool names from matches and add them to the list
            foreach (Match match in matches)
            {
                string poolName = match.Groups["name"].Value;
                poolNames.Add(poolName);
            }

        }

        private void excludedbul(string text)
        {

            // Regex pattern to match pool name declarations
            string pattern = @"ip dhcp excluded-address (?<name>\S+.*)";

            // Match all occurrences of the pattern in the text
            MatchCollection matches = Regex.Matches(text, pattern);

            // Extract pool names from matches and add them to the list
            foreach (Match match in matches)
            {
                string poolName = match.Groups["name"].Value;
                excluded.Add(poolName);
            }

        }




        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            poolNames.Clear();
            excluded.Clear();

            int selectedIndex = tabControl1.SelectedIndex;

            if (sshManager.SSHBaglantiVarMi())
            {
                switch (selectedIndex)
                {
                    case 0:
                        // �lk sekme se�ildi�inde yap�lacaklar
                        break;
                    case 4:
                        string komut = $"sh running-config | section dhcp pool";
                        string cevap = sshManager.KomutGonderVeCevapAl(komut);
                        cllkomut(cevap);
                        poolnamebul(cevap);
                        string komut2 = $"sh running-config | section dhcp excluded";
                        string cevap2 = sshManager.KomutGonderVeCevapAl(komut2);
                        cllkomut(cevap2);
                        excludedbul(cevap2);


                        // �kinci sekme se�ildi�inde yap�lacaklar
                        break;
                        // ... ve di�er sekmeler i�in
                }
            }
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            foreach (string i in poolNames)
            {
                comboBox3.Items.Add(i);
            }
            foreach (string i in excluded)
            {
                comboBox4.Items.Add(i);
            }




        }
        string degi�ken;
        string degi�ken2;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            degi�ken = comboBox3.SelectedItem.ToString();
            string secint = comboBox3.SelectedItem.ToString();
            string detay = sshManager.KomutGonderVeCevapAl($"sh running-config | section dhcp pool {secint}");
            cllkomut(detay);
            //textBox9.AppendText(detay);

            string[] satirlar = detay.Split('\n');

            foreach (string i in satirlar)
            {
                textBox9.AppendText(i + "\n");
            }

            // Her sat�r� i�lemek i�in bir d�ng�
            foreach (string satir in satirlar)
            {
                textBox9.AppendText("\r\n");
                // Sat�rdaki anahtar kelimeleri ve de�erleri ay�rmak i�in bir dizi
                string[] kelimeler = satir.Split(' ');



                // Anahtar kelimelere g�re i�lem yapmak
                if (kelimeler.Count() > 4)
                {
                    if (kelimeler[5] == "pool")
                    {
                        textBox2.Text = kelimeler[6];
                    }
                }

                if (kelimeler.Count() > 1)
                {
                    if (kelimeler[1] == "network")
                    {
                        textBox3.Text = kelimeler[2] + " " + kelimeler[3];
                    }
                    if (kelimeler[1] == "default-router")
                    {
                        textBox4.Text = kelimeler[2];
                    }
                    if (kelimeler[1] == "dns-server")
                    {
                        textBox6.Text = kelimeler[2];
                    }
                }

            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            degi�ken2 = comboBox4.SelectedItem.ToString();
            string secint = comboBox4.SelectedItem.ToString();
            textBox7.Text = secint;
        }

        private void dhcpbutton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {

                string detay = sshManager.KomutGonderVeCevapAl($"conf t \n ip dhcp pool {textBox2.Text} \n network {textBox3.Text} \n default-router {textBox4.Text}\n dns-server {textBox6.Text}\n end");
                cllkomut(detay);
            }
            if (textBox7.Text != "")
            {

                string detay = sshManager.KomutGonderVeCevapAl($"conf t \n ip dhcp excluded-address {textBox7.Text}\nend");
                cllkomut(detay);
            }

            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void dhcpsil_Click(object sender, EventArgs e)
        {
            string detay = sshManager.KomutGonderVeCevapAl($"conf t \n no ip dhcp pool {degi�ken}\nend");
            cllkomut(detay);           
            

            if (textBox7.Text != "")
            {

                string detay2 = sshManager.KomutGonderVeCevapAl($"conf t \n no  ip dhcp excluded-address {degi�ken2}\nend");
                cllkomut(detay2);
            }
            tabControl1_SelectedIndexChanged(sender, e);

        }
    }
}





