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

        //cihaz bilgileri için listeler oluþturur
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



        private void KAYDET_Click(object sender, EventArgs e) // giriþ cihaz kayýtý için 
        {

            KaydetIsleminiYap();

        }
        private void KaydetIsleminiYap()
        {
            if (sshManager.Baglan(serverip.Text, kadi.Text, sifre.Text)) // yanlýþ baðlantý bilgileri ile cihaz eklenememesi için kontrol
            {
                textBox5.AppendText($"{cihazisim.Text} cihazýnýz listeye baþarýyla eklenmiþtir.\r\n");  //###################################################
                sshManager.Kapat();
                // textbox lardan alýnan verþleri lýstelere ekler 
                sship = serverip.Text; // cihaz baðlantý ipsini tutma
                cihazisimlist.Add(cihazisim.Text);
                sifrelerlist.Add(sifre.Text);
                kullaniciAdilist.Add(kadi.Text);
                hostliste.Add(serverip.Text);
                portliste.Add(Int32.Parse(portno.Text));
                konsolsifrelist.Add(consolesifre.Text);

                //cihaz bilgilerinin bulunduðu grupboxý kaydedip içindeki textleri siler.
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is System.Windows.Forms.TextBox)
                    {
                        ((System.Windows.Forms.TextBox)control).Text = string.Empty;
                    }
                }
                cihazlarýekleme();
            }
            else
            {
                MessageBox.Show("Baðlantý hatasý.");
            }

        }
        private void cihazlarýekleme()
        {
            groupBox3.Controls.Clear();

            int x = 25; // X konumu
            int y = 30; // Y konumu

            // Grup kutularý ekleme döngüsü
            for (int i = 0; i < cihazisimlist.Count(); i++)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = cihazisimlist[i];
                groupBox.Location = new System.Drawing.Point(x, y); // Belirlenen konuma göre yerleþtirme
                groupBox.Size = new System.Drawing.Size(151, 122); // Grup kutusu boyutu
                groupBox.Name = cihazisimlist[i];
                groupBox.Enabled = true;

                // PictureBox oluþturma ve ayarlama
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new System.Drawing.Point(20, 20); // PictureBox'ýn konumu (GroupBox içinde)
                pictureBox.Size = new System.Drawing.Size(100, 100); // PictureBox boyutu
                pictureBox.Name = cihazisimlist[i];
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.MouseDoubleClick += PictureBox_MouseDoubleClick;
                pictureBox.Image = Image.FromFile("D:/OKUL/BAU-PROJE-1/VÝSUAL VODE BAÐLANTI/PROJE/proje-9.HAFTA/proje_3/router.jpg"); // Örnek bir resim atamasý (projenizin kaynaklarýndan bir resim seçin)

                // Grup kutusuna PictureBox ekleme
                groupBox.Controls.Add(pictureBox);

                // groupBox3'ün Controls koleksiyonuna grup kutusunu ekleme
                groupBox3.Controls.Add(groupBox);

                // Sonraki grup kutusunun konumunu güncelleme
                if (x == 347)
                {
                    x = 25;
                    y += 161;
                }
                else
                {
                    x += 161;
                }
                //x += 161; // X konumunu artýrarak bir sonraki grup kutusunu yan yana yerleþtirme
            }
            // Kaydet iþlemini gerçekleþtiren kod
        }
        private void PictureBox_MouseDoubleClick(object? sender, MouseEventArgs e)
        {

            OutputTextBox.Clear(); // cll temizlik  #########################
            // resme iki kere týklandýðýnda cihaz ismini listede aratýr ve indexsini bulur ve bu index numarasý ile cihazýn tüm bilgilerini çeker
            PictureBox clickedPictureBox = (PictureBox)sender;
            string pictureBoxName = clickedPictureBox.Name;
            int sýra = cihazisimlist.IndexOf(pictureBoxName);
            string host = hostliste[sýra];
            string kullaniciAdi = kullaniciAdilist[sýra];
            string sifre = sifrelerlist[sýra];
            string konsole = konsolsifrelist[sýra];

            if (sshManager.Baglan(host, kullaniciAdi, sifre))
            {
                textBox5.AppendText($"{cihazisimlist[sýra]} Baðlantý baþarýlý.\r\n");  //###################################################
            }
            else
            {
                MessageBox.Show("Baðlantý hatasý.");
            }

            string cevap = sshManager.KomutGonderVeCevapAl($"terminal length 0\nen\n{konsole}");
            OutputTextBox.AppendText(cevap);
            arayuz = sshManager.KomutGonderVeCevapAl($"sh ip int brief"); // cihaz interface ipilerini cekip arayuz adlý deðikene atar.

            comboBox2.Items.Clear(); // ##############################
            comboBox2.Text = "";
            int0text.Text = ""; // ########################
            interfaceNames.Clear(); // ###############################


            // interface isimlerini alma ve ekleme
            string[] lines = arayuz.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries); // arayüzeleri içerisindeki veriyi parcalama

            foreach (string line in lines)
            {
                // Satýrý boþluk karakterlerine göre böleriz
                string[] parts = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Ýlk parça arayüz adýný içerir
                string interfaceName = parts[0];

                // "Interface" kelimesini atlamak için kontrol ediyoruz
                int index = interfaceName.IndexOf('#');
                string cihazisim = "";

                if (index != -1)
                {
                    cihazisim = interfaceName.Substring(0, index + 1); // '#' dahil almak için index + 1
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
        private void gonder_Click(object sender, EventArgs e) // ############################# cll direket komut gönderme
        {
            string komut = gondertext.Text;
            if (gondertext.Text == "")
            {
                string normal = sshManager.CevapAl();
                cllkomut(normal);
            }
            else
            {
                // Komutu gönder ve cevabý al
                string cevap = sshManager.KomutGonderVeCevapAl(komut);
                // Cevabý TextBox'a yazdýr
                gondertext.Text = "";
                cllkomut(cevap);
            }
        }
        private void kayýt_Click(object sender, EventArgs e) // ############################
        {
            if (saat.Text != "")
            {
                string saat1 = saat.Text;
                string komut = $"clock set {saat1}";
                //clock set 11:09:20 mar 7 2024

                string cevap = sshManager.KomutGonderVeCevapAl(komut);

                // Cevabý TextBox'a yazdýr
                cllkomut(cevap);
                saat.Text = "";
            }
            if (isimm.Text != "")
            {
                string isim = isimm.Text;
                string komut = $"conf t\n hostname {isim}\n end";

                // Komutu gönder ve cevabý al
                string cevap = sshManager.KomutGonderVeCevapAl(komut);
                // Cevabý TextBox'a yazdýr
                cllkomut(cevap);
                isimm.Text = "";
            }

        }
        private void cllkomut(string cevap)  // komut takip ekranýna gönderme ve en aþaðý inme
        {
            OutputTextBox.AppendText(cevap);
            OutputTextBox.SelectionStart = OutputTextBox.Text.Length;
            OutputTextBox.ScrollToCaret();
        }

        private void gondertext_KeyDown(object sender, KeyEventArgs e) // cll enter tuþuna basýldýðýnda otomatik gönderme
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuþuna basýldýðýnda yapýlmasýný istediðiniz iþlemleri burada gerçekleþtirin
                // Örneðin:
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
                int0text.Text = "NO ÝP ADRESS";
            }

        }

        private void kayýt1_Click(object sender, EventArgs e)
        {

            if (iptext == sship)
            {
                DialogResult result = MessageBox.Show("Deðiþtirmek istediðiniz ip üzerinden ssh baðlantýsý yapýlmaktadýr deðiþtirmeniz durumunda shh baðlantýnýz kopacaktýr?", "Evet/Hayýr", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kullanýcýnýn seçimine göre iþlem yapabilirsiniz
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("ip adresiniz deðiþtirildi Baðlantý kopltu !");
                    string secimler = comboBox2.SelectedItem.ToString();

                    string ip = int0text.Text;
                    string[] ipandsub = ip.Split('/');
                    int subnet = Convert.ToInt32(ipandsub[1]);
                    string komut = $"conf t\n int {secimler}\n no sh\n ip address {ipandsub[0]} {SubnetUzunluguToSubnetMask(subnet)}\nend";
                    // Komutu gönder ve cevabý al
                    string cevap = sshManager.KomutGonderVeCevapAl(komut);

                    // Cevabý TextBox'a yazdýr
                    cllkomut(cevap);

                    int hangiindex = hostliste.IndexOf(sship);
                    textBox1.Text = hangiindex.ToString();



                    cihazisimlist.RemoveAt(hangiindex);
                    sifrelerlist.RemoveAt(hangiindex);
                    kullaniciAdilist.RemoveAt(hangiindex);
                    hostliste.RemoveAt(hangiindex);
                    portliste.RemoveAt(hangiindex);
                    konsolsifrelist.RemoveAt(hangiindex);

                    cihazlarýekleme();
                    //KAYDET_Click(object sender, EventArgs e);
                }
                else
                {
                    MessageBox.Show("ip adresi deðiþtirilmedi");
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
            // 32 bitlik bir subnet maský temsil etmek için kullanýlan 32 bitlik bir unsigned integer
            uint mask = 0;

            // Belirtilen sayýda biti ayarlayýn
            for (int i = 0; i < subnetUzunlugu; i++)
            {
                mask |= (uint)(1 << (31 - i));
            }

            // Subnet maskýný dört parçaya ayýrýn ve "." ile birleþtirin
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
                        // Ýlk sekme seçildiðinde yapýlacaklar
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


                        // Ýkinci sekme seçildiðinde yapýlacaklar
                        break;
                        // ... ve diðer sekmeler için
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
        string degiþken;
        string degiþken2;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            degiþken = comboBox3.SelectedItem.ToString();
            string secint = comboBox3.SelectedItem.ToString();
            string detay = sshManager.KomutGonderVeCevapAl($"sh running-config | section dhcp pool {secint}");
            cllkomut(detay);
            //textBox9.AppendText(detay);

            string[] satirlar = detay.Split('\n');

            foreach (string i in satirlar)
            {
                textBox9.AppendText(i + "\n");
            }

            // Her satýrý iþlemek için bir döngü
            foreach (string satir in satirlar)
            {
                textBox9.AppendText("\r\n");
                // Satýrdaki anahtar kelimeleri ve deðerleri ayýrmak için bir dizi
                string[] kelimeler = satir.Split(' ');



                // Anahtar kelimelere göre iþlem yapmak
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
            degiþken2 = comboBox4.SelectedItem.ToString();
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
            string detay = sshManager.KomutGonderVeCevapAl($"conf t \n no ip dhcp pool {degiþken}\nend");
            cllkomut(detay);           
            

            if (textBox7.Text != "")
            {

                string detay2 = sshManager.KomutGonderVeCevapAl($"conf t \n no  ip dhcp excluded-address {degiþken2}\nend");
                cllkomut(detay2);
            }
            tabControl1_SelectedIndexChanged(sender, e);

        }
    }
}





