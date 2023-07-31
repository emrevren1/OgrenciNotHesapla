using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace VizeSinavi
{
    public partial class Form1 : Form
    {
        int ogrencisayisi;
        string sistem;
        double[] ortalama;
        string[] sira, ogrno, ograd, ogrsoyad, BBN;
        int[] vize, final, butunleme;
        int i = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ogrencisayisi = int.Parse(Interaction.InputBox("Kaç Öğrenci Girilecek ? ", "Öğrenci sayısını giriniz"));
            sistem = Interaction.InputBox("Hangi sistemde not gösterilecek ? (100lüksistem veya bagilsistem) yazınız.", "Hangi Sistem");
            ortalama = new double[ogrencisayisi];
            sira = new string[ogrencisayisi];
            ogrno = new string[ogrencisayisi];
            ograd = new string[ogrencisayisi];
            ogrsoyad = new string[ogrencisayisi];
            BBN = new string[ogrencisayisi];
            vize = new int[ogrencisayisi];
            final = new int[ogrencisayisi];
            butunleme = new int[ogrencisayisi];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                sira[i] = textBox1.Text;
                ogrno[i] = textBox2.Text;
                ograd[i] = textBox3.Text;
                ogrsoyad[i] = textBox4.Text;
                vize[i] = int.Parse(textBox5.Text);
                final[i] = int.Parse(textBox6.Text);
                butunleme[i] = int.Parse(textBox7.Text);
                MessageBox.Show("Kayıt Başarılı.");
                i++;
                label9.Text = "Kaç Öğrenci Daha Girilecek : " + (ogrencisayisi - i).ToString();
            }
            if (label9.Text == "0")
                MessageBox.Show("Öğrenci Kayıtları tamamlandı.");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double sinifortalamasi = 0;
            foreach (double a in ortalama)
                sinifortalamasi += a;
            sinifortalamasi /= ogrencisayisi;
            for (int i = 0; i < ogrencisayisi; i++)
            {
                ortalama[i] = vize[i] * 0.4 + final[i] * 0.6;
                ortalama[i] = (ortalama[i] + butunleme[i]) / 2;
                if (sistem == "100lüksistem")
                {
                    ortalama[i] = ortalama[i];
                    BBN[i] = "";
                }
                else if (sistem == "bagilsistem")
                {
                    if (ortalama[i] <= 100 && ortalama[i] >= 70) BBN[i] = "AA";
                    else if (ortalama[i] <= 70 && ortalama[i] > 60) BBN[i] = "BA";
                    else if (ortalama[i] <= 60 && ortalama[i] > 50) BBN[i] = "BB";
                    else if (ortalama[i] <= 50 && ortalama[i] > 45) BBN[i] = "CB";
                    else if (ortalama[i] <= 45 && ortalama[i] > 40) BBN[i] = "CC";
                    else if (ortalama[i] <= 40 && ortalama[i] > 30) BBN[i] = "DC";
                    else if (ortalama[i] <= 30 && ortalama[i] > 20) BBN[i] = "DD";
                    else if (ortalama[i] <= 20) BBN[i] = "FF";
                    else MessageBox.Show("Giriş hatası var.");
                }
                else MessageBox.Show("Giriş hatalı.");
            }
            int h = 0;
            while (h < ogrencisayisi)
            {
                listBox1.Items.Add("Öğrenci Numarası = " + ogrno[h]);
                listBox1.Items.Add("Öğrenci Adı = " + ograd[h]);
                listBox1.Items.Add("Öğrenci Soyadı = " + ogrsoyad[h]);
                listBox1.Items.Add("Vize = " + vize[h]);
                listBox1.Items.Add("Final = " + final[h]);
                listBox1.Items.Add("Bütünleme = " + butunleme[h]);
                listBox1.Items.Add("BBN = " + BBN[h]);
                h++;
            }
            MessageBox.Show("Kayıt Başarılı.");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string hangi = Interaction.InputBox("Aramak istediğiniz öğrencinin okul no giriniz", "Hangi öğrenci");
            int index = Array.IndexOf(ogrno, hangi);
            textBox1.Text = sira[index];
            textBox2.Text = ogrno[index];
            textBox3.Text = ograd[index];
            textBox4.Text = ogrsoyad[index];
            textBox5.Text = vize[index].ToString();
            textBox6.Text = final[index].ToString();
            textBox7.Text = butunleme[index].ToString();
            textBox8.Text = BBN[index];
        }
    }
}
