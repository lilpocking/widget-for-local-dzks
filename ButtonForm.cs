using System;
using System.Windows.Forms;

namespace WidjetSobaka
{
    public partial class ButtonForm : Form
    {
        public bool buttonIsPressed;
        public ButtonForm(string TextOnButton)
        {
            InitializeComponent();
            button1.Text = TextOnButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonIsPressed = true;
        }
    }
}
