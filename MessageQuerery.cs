using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WidjetSobaka
{
    class MessageFormsQuerery
    {
        //Очередь из сообщений
        static private Queue<Form2> messageForms = new Queue<Form2>();

        static private Form1 mainForm;
        static private bool queueAlredyStartPrinting = false;

        //Функция для добавления сообщения в очередь
        /// <summary>
        /// Функция для добавления сообщения в очередь сообщений.
        /// </summary>
        /// <param name="messageText">Текст выводимого сообщения.</param>
        /// <param name="parent">Форма, относительно которой будет вырвниваться окно сообщения.</param>
        static public void AddMessage(string messageText, Form1? parent)
        {
            messageForms.Enqueue(new Form2(messageText, parent));
            if(mainForm == null) mainForm = parent;

            //Проверяется запущена ли очередь сообщений на вывод или нет
            if (!queueAlredyStartPrinting) {
                //Если нет, то ставится флагу queueAlredyStartPrinting значение true
                queueAlredyStartPrinting = true; 
                StartPrintMessages(); 
            }
        }

        //Асинхронный метод отвечающий за вывод сообщений из очереди
        async private static void StartPrintMessages()
        {
            while (messageForms.Count > 0)
            {
                using (Form2 form = messageForms.Dequeue())
                {

                    form.Location = new Point((mainForm.Location.X + mainForm.Size.Width / 2) - form.Size.Width / 2, mainForm.Location.Y - form.Size.Height);
                    form.Show();


                    while (!form.isClosing) { await Task.Delay(1); }
                }
                GC.Collect(2);
            }

            queueAlredyStartPrinting = false;
        }


    }
}
