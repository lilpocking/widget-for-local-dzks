using System;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace WidjetSobaka
{
    class DollState_Guider
    {
        //Events checkers
        static public bool rightMouseButtonIsPressed = false;
        static public bool helpButtonIsPressed = false;
        static public bool pcInfoIsPreassed = false;

        //Старт обучения
        async static public void StartBeginnerGuide(Form1? mainForm)
        {
            Settings.LoadSettings();
            //Начало гайда
            if (mainForm == null) return;
            {
                DialogForm dialog = new DialogForm("Привет я твой помощник!", "Привет", mainForm);
                dialog.ShowDialog();
                while (!dialog.button.buttonIsPressed) { await Task.Delay(1); }
                dialog.Close();
            }
            //Гайд по нажатию ПКМ по главной форме
            {
                rightMouseButtonIsPressed = false;
                Form2 form2 = new Form2($"Попробуй нажать на меня правой кнопкой мыши, чтобы открыть меню.{Environment.NewLine}Нажмите, чтобы продолжить.", mainForm, true);
                form2.Show();

                while (!rightMouseButtonIsPressed) { form2.Location = new System.Drawing.Point((mainForm.Location.X + mainForm.Size.Width / 2) - form2.Size.Width / 2, mainForm.Location.Y - form2.Size.Height); ; await Task.Delay(1); }
                form2.Close();

            }
            //Гайд по информации о нажатии на конпку Нудна помощь
            {
                helpButtonIsPressed = false;
                Form2 form2 = new Form2($"При нажатии на [Нужна помощь] откроется сайт, где вы сможете обратиться за помощью к техподдержке.{Environment.NewLine}Нажмите, чтобы продолжить.", mainForm, true);
                form2.Show();

                while (!helpButtonIsPressed) { form2.Location = new System.Drawing.Point((mainForm.Location.X + mainForm.Size.Width / 2) - form2.Size.Width / 2, mainForm.Location.Y - form2.Size.Height); ; await Task.Delay(1); }
                form2.Close();
            }
            //Гайд по информации о компьютере
            {
                pcInfoIsPreassed = false;
                Form2 form2 = new Form2($"При нажатии [Информация об компьютере], вы можете получить название вашего компьютера.{Environment.NewLine}Нажмите, чтобы продолжить.", mainForm, true);
                form2.Show();

                while (!pcInfoIsPreassed) { form2.Location = new System.Drawing.Point((mainForm.Location.X + mainForm.Size.Width / 2) - form2.Size.Width / 2, mainForm.Location.Y - form2.Size.Height); ; await Task.Delay(1); }
                form2.Close();
            }


            //Анимация смещение главной формы в нормально позицию
            Point endPoint = new Point(Screen.PrimaryScreen.Bounds.Width - mainForm.Size.Width, (Screen.PrimaryScreen.Bounds.Height * 95 / 100) - mainForm.Size.Height);
            Point nowPoint = new Point(mainForm.Location.X, mainForm.Location.Y);

            Point vectorOfNowAndEndPoints = new Point(endPoint.X - nowPoint.X, endPoint.Y - nowPoint.Y);

            float lenght = (float)Math.Abs(Math.Sqrt(Math.Pow(endPoint.X - nowPoint.X, 2) + Math.Pow(endPoint.Y - nowPoint.Y, 2)));

            //Определение сколько нужно прибавлять
            float addX = vectorOfNowAndEndPoints.X / lenght;
            float addY = vectorOfNowAndEndPoints.Y / lenght;
            //Скорость смещения главной формы
            float speed = 10.4f;

            //Запуск анимации
            while ((mainForm.Location.X  < endPoint.X) && (mainForm.Location.Y + mainForm.Size.Height < Screen.PrimaryScreen.Bounds.Height))
            {
                mainForm.Location = new Point((int)(Math.Round(mainForm.Location.X + addX * speed)), (int)(Math.Round(mainForm.Location.Y + addY * speed)));
                //~60-т кадров в секунду
                await Task.Delay(16);
            }

            //Сохранение настроек
            Settings.isFirstStart = false;
            Settings.SaveSettings();
        }
    }
}
