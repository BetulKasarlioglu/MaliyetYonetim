using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaliyetYonetim.AracDoldur;
using MaliyetYonetim.Siniflar;

namespace MaliyetYonetim
{
    public partial class Malzeme : Form
    {
        public Malzeme()
        {
            InitializeComponent();
            Show();
        }

        private void Malzeme_Load(object sender, EventArgs e)
        {
            new cmbTur(comboBox1);
            new AracMalzemeler().MalzemelerDataGrid(dataGridView1);
        }
        ComboBoxItem cbi;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                return;
            }
            cbi = (ComboBoxItem)comboBox1.SelectedItem;

            new AracDoldur.cmbCins(comboBox3, cbi.Value.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            malzeme = new Malzemeler();
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                malzeme.mmalzemeler = new ModelMalzeme();
                malzeme.mmalzemeler.MalzemeID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (malzeme.Sil())
                    MessageBox.Show("Mazleme Silindi");
                new AracMalzemeler().MalzemelerDataGrid(dataGridView1);

            }
            if (e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                 malzeme.mmalzemeler = new ModelMalzeme();
                 malzeme.mmalzemeler.MalzemeID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                 malzeme.mmalzemeler.TurCinsId = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                 malzeme.mmalzemeler.TurId  = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                 malzeme.mmalzemeler.CinsId = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                 malzeme.mmalzemeler.MalzemeAd = textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                 malzeme.mmalzemeler.BirimFiyat = textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                 malzeme.mmalzemeler.Birim = textBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                 malzeme.mmalzemeler.Adet = textBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                malzeme.mmalzemeler.Aciklama=richTextBox1.Text= dataGridView1.CurrentRow.Cells[10].Value.ToString();
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    cbi = (ComboBoxItem)comboBox1.Items[i];
                    if (cbi.Value.ToString() == malzeme.mmalzemeler.TurId)
                    {
                        comboBox1.SelectedIndex = i;

                    }
                }
                comboIndexSelect(comboBox3, malzeme.mmalzemeler.CinsId, true);
                comboBox1.Enabled = false;
                comboBox3.Enabled = false;
                button1.Text = "GÜNCELLE";
                groupBox1.Text = "Cins Güncelle";

            }
        }
        Malzemeler malzeme;
        private void button1_Click(object sender, EventArgs e)
        {
         
                malzeme = new Malzemeler();
                malzeme.mmalzemeler = new ModelMalzeme();
                ComboBoxItem tur = (ComboBoxItem)comboBox1.Items[comboBox1.SelectedIndex];
                malzeme.mmalzemeler.TurId = tur.Value.ToString();
                ComboBoxItem cins = (ComboBoxItem)comboBox3.Items[comboBox3.SelectedIndex];
                malzeme.mmalzemeler.CinsId = cins.Value.ToString();
                malzeme.mmalzemeler.MalzemeAd = textBox1.Text;
                malzeme.mmalzemeler.BirimFiyat = textBox2.Text;
                malzeme.mmalzemeler.Birim = textBox3.Text;
                malzeme.mmalzemeler.Adet = textBox4.Text;
                malzeme.mmalzemeler.Aciklama = richTextBox1.Text;

                if (txtKontrol())
                {
                    MessageBox.Show("Alanları Doldurunuz");
                    return;
                }
              



            if (button1.Text == "GÜNCELLE")
            {
                malzeme.mmalzemeler.MalzemeID = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                malzeme.Guncelle();
                new AracMalzemeler().MalzemelerDataGrid(dataGridView1);
                button1.Text = "KAYDET";

            }
            else

            if( malzeme.Ekle())
            MessageBox.Show("MAlzemeler Eklendi");
            Temizle();
            new AracMalzemeler().MalzemelerDataGrid(dataGridView1);

        }
      
        void Temizle()
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = "";
                if (item is RichTextBox)
                    ((RichTextBox)item).Text = "";
                if (item is ComboBox)
                    ((ComboBox)item).Text = "";
            }
        }
        bool txtKontrol()
        {
            bool sonuc = false;
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                    if (string.IsNullOrEmpty(((TextBox)item).Text))
                    {
                        sonuc = true;
                        break;
                    }
                if (item is RichTextBox)
                    if (string.IsNullOrEmpty(((RichTextBox)item).Text))
                    {
                        sonuc = true;
                        break;
                    }
                if (item is ComboBox)
                    if (string.IsNullOrEmpty(((ComboBox)item).Text))
                    {
                        sonuc = true;
                        break;
                    }
            }
            return sonuc;
        }
        public void comboIndexSelect(ComboBox cmb, string deger, bool textfalsevaluetrue)
        {
            ComboBoxItem cbi;
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (textfalsevaluetrue)
                {
                    cbi = (ComboBoxItem)cmb.Items[i];
                    if (cbi.Value.ToString() == deger)
                    {
                        cmb.SelectedIndex = i;
                    }
                }
                else
                {
                    cbi = new ComboBoxItem();
                    cbi.Text = cmb.Items[i].ToString();
                    if (cbi.Text.ToString() == deger)
                    {
                        cmb.SelectedIndex = i;
                    }
                }
            }
        }
    }
}
