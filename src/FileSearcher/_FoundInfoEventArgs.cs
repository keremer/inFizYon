using System;
using System.Collections.Generic;
using System.IO;



namespace FileSearcher
{
    public class FoundInfoEventArgs
    {
        // ----- Variables -----

        private FileSystemInfo m_info;


        // ----- Constructor -----

        public FoundInfoEventArgs(FileSystemInfo info)
        {
            m_info = info;
        }


        // ----- Public Properties -----

        public FileSystemInfo Info
        {
            get { return m_info; }
        }
    }
}
