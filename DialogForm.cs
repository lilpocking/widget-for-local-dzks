using System.Threading.Tasks;
using System.Drawing;

namespace WidjetSobaka
{
    class DialogForm
    {
        private Form1? mainForm;
        private Form2 textForm;
        public ButtonForm button;


        public DialogForm(string text,string textOnButton ,Form1? parent)
        {
            mainForm = parent;

            textForm = new Form2(text, parent, true);
            

            button = new ButtonForm(textOnButton);
        }

        async public void ShowDialog()
        {

            button.Size = new Size(textForm.Size.Width, button.Size.Height);
            button.Location = new Point((mainForm.Location.X + mainForm.Size.Width / 2) - button.Size.Width / 2, mainForm.Location.Y - button.Size.Height);

            textForm.Location = new Point(button.Location.X, button.Location.Y - textForm.Size.Height);

            button.Show();
            textForm.Show();

            while (true)
            {
                button.Location = new Point((mainForm.Location.X + mainForm.Size.Width / 2) - button.Size.Width / 2, mainForm.Location.Y - button.Size.Height);
                textForm.Location = new Point(button.Location.X, button.Location.Y - textForm.Size.Height);

                await Task.Delay(1);
            }

        }
        public void Close()
        {
            textForm.Close();
            button.Close();
        }
        ~DialogForm() { }
    }
}
