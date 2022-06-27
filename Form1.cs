using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WidjetSobaka
{
    public partial class Form1 : Form
    {
        private bool drag = false;
        private Point divForm;
        static public readonly string UriPathBackend = "http://localhost:5224";
        static public readonly string serverAddress = "127.0.0.1";
        static public readonly int serverPort = 8888;
        public Form1()
        {
            InitializeComponent();

            Settings.LoadSettings();

            this.Opacity = Settings.opacityOfMainForm;

            this.MouseUp += (s, e) => { drag = false; };
            this.MouseLeave += (s, e) => { drag = false; };
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (Form1.MouseButtons)
            {
                case MouseButtons.Left:
                    divForm = new Point(this.Location.X - MousePosition.X, this.Location.Y - MousePosition.Y);
                    drag = true;
                    break;
                case MouseButtons.Right:
                    if (Settings.isFirstStart) DollState_Guider.rightMouseButtonIsPressed = true;
                    contextMenuStrip1.Show((this.Location.X + this.Size.Width / 2) - contextMenuStrip1.Size.Width / 2, this.Location.Y + this.Size.Height);
                    break;
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag && !Settings.isFirstStart)
            {
                contextMenuStrip1.Close();
                this.Location = new Point(this.Location.X + e.X + divForm.X, this.Location.Y + e.Y + divForm.Y);
                CheckFormLocation();
            }
        }

        //Проверка расположения формы относительно рабочего стола
        private void CheckFormLocation()
        {
            int widht = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            if ((this.Location.X + this.Size.Width) > widht)
            {
                this.Location = new Point(widht - this.Size.Width, this.Location.Y);
            }
            else if (this.Location.X < 0) this.Location = new Point(0, this.Location.Y);

            if ((this.Location.Y + this.Size.Height) > height)
            {
                this.Location = new Point(this.Location.X, height - this.Size.Height);
            }
            else if (this.Location.Y < 0) this.Location = new Point(this.Location.X, 0);
        }

        //Отмена закрытия формы пользователем с помощью Alt+F4
        //Отмена попытки закрытия формы с помощью TaskManager
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
                case CloseReason.TaskManagerClosing:
                    e.Cancel = true;
                    break;
            }
        }

        //Обработка нажатия, на всплывающем окне, кнопки "Нужна помощь"
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Settings.isFirstStart) DollState_Guider.helpButtonIsPressed = true;
            System.Diagnostics.Process.Start("https://ru.wikipedia.org");
        }

        //Обработка нажатия, на всплывающем окне, кнопки "Нужна помощь"
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Settings.isFirstStart) DollState_Guider.pcInfoIsPreassed = true;
            string mess = $"Название ПК: {Environment.MachineName}{Environment.NewLine}{Environment.NewLine}Имя пользователя: {Environment.UserName}";

            MessageFormsQuerery.AddMessage(mess, this);
        }

        //Обработка закрытия всплывающего окна
        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case ToolStripDropDownCloseReason.AppFocusChange:
                    e.Cancel = true;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double scalible = Screen.PrimaryScreen.Bounds.Width * 100 / 1920;

            this.Width = (int)(96 * scalible / 100);
            this.Height = (int)(96 * scalible / 100);

            Settings.LoadSettings();
            if (Settings.isFirstStart)
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2);
                DollState_Guider.StartBeginnerGuide(this);
            }
            else
            {
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Size.Width, (Screen.PrimaryScreen.Bounds.Height * 95 / 100) - this.Size.Height);
            }

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\wallpaper.jpg"))
            {
                WebClient client = new WebClient();
                Uri uri = new Uri(UriPathBackend + "/wallpaper");
                if (uri.IsWellFormedOriginalString())
                {
                    client.DownloadFileAsync(uri, "wallpaper.jpg");
                }
            }
            else
            {
                NativeMethods.SetWallpaper(Directory.GetCurrentDirectory() + "\\wallpaper.jpg", NativeMethods.Style.Centered, 0);
            }

            NativeMethods.ConnectingToServer();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.Show();
        }
    }
}
