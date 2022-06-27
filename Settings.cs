using System;
using System.IO;
using System.Xml.Serialization;

namespace WidjetSobaka
{
    [Serializable]
    public class SettingsClass
    {
        public SettingsClass() { }
        public SettingsClass(bool isFirstStart, double opacity)
        {
            this.isFirstStart = isFirstStart;
            this.opacityOfMainForm = opacity;
        }
        public bool isFirstStart;
        public double opacityOfMainForm;
    }

    public class Settings
    {
        static private string pathToSettings = "settings.xml";

        static public bool isFirstStart;
        static public double opacityOfMainForm;
        static SettingsClass settings = new SettingsClass();
        static public void LoadSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsClass));

            if (!File.Exists(pathToSettings))
            {
                settings = new SettingsClass(true, 1d);
                using (FileStream fileStream = new FileStream(pathToSettings, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fileStream, settings);
                }
            }
            else //Иначе читает настройки из файла
            {
                using (FileStream fileStream = new FileStream(pathToSettings, FileMode.Open))
                {
                    settings = serializer.Deserialize(fileStream) as SettingsClass;
                }
            }

            isFirstStart = settings.isFirstStart;
            opacityOfMainForm = settings.opacityOfMainForm;
        }
        static public void SaveSettings()
        {
            settings.isFirstStart = isFirstStart;
            settings.opacityOfMainForm = opacityOfMainForm;

            XmlSerializer serializer = new XmlSerializer(typeof(SettingsClass));
            using (FileStream fileStream = new FileStream(pathToSettings, FileMode.Create))
            {
                serializer.Serialize(fileStream, settings);
            }
        }
    }
}
