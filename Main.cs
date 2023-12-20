using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.IO;
using System.Threading;

namespace w2_volume
{
    public partial class Main : Form
    {
        //Unique App Identifier
        static Mutex mutex = new Mutex(true, "Worms 2 Volume by Carlmundo");
        //File with BGM Volume value
        private string fileVolumeBGM = "volumeBGM.txt";

        public Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                mutex.ReleaseMutex();
                InitializeComponent();
            }
            else
            {
                Close();
            } 
        }
        public static string GetOSVersion()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT version FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["version"].ToString();
                break;
            }
            return result;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Check if Audio Mixer should be shown
            string versionOS = GetOSVersion();
            string versionMixer = "10.0.18362"; //Windows 10 Build 1903
            var vOS = new Version(versionOS);
            var vMixer = new Version(versionMixer);
            var result = vOS.CompareTo(vMixer);
            if (result < 0)
            {
                lblMixer.Visible = false;
                btnMixer.Visible = false;
            }        

            //Create file if it doesn't exist and set default value 
            if (!File.Exists(fileVolumeBGM))
            {
                File.WriteAllText(fileVolumeBGM, "100");
            }
            else
            {
                //Read value and set the trackbar to match if it is a valid number
                string readVolumeBGM = File.ReadAllText(fileVolumeBGM).Trim();
                try
                {
                    tbBGM.Value = int.Parse(readVolumeBGM);
                }
                catch {}                
            }
        }

        private void tbBGM_ValueChanged(object sender, EventArgs e)
        {
            string strBGM = tbBGM.Value.ToString();
            //Update the label
            lblBGMval.Text = strBGM;
            //Write the volume to file
            File.WriteAllText(fileVolumeBGM, strBGM);
        }

        private void btnMixer_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:apps-volume");
        }

        private void timerProcessCheck_Tick(object sender, EventArgs e)
        {
            Process[] ProcessW2 = Process.GetProcessesByName("worms2");
            if (ProcessW2.Length > 0)
            {
                tbBGM.Enabled = false;
            }
            else
            {
                tbBGM.Enabled = true;
            }
        }
    }
}
