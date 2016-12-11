using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;



namespace FileSearcher
{
    public partial class MainWindow : Form
    {
        // ----- Variables -----

        private Boolean m_closing = false;


        // ----- Synchronizing Delegates -----

        private delegate void FoundInfoSyncHandler(FoundInfoEventArgs e);
        private FoundInfoSyncHandler FoundInfo;

        private delegate void ThreadEndedSyncHandler(ThreadEndedEventArgs e);
        private ThreadEndedSyncHandler ThreadEnded;


        // ----- Constructor -----

        public MainWindow()
        {
            InitializeComponent();
        }


        // ----- Event Handlers -----

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Load config values:
            UserConfig.Load();

            this.Location = new Point(UserConfig.Data.LocationX, UserConfig.Data.LocationY);
            this.Size = new Size(UserConfig.Data.Width, UserConfig.Data.Height);
            this.WindowState = (FormWindowState)UserConfig.Data.WindowState;
            
            searchDirTextBox.Text = UserConfig.Data.SearchDir;
            includeSubDirsCheckBox.Checked = UserConfig.Data.IncludeSubDirsChecked;
            fileNameTextBox.Text = UserConfig.Data.FileName;
            newerThanCheckBox.Checked = UserConfig.Data.NewerThanChecked;
            newerThanDateTimePicker.Value = UserConfig.Data.NewerThanDateTime;
            olderThanCheckBox.Checked = UserConfig.Data.OlderThanChecked;
            olderThanDateTimePicker.Value = UserConfig.Data.OlderThanDateTime;
            containingCheckBox.Checked = UserConfig.Data.ContainingChecked;
            containingTextBox.Text = UserConfig.Data.ContainingText;
            asciiRadioButton.Checked = UserConfig.Data.AsciiChecked;
            unicodeRadioButton.Checked = UserConfig.Data.UnicodeChecked;
            delimeterTextBox.Text = UserConfig.Data.Delimeter;

            // Subscribe for my own delegates:
            this.FoundInfo += new FoundInfoSyncHandler(this_FoundInfo);
            this.ThreadEnded += new ThreadEndedSyncHandler(this_ThreadEnded);

            // Subscribe for the Searcher's events:
            Searcher.FoundInfo += new Searcher.FoundInfoEventHandler(Searcher_FoundInfo);
            Searcher.ThreadEnded += new Searcher.ThreadEndedEventHandler(Searcher_ThreadEnded);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Remember that the window is closing,
            // so that all events from the Searcher are ignored from now on:
            m_closing = true;

            // Stop the search thread if it is running:
            Searcher.Stop();

            // Save config values:
            if (this.WindowState == FormWindowState.Normal)
            {
                UserConfig.Data.LocationX = this.Location.X;
                UserConfig.Data.LocationY = this.Location.Y;
                UserConfig.Data.Width = this.Size.Width;
                UserConfig.Data.Height = this.Size.Height;
            }
            if (this.WindowState != FormWindowState.Minimized)
            {
                UserConfig.Data.WindowState = (Int32)this.WindowState;
            }

            UserConfig.Data.SearchDir = searchDirTextBox.Text;
            UserConfig.Data.IncludeSubDirsChecked = includeSubDirsCheckBox.Checked;
            UserConfig.Data.FileName = fileNameTextBox.Text;
            UserConfig.Data.NewerThanChecked = newerThanCheckBox.Checked;
            UserConfig.Data.NewerThanDateTime = newerThanDateTimePicker.Value;
            UserConfig.Data.OlderThanChecked = olderThanCheckBox.Checked;
            UserConfig.Data.OlderThanDateTime = olderThanDateTimePicker.Value;
            UserConfig.Data.ContainingChecked = containingCheckBox.Checked;
            UserConfig.Data.ContainingText = containingTextBox.Text;
            UserConfig.Data.AsciiChecked = asciiRadioButton.Checked;
            UserConfig.Data.UnicodeChecked = unicodeRadioButton.Checked;
            UserConfig.Data.Delimeter = delimeterTextBox.Text;
            
            UserConfig.Save();
        }

        private void selectSearchDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = searchDirTextBox.Text;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                searchDirTextBox.Text = dlg.SelectedPath;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Stop the search thread if it is running:
            Searcher.Stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Clear the results list:
            resultsList.Items.Clear();

            // Get the parameters for  the search thread:
            String fileNamesString = fileNameTextBox.Text;
            String[] fileNames = fileNamesString.Split(new Char[]{';'});
            List<String> validFileNames = new List<String>();
            foreach (String fileName in fileNames)
            {
                String trimmedFileName = fileName.Trim();
                if (trimmedFileName != "")
                {
                    validFileNames.Add(trimmedFileName);
                }
            }

            Encoding encoding = asciiRadioButton.Checked ? Encoding.ASCII : Encoding.Unicode;

            SearcherParams pars = new SearcherParams(   searchDirTextBox.Text.Trim(),
                                                        includeSubDirsCheckBox.Checked,
                                                        validFileNames,
                                                        newerThanCheckBox.Checked,
                                                        newerThanDateTimePicker.Value,
                                                        olderThanCheckBox.Checked,
                                                        olderThanDateTimePicker.Value,
                                                        containingCheckBox.Checked,
                                                        containingTextBox.Text.Trim(),
                                                        encoding);
            
            // Start the search thread if it is not already running:
            if (Searcher.Start(pars))
            {
                // Disable all buttons except stop button:
                DisableButtons();
            }
            else
            {
                MessageBox.Show("The searcher is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void writeResultsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.FileName = UserConfig.Data.ResultsFilePath;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                UserConfig.Data.ResultsFilePath = dlg.FileName;

                try
                {
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);

                    String delimeter = delimeterTextBox.Text.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");

                    bool bFirstHdr = true;
                    foreach (ColumnHeader hdr in resultsList.Columns)
                    {
                        if (bFirstHdr)
                        {
                            bFirstHdr = false;
                            sw.Write(hdr.Text + ":");
                        }
                        else
                        {
                            sw.Write(delimeter + hdr.Text + ":");
                        }
                    }
                    sw.WriteLine();

                    foreach (ListViewItem lvi in resultsList.Items)
                    {
                        bool bFirstLvsi = true;
                        foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                        {
                            if (bFirstLvsi)
                            {
                                bFirstLvsi = false;
                                sw.Write(lvsi.Text);
                            }
                            else
                            {
                                sw.Write(delimeter + lvsi.Text);
                            }
                        }
                        sw.WriteLine();
                    }

                    sw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void newerThanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (newerThanCheckBox.Checked)
            {
                newerThanDateTimePicker.Enabled = true;
            }
            else
            {
                newerThanDateTimePicker.Enabled = false;
            }
        }

        private void olderThanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (olderThanCheckBox.Checked)
            {
                olderThanDateTimePicker.Enabled = true;
            }
            else
            {
                olderThanDateTimePicker.Enabled = false;
            }
        }

        private void containingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (containingCheckBox.Checked)
            {
                containingTextBox.Enabled = true;
                asciiRadioButton.Enabled = true;
                unicodeRadioButton.Enabled = true;
            }
            else
            {
                containingTextBox.Enabled = false;
                asciiRadioButton.Enabled = false;
                unicodeRadioButton.Enabled = false;
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Don't open the context menu strip, if there are no items selected:
            if (resultsList.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void openContainingFolderContextMenuItem_Click(object sender, EventArgs e)
        {
            // Get the path from the selected item:
            if (resultsList.SelectedItems.Count > 0)
            {
                String path = resultsList.SelectedItems[0].Text;

                // Open its containing folder in Windows Explorer:
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "explorer.exe";
                    startInfo.Arguments = Path.GetDirectoryName(path);
                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.Start();
                }
                catch (Exception)
                {
                }
            }
        }

        private void resultsList_DoubleClick(object sender, EventArgs e)
        {
            // Get the path from the selected item:
            if (resultsList.SelectedItems.Count > 0)
            {
                String path = resultsList.SelectedItems[0].Text;

                // Open it, if it's a file:
                if (File.Exists(path))
                {
                    try
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = path;
                        startInfo.Arguments = "";
                        Process process = new Process();
                        process.StartInfo = startInfo;
                        process.Start();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void resultsList_Resize(object sender, EventArgs e)
        {
            resultsList.Columns[0].Width = resultsList.Width - 230;
        }

        private void Searcher_FoundInfo(FoundInfoEventArgs e)
        {
            if (!m_closing)
            {
                // Invoke the method "this_FoundInfo" through a delegate,
                // so it is executed in the same thread as MainWindow:
                this.Invoke(FoundInfo, new object[] { e });
            }
        }

        private void this_FoundInfo(FoundInfoEventArgs e)
        {
            // Create a new item in the results list:
            CreateResultsListItem(e.Info);
        }

        private void Searcher_ThreadEnded(ThreadEndedEventArgs e)
        {
            if (!m_closing)
            {
                // Invoke the method "this_ThreadEnded" through a delegate,
                // so it is executed in the same thread as MainWindow:
                this.Invoke(ThreadEnded, new object[] { e });
            }
        }

        private void this_ThreadEnded(ThreadEndedEventArgs e)
        {
            // Enable all buttons except stop button:
            EnableButtons();

            // Show an error message if necessary:
            if (!e.Success)
            {
                MessageBox.Show(e.ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        // ----- Private Methods -----

        private void EnableButtons()
        {
            searchDirTextBox.Enabled = true;
            selectSearchDirButton.Enabled = true;
            includeSubDirsCheckBox.Enabled = true;
            fileNameTextBox.Enabled = true;
            newerThanCheckBox.Enabled = true;
            if (newerThanCheckBox.Checked)
            {
                newerThanDateTimePicker.Enabled = true;
            }
            olderThanCheckBox.Enabled = true;
            if (olderThanCheckBox.Checked)
            {
                olderThanDateTimePicker.Enabled = true;
            }
            containingCheckBox.Enabled = true;
            if (containingCheckBox.Checked)
            {
                containingTextBox.Enabled = true;
                asciiRadioButton.Enabled = true;
                unicodeRadioButton.Enabled = true;
            }
            stopButton.Enabled = false;
            startButton.Enabled = true;
            delimeterTextBox.Enabled = true;
            writeResultsButton.Enabled = true;
        }

        private void DisableButtons()
        {
            searchDirTextBox.Enabled = false;
            selectSearchDirButton.Enabled = false;
            includeSubDirsCheckBox.Enabled = false;
            fileNameTextBox.Enabled = false;
            newerThanCheckBox.Enabled = false;
            newerThanDateTimePicker.Enabled = false;
            olderThanCheckBox.Enabled = false;
            olderThanDateTimePicker.Enabled = false;
            containingCheckBox.Enabled = false;
            containingTextBox.Enabled = false;
            asciiRadioButton.Enabled = false;
            unicodeRadioButton.Enabled = false;
            stopButton.Enabled = true;
            startButton.Enabled = false;
            delimeterTextBox.Enabled = false;
            writeResultsButton.Enabled = false;
        }

        public static String GetBytesStringKB(Int64 bytesCount)
        {
            Int64 bytesShow = (bytesCount + 1023) >> 10;
            String bytesString = GetPointString(bytesShow) + " KB";
            return bytesString;
        }

        public static String GetPointString(Int64 value)
        {
            String pointString = value.ToString();

            Int32 i = 3;
            while (pointString.Length > i)
            {
                pointString = pointString.Substring(0, pointString.Length - i) + "." + pointString.Substring(pointString.Length - i, i);
                i += 4;
            }

            return pointString;
        }

        private void CreateResultsListItem(FileSystemInfo info)
        {
            // Create a new item and set its text:
            ListViewItem lvi = new ListViewItem();
            lvi.Text = info.FullName;

            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            if (info is FileInfo)
            {
                lvsi.Text = GetBytesStringKB(((FileInfo)info).Length);
            }
            else
            {
                lvsi.Text = "";
            }
            lvi.SubItems.Add(lvsi);

            lvsi = new ListViewItem.ListViewSubItem();
            lvsi.Text = info.LastWriteTime.ToShortDateString() + " " + info.LastWriteTime.ToShortTimeString();
            lvi.SubItems.Add(lvsi);

            // Set the text that is shown when the mouse cursor
            // rests over the item (The "ShowItemToolTips" property of the ListView
            // must be true to show the text.):
            lvi.ToolTipText = info.FullName;

            // Add the new item to the list:
            resultsList.Items.Add(lvi);
        }
    }
}
