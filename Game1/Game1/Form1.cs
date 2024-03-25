using Game1.DinamikEngel;
using Game1.HareketsizEngel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public partial class Form1 : Form
    {

        private const int kutuBoyutu = 30; // Her bir ızgara kutusunun boyutu
        private int haritaEn;
        private int haritaBoy;
        private bool haritaOlusturuldu = false;
        private Panel pnlHarita;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GirisEkraniGoster();
            EngelleriYerlestir();
        }

        private void GirisEkraniGoster()
        {
            // Giriş ekranı kodu buraya gelecek
            HaritaBoyutuFormuAc(); // Harita boyutunu kullanıcıdan al
        }

        private void HaritaBoyutuFormuAc()
        {
            Form boyutFormu = new Form();
            boyutFormu.Text = "Harita Boyutu";
            boyutFormu.StartPosition = FormStartPosition.CenterScreen;
            boyutFormu.Size = new Size(300, 200); // Form boyutunu büyüttük

            Label lblEn = new Label();
            lblEn.Text = "Harita En:";
            lblEn.Font = new System.Drawing.Font("Arial", 12);
            lblEn.Location = new System.Drawing.Point(20, 20);
            lblEn.Size = new System.Drawing.Size(160, 20);
            boyutFormu.Controls.Add(lblEn);

            NumericUpDown numEn = new NumericUpDown();
            numEn.Minimum = 5;
            numEn.Maximum = 20;
            numEn.Value = 10;
            numEn.Location = new System.Drawing.Point(180, 20);
            numEn.Size = new System.Drawing.Size(50, 20);
            boyutFormu.Controls.Add(numEn);

            Label lblBoy = new Label();
            lblBoy.Text = "Harita Boy:";
            lblBoy.Font = new System.Drawing.Font("Arial", 12);
            lblBoy.Location = new System.Drawing.Point(20, 50);
            lblBoy.Size = new System.Drawing.Size(160, 20);
            boyutFormu.Controls.Add(lblBoy);

            NumericUpDown numBoy = new NumericUpDown();
            numBoy.Minimum = 5;
            numBoy.Maximum = 20;
            numBoy.Value = 10;
            numBoy.Location = new System.Drawing.Point(180, 50);
            numBoy.Size = new System.Drawing.Size(50, 20);
            boyutFormu.Controls.Add(numBoy);

            Button btnTamam = new Button();
            btnTamam.Text = "Tamam";
            btnTamam.Font = new System.Drawing.Font("Arial", 12);
            btnTamam.Location = new System.Drawing.Point(90, 90);
            btnTamam.Size = new System.Drawing.Size(80, 30);
            btnTamam.Click += (sender, e) =>
            {
                haritaEn = (int)numEn.Value;
                haritaBoy = (int)numBoy.Value;
                boyutFormu.Close();
                if (!haritaOlusturuldu)
                {
                    HaritayiOlustur();
                    haritaOlusturuldu = true;
                }
            };
            boyutFormu.Controls.Add(btnTamam);

            boyutFormu.ShowDialog();
        }

        private void HaritayiOlustur()
        {
            pnlHarita = new Panel();
            pnlHarita.Size = new Size(haritaEn * kutuBoyutu + 20, haritaBoy * kutuBoyutu + 30);
            pnlHarita.Location = new Point((Width - pnlHarita.Width) / 2, (Height - pnlHarita.Height) / 2);
            pnlHarita.BackColor = Color.Transparent; // Harita arka plan rengi

            // Harita üzerine ızgaraları çiz
            for (int i = 0; i < haritaEn; i++)
            {
                for (int j = 0; j < haritaBoy; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(kutuBoyutu, kutuBoyutu);
                    pb.Location = new Point(i * kutuBoyutu, j * kutuBoyutu);
                    pb.BorderStyle = BorderStyle.FixedSingle; // Kutu çerçeve stilini belirle
                    pb.BackColor = Color.Transparent; // Kutu rengini belirle
                    pnlHarita.Controls.Add(pb);
                }
            }

            Controls.Add(pnlHarita);

            // Yeni Harita Oluştur butonu ekle
            Button btnYeniHarita = new Button();
            btnYeniHarita.Text = "Yeni Harita Oluştur";
            btnYeniHarita.Font = new System.Drawing.Font("Arial", 12);
            btnYeniHarita.Location = new System.Drawing.Point(pnlHarita.Right, pnlHarita.Top);
            btnYeniHarita.Size = new System.Drawing.Size(130, 30);
            btnYeniHarita.Click += (sender, e) =>
            {
                HaritaBoyutuFormuAc();
            };
            Controls.Add(btnYeniHarita);

            // Start butonu ekle
            Button btnStart = new Button();
            btnStart.Text = "Start";
            btnStart.Font = new System.Drawing.Font("Arial", 12);
            btnStart.Location = new System.Drawing.Point(pnlHarita.Right, pnlHarita.Top + 40);
            btnStart.Size = new System.Drawing.Size(80, 30);
            btnStart.Click += (sender, e) =>
            {
                // Start butonuna basıldığında yapılacak işlemler buraya gelecek
                // Örneğin, oyunu başlatma veya karakteri hareket ettirme
            };
            Controls.Add(btnStart);

            boyutFormunuGuncelle();
        }



        private void boyutFormunuGuncelle()
        {
            // Boyut formunu güncelle
            Size yeniBoyut = new Size((haritaEn * kutuBoyutu) + 40, (haritaBoy * kutuBoyutu) + 160);
            Size = yeniBoyut;
            pnlHarita.Location = new Point((Width - pnlHarita.Width) / 2, (Height - pnlHarita.Height) / 2);
        }

        private void ResmiIzgaraUzerineYerlestir(PictureBox pictureBox, int x, int y)
        {
            pictureBox.Size = new Size(kutuBoyutu, kutuBoyutu);
            pictureBox.Location = new Point(x * kutuBoyutu, y * kutuBoyutu);
            pictureBox.BackColor = Color.Transparent; // Resmin arka plan rengi
            pnlHarita.Controls.Add(pictureBox);
            pnlHarita.Controls.SetChildIndex(pictureBox, 0); // Resmi en öne getir
        }

        private void EngelleriYerlestir()
        {
            Random random = new Random();
            List<Point> hareketsizEngelKonumlari = new List<Point>(); // Hareketsiz engellerin konumlarını saklamak için liste
            List<Point> dinamikEngelKonumlari = new List<Point>(); // Dinamik engellerin konumlarını saklamak için liste

            // Ağaçları, duvarları, granitleri, dağları ve dinamik engelleri yerleştir
            for (int i = 0; i < haritaEn; i++)
            {
                for (int j = 0; j < haritaBoy; j++)
                {
                    int rastgeleSayi = random.Next(100); // Rastgele sayı üret (0-99 arasında)

                    // Rastgele sayıya göre engel yerleştir
                    if (rastgeleSayi < 18) // %18 ihtimalle engel yerleştir
                    {
                        Point konum = new Point(i, j); // Engelin konumu

                        // Çakışma kontrolü
                        if (!hareketsizEngelKonumlari.Contains(konum) && !dinamikEngelKonumlari.Contains(konum))
                        {
                            if (rastgeleSayi < 3) // %3 ihtimalle yerleştir
                            {
                                PictureBox agac = new PictureBox();
                                agac.Size = new Size(kutuBoyutu, kutuBoyutu); // Resim boyutunu ızgara boyutuna ayarla
                                agac.SizeMode = PictureBoxSizeMode.StretchImage; // Resmi istenen boyuta sıkıştır
                                agac.Image = Image.FromFile(@"C:\Users\DELL\Desktop\Yazlab1 Çalışmaları\Game1\Game1\HareketsizEngelResim\tree.png"); // Ağaç resmi
                                ResmiIzgaraUzerineYerlestir(agac, i, j);
                                hareketsizEngelKonumlari.Add(konum); // Yerleştirilen engelin konumunu hareketsiz engel listesine ekle
                            }
                            else if (rastgeleSayi < 6) // %3 ihtimalle yerleştir
                            {
                                PictureBox duvar = new PictureBox();
                                duvar.Size = new Size(kutuBoyutu, kutuBoyutu);
                                duvar.SizeMode = PictureBoxSizeMode.StretchImage;
                                duvar.Image = Image.FromFile(@"C:\Users\DELL\Desktop\Yazlab1 Çalışmaları\Game1\Game1\HareketsizEngelResim\wall.png"); // Duvar resmi
                                ResmiIzgaraUzerineYerlestir(duvar, i, j);
                                hareketsizEngelKonumlari.Add(konum); // Yerleştirilen engelin konumunu hareketsiz engel listesine ekle
                            }
                            else if (rastgeleSayi < 9) // %3 ihtimalle yerleştir
                            {
                                PictureBox granite = new PictureBox();
                                granite.Size = new Size(kutuBoyutu, kutuBoyutu);
                                granite.SizeMode = PictureBoxSizeMode.StretchImage;
                                granite.Image = Image.FromFile(@"C:\Users\DELL\Desktop\Yazlab1 Çalışmaları\Game1\Game1\HareketsizEngelResim\granite.png"); // granite resmi
                                ResmiIzgaraUzerineYerlestir(granite, i, j);
                                hareketsizEngelKonumlari.Add(konum); // Yerleştirilen engelin konumunu hareketsiz engel listesine ekle
                            }
                            else if (rastgeleSayi < 12) // %3 ihtimalle yerleştir
                            {
                                PictureBox mountain = new PictureBox();
                                mountain.Size = new Size(kutuBoyutu, kutuBoyutu);
                                mountain.SizeMode = PictureBoxSizeMode.StretchImage;
                                mountain.Image = Image.FromFile(@"C:\Users\DELL\Desktop\Yazlab1 Çalışmaları\Game1\Game1\HareketsizEngelResim\mountain.png"); // dağ resmi
                                ResmiIzgaraUzerineYerlestir(mountain, i, j);
                                hareketsizEngelKonumlari.Add(konum); // Yerleştirilen engelin konumunu hareketsiz engel listesine ekle
                            }
                            else // %1 ihtimalle dinamik engel (kuş veya arı) yerleştir
                            {
                                if (rastgeleSayi < 15) // %3 ihtimalle yerleştir
                                {
                                    Kuslar kus = new Kuslar("Kuş", new Size(2, 2), i, j);

                                    PictureBox kusPictureBox = new PictureBox();
                                    kusPictureBox.Size = new Size(kutuBoyutu, kutuBoyutu);
                                    kusPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                    kusPictureBox.Image = Image.FromFile(@"C:\Users\DELL\Desktop\Yazlab1 Çalışmaları\Game1\Game1\DinamikEngelResim\bird.png"); // Kuş resmi
                                    ResmiIzgaraUzerineYerlestir(kusPictureBox, i, j);
                                    dinamikEngelKonumlari.Add(konum); // Yerleştirilen engelin konumunu hareketsiz engel listesine ekle

                                    Timer kusTimer = new Timer();
                                    kusTimer.Interval = 500; // Her 0.5 saniyede bir hareket et
                                    kusTimer.Tick += (sender, e) =>
                                    {
                                        kus.HareketEt();

                                        // Kuşların yeni konumunu güncelle
                                        kusPictureBox.Location = new Point(kus.X * kutuBoyutu, kus.Y * kutuBoyutu);
                                    };
                                    kusTimer.Start();
                                }
                                else if (rastgeleSayi < 18) // %3 ihtimalle yerleştir
                                {
                                    Arilar arı = new Arilar("Arı", new Size(2, 2), i, j);

                                    PictureBox arıPictureBox = new PictureBox();
                                    arıPictureBox.Size = new Size(kutuBoyutu, kutuBoyutu);
                                    arıPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                    arıPictureBox.Image = Image.FromFile(@"C:\Users\DELL\Desktop\Yazlab1 Çalışmaları\Game1\Game1\DinamikEngelResim\bee.png"); // Arı resmi
                                    ResmiIzgaraUzerineYerlestir(arıPictureBox, i, j);
                                    dinamikEngelKonumlari.Add(konum); // Yerleştirilen engelin konumunu hareketsiz engel listesine ekle

                                    Timer arıTimer = new Timer();
                                    arıTimer.Interval = 500; // Her 0.5 saniyede bir hareket et
                                    arıTimer.Tick += (sender, e) =>
                                    {
                                        arı.HareketEt();

                                        // Arıların yeni konumunu güncelle
                                        arıPictureBox.Location = new Point(arı.X * kutuBoyutu, arı.Y * kutuBoyutu);
                                    };
                                    arıTimer.Start();
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}





