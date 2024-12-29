using System;
using Renci.SshNet;

namespace proje_3
{
    public class SshManager : IDisposable
    {
        private SshClient sshClient;
        private ShellStream shellStream;

        public bool Baglan(string host, string kullaniciAdi, string sifre)
        {
            try
            {
                sshClient = new SshClient(host, kullaniciAdi, sifre);
                sshClient.Connect();

                if (sshClient.IsConnected)
                {
                    shellStream = sshClient.CreateShellStream("CLI", 0, 0, 0, 0, 1024);
                    
                    Thread.Sleep(500);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public string KomutGonderVeCevapAl(string komut)
        {
            if (sshClient != null && sshClient.IsConnected)
            {
                // Komutu gönder
                shellStream.WriteLine(komut);

                // Cihazdan gelen cevabı oku
                string cevap = "";
                DateTime baslangicZaman = DateTime.Now;
                while (true)
                {
                    string yeniCevap = shellStream.Read();
                    cevap += yeniCevap;

                    if (DateTime.Now.Subtract(baslangicZaman).TotalSeconds >= 1)
                    {
                        break;
                    }
                }

                // Cihazdan gelen cevabı geri döndür
                return cevap;
            }
            else
            {
                return "Bağlantı kurulmamış veya kesilmiş durumda.";
            }
        }
        public string CevapAl( )
        {

            if (sshClient != null && sshClient.IsConnected)
            {               
                // Cihazdan gelen cevabı oku
                string cevap = shellStream.Read();
                Thread.Sleep(500);

                // Cihazdan gelen cevabı geri döndür
                return cevap;
            }
            else
            {
                return "Bağlantı kurulmamış veya kesilmiş durumda.";
            }
        }

        public void Kapat()
        {
            if (sshClient != null && sshClient.IsConnected)
            {
                sshClient.Disconnect();
                //sshClient.Dispose();
            }
            else
            {
                //
            }
        }

        public bool SSHBaglantiVarMi()
        {
            if (sshClient != null && sshClient.IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            Kapat();
        }
    }
}
