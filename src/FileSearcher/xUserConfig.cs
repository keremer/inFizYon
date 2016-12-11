using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.IO;
using System.Windows.Forms;



namespace FileSearcher
{
    public class UserConfigData
    {
        // ----- Variables -----

        private Int32 m_locationX = 100;
        private Int32 m_locationY = 100;
        private Int32 m_width = 528;
        private Int32 m_height = 551;
        private Int32 m_windowState = 0;

        private String m_searchDir = "C:\\";
        private Boolean m_includeSubDirsChecked = true;
        private String m_fileName = "*.*";
        private Boolean m_newerThanChecked = false;
        private DateTime m_newerThanDateTime = new DateTime(2012, 1, 1, 0, 0, 0);
        private Boolean m_olderThanChecked = false;
        private DateTime m_olderThanDateTime = new DateTime(2012, 1, 1, 0, 0, 0);
        private Boolean m_containingChecked = false;
        private String m_containingText = "";
        private Boolean m_asciiChecked = true;
        private Boolean m_unicodeChecked = false;
        private String m_delimeter = ";";
        private String m_resultsFilePath = "";


        // ----- Public Properties -----

        public Int32 LocationX
        {
            get { return m_locationX; }
            set { m_locationX = value; }
        }

        public Int32 LocationY
        {
            get { return m_locationY; }
            set { m_locationY = value; }
        }

        public Int32 Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        public Int32 Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        public Int32 WindowState
        {
            get { return m_windowState; }
            set { m_windowState = value; }
        }


        public String SearchDir
        {
            get { return m_searchDir; }
            set { m_searchDir = value; }
        }

        public Boolean IncludeSubDirsChecked
        {
            get { return m_includeSubDirsChecked; }
            set { m_includeSubDirsChecked = value; }
        }

        public String FileName
        {
            get { return m_fileName; }
            set { m_fileName = value; }
        }

        public Boolean NewerThanChecked
        {
            get { return m_newerThanChecked; }
            set { m_newerThanChecked = value; }
        }

        public DateTime NewerThanDateTime
        {
            get { return m_newerThanDateTime; }
            set { m_newerThanDateTime = value; }
        }

        public Boolean OlderThanChecked
        {
            get { return m_olderThanChecked; }
            set { m_olderThanChecked = value; }
        }

        public DateTime OlderThanDateTime
        {
            get { return m_olderThanDateTime; }
            set { m_olderThanDateTime = value; }
        }

        public Boolean ContainingChecked
        {
            get { return m_containingChecked; }
            set { m_containingChecked = value; }
        }

        public String ContainingText
        {
            get { return m_containingText; }
            set { m_containingText = value; }
        }

        public Boolean AsciiChecked
        {
            get { return m_asciiChecked; }
            set { m_asciiChecked = value; }
        }

        public Boolean UnicodeChecked
        {
            get { return m_unicodeChecked; }
            set { m_unicodeChecked = value; }
        }

        public String Delimeter
        {
            get { return m_delimeter; }
            set { m_delimeter = value; }
        }

        public String ResultsFilePath
        {
            get { return m_resultsFilePath; }
            set { m_resultsFilePath = value; }
        }
    }


    public class UserConfig
    {
        // ----- Variables -----

        private static String m_path = Path.Combine(Application.UserAppDataPath, "UserConfig.txt");
        private static UserConfigData m_configData = new UserConfigData();

        
        // ----- Public Properties -----

        public static UserConfigData Data
        {
            get { return m_configData; }
        }


        // ----- Public Methods -----

        public static Boolean Load()
        {
            Boolean success = false;

            try
            {
                // Zeilen aus der Datei "Config.txt" lesen:
                List<String> lines = new List<String>();
                FileStream fileStream = new FileStream(m_path, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                while (streamReader.Peek() >= 0)
                {
                    String line = streamReader.ReadLine();
                    lines.Add(line);
                }
                streamReader.Close();
                fileStream.Close();

                // Properties mit Werten belegen:
                PropertyInfo[] propertyInfos = m_configData.GetType().GetProperties();
                if (propertyInfos.Length == lines.Count)
                {
                    for (Int32 i = 0; i < propertyInfos.Length; i++)
                    {
                        PropertyInfo propertyInfo = propertyInfos[i];
                        String line = lines[i];
                        Object value = null;
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case "String":
                                value = line;
                                break;
                            case "Int32":
                                value = Convert.ToInt32(line, System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "Boolean":
                                value = Convert.ToBoolean(line, System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "DateTime":
                                value = Convert.ToDateTime(line, System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            default:
                                break;
                        }
                        propertyInfo.SetValue(m_configData, value, null);
                    }

                    success = true;
                }
            }
            catch (Exception)
            {
            }

            return success;
        }

        public static Boolean Save()
        {
            Boolean success = false;

            try
            {
                if (File.Exists(m_path))
                {
                    // Schreibschutz aufheben:
                    FileAttributes attributes = File.GetAttributes(m_path);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        FileAttributes newAttributes = attributes ^ FileAttributes.ReadOnly;
                        File.SetAttributes(m_path, newAttributes);
                    }
                    // Datei löschen:
                    File.Delete(m_path);
                }
                FileStream fileStream = new FileStream(m_path, FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                try
                {
                    foreach (PropertyInfo propertyInfo in m_configData.GetType().GetProperties())
                    {
                        String line = "";
                        Object obj = propertyInfo.GetValue(m_configData, null);
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case "String":
                                line = (String)obj;
                                break;
                            case "Int32":
                                Int32 i = (Int32)obj;
                                line = i.ToString(System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "Boolean":
                                Boolean b = (Boolean)obj;
                                line = b.ToString(System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "DateTime":
                                DateTime dt = (DateTime)obj;
                                line = dt.ToString(System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            default:
                                break;
                        }
                        streamWriter.WriteLine(line);
                    }

                    success = true;
                }
                catch (Exception)
                {
                }

                streamWriter.Close();
                fileStream.Close();
            }
            catch (Exception)
            {
            }

            return success;
        }
    }
}
