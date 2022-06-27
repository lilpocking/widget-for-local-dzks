using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidjetSobaka
{
    public partial class Form2 : Form
    {
        private bool mouseNotInForm = true;
        private Form1 mainForm;
        private bool isDialog = false;
        private bool changed = false;

        public bool isClosing { get; private set; }

        //Конструктор для обычных сообщений
        public Form2(string text, Form1? parrent)
        {
            InitializeComponent();
            MessageBoxT.Text = text;

            isClosing = false;

            this.mainForm = parrent;
            CheckTextSize();
        }

        //Конструктор, если нужно, чтобы сообщение не пропадало
        public Form2(string text, Form1? parrent, bool isDialog)
        {
            InitializeComponent();
            MessageBoxT.Text = text;

            this.isDialog = isDialog;

            isClosing = false;

            this.mainForm = parrent;
            CheckTextSize();
        }


        //      Блок отдельно прописанные ивенты формы

        private void Form2_LocationChanged(object sender, EventArgs e)
        {
            changed = CheckFormLocation();
        }
        /*
         * Вызвает 2 ассинхронные функции:
         *      1. Меняет расположение формы относительно главной формы
         *      2. Проверяет находиться ли мышь вне формы (отвечает за закрытие формы)
         */
        private void Form2_Shown(object sender, EventArgs e)
        {
            GoToParentForm();
            CheckMouseOutForm();
        }

        //Если мышь зашла в форму, то ставит флаг false
        private void Form2_MouseEnter(object sender, EventArgs e)
        {
            mouseNotInForm = false;
        }

        //Если мышь покинула область формы, то ставит флаг true
        private void Form2_MouseLeave(object sender, EventArgs e)
        {
            mouseNotInForm = true;
        }

        //      Конец блока отдельно прописанных ивентов формы


        //Настройка размера формы под размер текста
        private void CheckTextSize()
        {
            this.Size = new Size(this.Size.Width, MessageBoxT.Size.Height + ((this.Size.Height - flowLayoutPanel1.Height)));
        }

        //Проверка правильно ли расположена форма относительно рабочего стола
        private bool CheckFormLocation()
        {
            int widht = Screen.PrimaryScreen.Bounds.Width;


            bool changed = false;

            if (this.Location.X + this.Size.Width > widht)
            {
                this.Location = new Point(widht - this.Size.Width, this.Location.Y);
                changed = true; 
            }
            return changed;
        }

        //Ассинхронная функция, которая постоянно меняет расположения относително главной формы
        async private void GoToParentForm()
        {
            //Если был использован конструктор с атрибутом isDialog == true, то автоматически прирывает эту функцию
            if (isDialog) return;

            //Если if не сработал, то выполняется следующий код
            while (true)
            {
                if (!changed) this.Location = new Point((mainForm.Location.X + mainForm.Size.Width / 2) - this.Size.Width / 2, mainForm.Location.Y - this.Size.Height);
                changed = CheckFormLocation();
                await Task.Delay(1);
            }
        }

        /*
         * Проверка находится ли мышь в форме или нет
         * Если мышь была убрана, то запускается таймер
         * после истечения которого, запускается исчезновение сообщения
         * 
         * Если мышь снова оказалась на форме, то отменяет исчезновение формы
        */
        async private void CheckMouseOutForm()
        {
            if (isDialog) return;

            while (true)
            {
                await Task.Delay(4500);
                if (mouseNotInForm)
                {
                    while (Opacity > 0 && mouseNotInForm)
                    {
                        Opacity -= 0.03;
                        await Task.Delay(10);
                    }
                    if (Opacity <= 0)
                    {
                        isClosing = true;
                        Close();
                    }
                }
                Opacity = 100;
            }

        }
    }
}
