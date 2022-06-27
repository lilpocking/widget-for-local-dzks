using System;
using System.Windows.Forms;

namespace WidjetSobaka
{
    public partial class SettingsForm : Form
    {
        private Form1 mainForm;
        public SettingsForm(Form1? parrentForm)
        {
            InitializeComponent();
            mainForm = parrentForm;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            mainForm.Opacity = double.Parse(trackBar1.Value.ToString()) / 100;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.opacityOfMainForm = mainForm.Opacity;
            Settings.SaveSettings();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Settings.LoadSettings();
            trackBar1.Value = (int)(Settings.opacityOfMainForm * 100);
            label1.Text = trackBar1.Value.ToString();
        }
    }
}
