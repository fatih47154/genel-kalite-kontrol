using KaliteGiris.Bll;
using KaliteGiris.Entities;
using KaliteGiris.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab.WinForms
{
    public partial class frmLab : Form
    {
        private LabTalepManager LabTalepManager { get; set; }
        private FirmaManager FirmaManager { get; set; }
        private PersonelManager PersonelManager { get; set; }
        private DurumManager DurumManager { get; set; }
        private AlimTipiManager AlimTipiManager { get; set; }
        private List<LabTalep> listLab { get; set; }
        private List<Firma> listFirma { get; set; }
        private List<AlimTipi> listAlimTipi { get; set; }
        private List<Personel> listPersonel { get; set; }
        private List<Durum> listDurum { get; set; }

        private LabTalep labTalep { get; set; }

        public frmLab()
        {
            InitializeComponent();
            LabTalepManager = new LabTalepManager();
            FirmaManager =new FirmaManager();
            PersonelManager = new PersonelManager();
            DurumManager = new DurumManager();
            AlimTipiManager = new AlimTipiManager();
        }
        private void frmLab_Load(object sender, EventArgs e)
        {
            LabListGetir();
            gwRenklendir();
            FirmaGetir();
            AlimTipiGetir();
            PersonelGetir();            
            DurumGetir();
            SonucGetir();
            GKKSonucGetir();
        }

        private void gwRenklendir()
        {
           
        }
        private void GKKSonucGetir()
        {
            listDurum = DurumManager.DurumListele();
            //var listFiltered = listDurum.Where(i => i.DurumTipiId == LabEnum.LabDurum);
            var selected = listDurum.Select(x => new { x.DurumId, x.DurumTipiId, x.DurumAdi }).Where(i => i.DurumTipiId == LabEnum.LabSonuc);
            bsGKK.DataSource = selected;
            txtGKKSonucu.Properties.ValueMember = "DurumId";
            txtGKKSonucu.Properties.DisplayMember = "DurumAdi";
            txtGKKSonucu.Properties.PopulateColumns();
            txtGKKSonucu.Properties.Columns["DurumTipiId"].Visible = false;
            txtGKKSonucu.Properties.Columns["DurumId"].Visible = false;
        }
        private void SonucGetir()
        {

            listDurum = DurumManager.DurumListele();
            //var listFiltered = listDurum.Where(i => i.DurumTipiId == LabEnum.LabDurum);
            var selected = listDurum.Select(x => new { x.DurumId, x.DurumTipiId, x.DurumAdi }).Where(i => i.DurumTipiId == LabEnum.LabSonuc);
            bsSonuc.DataSource = selected;
            txtLabSonucu.Properties.ValueMember = "DurumId";
            txtLabSonucu.Properties.DisplayMember = "DurumAdi";
            txtLabSonucu.Properties.PopulateColumns();
            txtLabSonucu.Properties.Columns["DurumTipiId"].Visible = false;
            txtLabSonucu.Properties.Columns["DurumId"].Visible = false;
        }
        private void DurumGetir()
        {
            listDurum = DurumManager.DurumListele();
            //var listFiltered = listDurum.Where(i => i.DurumTipiId == LabEnum.LabDurum);
            var selected = listDurum.Select(x => new { x.DurumId,x.DurumTipiId, x.DurumAdi }).Where(i => i.DurumTipiId == LabEnum.LabDurum);
            bsDurum.DataSource = selected;
            txtLabDurumu.Properties.ValueMember = "DurumId";
            txtLabDurumu.Properties.DisplayMember = "DurumAdi";
            txtLabDurumu.Properties.PopulateColumns();
            txtLabDurumu.Properties.Columns["DurumTipiId"].Visible = false;
            txtLabDurumu.Properties.Columns["DurumId"].Visible = false;
        }
        private void PersonelGetir()
        {
            listPersonel = PersonelManager.PersonelListele();
            var selected = listPersonel.Select(x => new { x.PersonelId, x.Adi });
            bsPersonel.DataSource = selected;
            txtGKKSorumlusu.Properties.ValueMember = "PersonelId";
            txtGKKSorumlusu.Properties.DisplayMember = "Adi";
            txtGKKSorumlusu.Properties.PopulateColumns();
            txtGKKSorumlusu.Properties.Columns["PersonelId"].Visible = false;

        }
        private void AlimTipiGetir()
        {
            listAlimTipi = AlimTipiManager.AlimTipiListele();
            var selected = listAlimTipi.Select(x => new { x.AlimTipiId, x.AlimTipiAdi });
            bsAlimTipi.DataSource = selected;
            txtAlimTipi.Properties.ValueMember = "AlimTipiId";
            txtAlimTipi.Properties.DisplayMember = "AlimTipiAdi";
            txtAlimTipi.Properties.PopulateColumns();
            txtAlimTipi.Properties.Columns["AlimTipiId"].Visible = false;
        }
        private void FirmaGetir()
        {            
            listFirma = FirmaManager.FirmaListele();
            var selected = listFirma.Select(x => new { x.FirmaId, x.FirmaAdi });
            bsFirma.DataSource = selected;
            txtFirmaAdi.Properties.ValueMember = "FirmaId";
            txtFirmaAdi.Properties.DisplayMember = "FirmaAdi";
            txtFirmaAdi.Properties.PopulateColumns();
            txtFirmaAdi.Properties.Columns["FirmaId"].Visible = false;
            //txtFirmaAdi.Properties.Columns["Durum"].Visible = false;
        }
        private void LabListGetir()
        {
            listLab = LabTalepManager.LabTalepListele();
            labTalepBindingSource.DataSource = listLab;
            gcLab.DataSource = labTalepBindingSource;
        }
        private void btnYeni_Click(object sender, EventArgs e)
        {
            //TextleriTemizle();

            labTalep =(LabTalep) labTalepBindingSource.AddNew();
            DateTime Tarih = DateTime.Today;
            string Tarih_str = Tarih.ToString();
            txtTarih.Text = Tarih_str.Substring(0, 10);
            txtRaporTarihi.Text = Tarih_str.Substring(0, 10);
        }
        private void TextleriTemizle()
        {
            txtTarih.Text = "";
            txtRaporTarihi.Text = "";
            Sira.Text = "";                 
            txtFirmaAdi.Text = "";
            txtSözlesmeNo.Text = "";
            txtAlimTipi.Text = "";
            txtMalzeme.Text = "";
            txtIrsaliyeNo.Text = "";
            txtGKKSorumlusu.Text = "";
            txtLabDurumu.Text = "";
            txtLabSonucu.Text = "";
            txtGKKSonucu.Text = "";            
            txtAciklama.Text = "";
            
            txtTarih.Focus();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            KayıtEkle();
            LabListGetir();
            MessageBox.Show("Kayıt Eklendi");
        }
        private int siraArtis()
        {
            int yeniSira;
            int baslangic = 0;
            if (listLab != null)
            {
                foreach (var item in listLab)
                {
                    if (item.Sira > baslangic)
                    {
                        baslangic = item.Sira;
                    }
                }
            }
           
            yeniSira = baslangic + 1;
            return yeniSira;
        }
        private void KayıtEkle()
        {
            bool boscheck = ValidationControlExtendClass.BosAlanKontrol(btnKaydet, txtFirmaAdi, txtIrsaliyeNo, txtSözlesmeNo, txtGKKSorumlusu);
            if (boscheck)
            {
                LabTalep labTalep = new LabTalep();

                labTalep.Sira = siraArtis();//Convert.ToInt16(txtSira.Text);
                labTalep.Tarih = DateTime.Now;
                labTalep.RaporTarihi = DateTime.Now;
                labTalep.FirmaId = new Guid((txtFirmaAdi.EditValue.ToString()));
                labTalep.SozlesmeNo = txtSözlesmeNo.Text;
                labTalep.AlimTipiId = new Guid((txtAlimTipi.EditValue.ToString()));
                labTalep.Malzeme = txtMalzeme.Text;
                labTalep.IrsaliyeNo = txtIrsaliyeNo.Text;
                labTalep.PersonelId = new Guid((txtGKKSorumlusu.EditValue.ToString()));
                labTalep.DurumId = new Guid((txtLabDurumu.EditValue.ToString()));
                labTalep.SonucDurumId = new Guid(txtLabSonucu.EditValue.ToString());
                labTalep.GKKSonucId = new Guid(txtGKKSonucu.EditValue.ToString());
                labTalep.Aciklama = txtAciklama.Text;

                LabTalepManager.LabTalepEkle(labTalep);
            }
            
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            KayıtSil();
            LabListGetir();
            MessageBox.Show("Kayıt Silindi");
        }
        private void KayıtSil()
        {   
            LabTalep labTalep = new LabTalep();
            Guid? secilenLabId = SecilenSatirIdGetir();
            labTalep.LabTalepId = new Guid(secilenLabId.ToString());

            LabTalepManager.LabTalepSil(labTalep);
        }
        private Guid? SecilenSatirIdGetir()
        {
            int row = gwLab.FocusedRowHandle;
            if (row>-1)
            {
                string strlabId = gwLab.GetRowCellValue(row, "LabTalepId").ToString();
                return new Guid(strlabId);
            }
            return null;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            KayıtGuncelle();
            LabListGetir();
            MessageBox.Show("Kayıt Güncellendi");
            
        }
        private void KayıtGuncelle()      
        {
            bool boscheck = ValidationControlExtendClass.BosAlanKontrol(btnKaydet, txtFirmaAdi, txtIrsaliyeNo, txtSözlesmeNo, txtGKKSorumlusu);
            if (boscheck)
            {                
                LabTalep labTalep = new LabTalep();
                Guid? secilenLabId = SecilenSatirIdGetir();
                labTalep.LabTalepId = new Guid(secilenLabId.ToString());

                labTalep.Sira = Convert.ToInt16(txtSira.Text);
                labTalep.Tarih = DateTime.Now;
                labTalep.RaporTarihi = DateTime.Now;
                labTalep.FirmaId = new Guid((txtFirmaAdi.EditValue.ToString()));
                labTalep.SozlesmeNo = txtSözlesmeNo.Text;
                labTalep.AlimTipiId = new Guid((txtAlimTipi.EditValue.ToString()));
                labTalep.Malzeme = txtMalzeme.Text;
                labTalep.IrsaliyeNo = txtIrsaliyeNo.Text;
                labTalep.PersonelId = new Guid((txtGKKSorumlusu.EditValue.ToString()));
                labTalep.DurumId = new Guid((txtLabDurumu.EditValue.ToString()));
                labTalep.SonucDurumId = new Guid(txtLabSonucu.EditValue.ToString());
                labTalep.GKKSonucId = new Guid(txtGKKSonucu.EditValue.ToString());
                labTalep.Aciklama = txtAciklama.Text;

                LabTalepManager.LabTalepGuncelle(labTalep);
         
            }
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            LabListGetir();
        }

        private void bsDurum_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void txtAlimTipi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void bsAlimTipi_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
