using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Export;
using DevExpress.XtraTab;

namespace Lab.WinForms
{

    public static class ValidationControlExtendClass
    {

        //button
        public static bool BosAlanKontrol(this Button buton, params Control[] controls)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            bool status = true;

            foreach (Control control in controls)
            {
                status = myControl(control);

                if (status == false)
                {
                    errorProvider.SetError(control, "Boş Geçilemez");
                    return status;
                }
                else
                {
                    errorProvider.Clear();
                }
            }

            return status;
        }

        //barbutton
    /*    public static bool BosAlanKontrol(this BarButtonItem buton, params Control[] controls)
        {
            bool status = true;

            ErrorProvider errorProvider = new ErrorProvider();

            foreach (Control control in controls)
            {
                status = myControl(control);

                if (status == false)
                {
                    errorProvider.SetError(control, "Boş Geçilemez");
                    return status;
                }
                else
                {

                }

            }

            return status;
        } */

        //simple button
        public static bool BosAlanKontrol(this SimpleButton buton, params Control[] controls)
        {
            bool status = true;

            ErrorProvider errorProvider = new ErrorProvider();

            foreach (Control control in controls)
            {
                status = myControl(control);

                if (status == false)
                {
                    errorProvider.SetError(control, "Boş Geçilemez");
                    return status;
                }
                else
                {

                }

            }

            return status;
        }

        //userkontrol
        public static bool BosAlanKontrol(this UserControl userControl, params Control[] controls)
        {
            bool status = true;

            ErrorProvider errorProvider = new ErrorProvider();

            foreach (Control control in controls)
            {
                status = myControl(control);

                if (status == false)
                {
                    errorProvider.SetError(control, "Boş Geçilemez");
                    return status;
                }
                else
                {

                }

            }

            return status;
        }
        static bool TextBoxKontrolEt(Control control)
        {
            bool status = true;
            if (control.Text.Trim() == "")
            {
                control.BackColor = Color.Red;
                status = false;
            }
            else
            {
                control.BackColor = Color.White;
                status = true;
            }
            return status;
        }
        static bool TextEditKontrolEt(Control control)
        {
            bool status = true;
            if (control.Text.Trim() == "")
            {
                control.BackColor = Color.Red;
                status = false;
            }
            else
            {
                control.BackColor = Color.White;
                status = true;
            }
            return status;
        }
        static bool DataEditKontrolEt(Control control)
        {

            DateEdit dateEdit = (DateEdit)control;

            bool status = true;
            if (dateEdit.Text.Trim() == "")
            {
                control.BackColor = Color.Red;
                status = false;
            }
            else
            {
                control.BackColor = Color.White;
                status = true;
            }
            return status;
        }
        static bool LookUpEditKontrolEt(Control control)
        {
            LookUpEdit lookUpEdit = (LookUpEdit)control;

            bool status = true;
            if (lookUpEdit.Text.Trim() == "")
            {
                control.BackColor = Color.Red;
                status = false;
            }
            else
            {
                control.BackColor = Color.White;
                status = true;
            }
            return status;
        }

        private static bool DateTimePickerKontrol(Control control)
        {
            bool status = false;

            DateTimePicker dateTimePicker = (DateTimePicker)control;

            if (dateTimePicker.Value == DateTime.MinValue)
            {
                dateTimePicker.BackColor = Color.Red;
                status = true;
            }
            else
            {
                dateTimePicker.BackColor = Color.White;
            }
            return status;
        }

        private static bool ComboBoxEditKontrol(Control control)
        {
            bool status = true;
            if (control.Text.Trim() == "")
            {
                control.BackColor = Color.Red;
                status = false;
            }
            else
            {
                control.BackColor = Color.White;
                status = true;
            }
            return status;
        }

        static bool myControl(Control control)
        {
            //control şarta uyuyorsa true
            bool status = true;

            if (control is Label)
            {
                // status = KontrolEt(control);
            }

            if (control is TextBox)
            {
                status = TextBoxKontrolEt(control);
            }
            if (control is TextEdit)
            {
                status = TextEditKontrolEt(control);
            }
            if (control is LookUpEdit)
            {
                status = LookUpEditKontrolEt(control);
            }

            if (control is CheckBox)
            {

            }
            if (control is RadioButton)
            {

            }

            if (control is TabPage)
            {

            }
            if (control is GroupBox)
            {

            }

            if (control is ToolStrip)
            {

            }

            if (control is MenuStrip)
            {

            }

            if (control is SimpleButton)
            {

            }
            if (control is LabelControl)
            {
                // status = KontrolEt(control);
            }
            if (control is CheckEdit)
            {

            }
            if (control is RadioGroup)
            {

            }
            if (control is CheckedListBox)
            {

            }
            if (control is XtraTabControl)
            {

            }
            if (control is DevExpress.XtraTab.XtraTabPage)
            {

            }

            if (control is LinkLabel)
            {

                // status = KontrolEt(control);
            }

            if (control is DateEdit)
            {
                status = DataEditKontrolEt(control);
            }


            if (control is DateTimePicker)
            {
                status = DateTimePickerKontrol(control);
            }
            if (control is ComboBoxEdit)
            {
                status = ComboBoxEditKontrol(control);
            }


            return status;
        }


    }
}
