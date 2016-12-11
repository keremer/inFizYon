using System;
using System.Collections.Generic;
using System.IO;



namespace FileSearcher
{
    public class ThreadEndedEventArgs
    {
        // ----- Variables -----

        private Boolean m_success;
        private String m_errorMsg;


        // ----- Constructor -----

        public ThreadEndedEventArgs(Boolean success,
                                    String errorMsg)
        {
            m_success = success;
            m_errorMsg = errorMsg;
        }


        // ----- Public Properties -----

        public Boolean Success
        {
            get { return m_success; }
        }

        public String ErrorMsg
        {
            get { return m_errorMsg; }
        }
    }
}
