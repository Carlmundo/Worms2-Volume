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
        //File with BGM Volume value
        private string fileVolumeBGM = "volumeBGM.txt";

        public Main()
        {
            InitializeComponent();
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
            //Check Language
            string langFile = "language.txt";
            string[] langArr = {"cs","de","en","es","es-419","fr","it","nl","pl","pt","pt-br","ru","sv"};
            string langVal;
            if (File.Exists(langFile)){ 
                langVal = File.ReadAllText(langFile).Trim();
                if (!Array.Exists(langArr, element => element == langVal))
                {
                    langVal = "en";
                }
            }
            else
            {
                langVal = "en";
            }

            string txtVolume, txtBGM, txtMixer, txtOpenMixer;
            switch (langVal)
            {
                case "cs":
                    //Credit: JPEXS
                    txtVolume = "Hlasitost";
                    txtBGM = "Hudba v pozadí";
                    txtMixer = "Směšovač hlasitosti";
                    txtOpenMixer = "Otevřít směšovač hlasitosti";
                    break;
                case "de":
                    txtVolume = "Lautstärke";
                    txtBGM = "Audio-Hintergrund";
                    txtMixer = "Ton-Mischpult";
                    txtOpenMixer = "Einstellungen";
                break;
                case "es":
                    //Credit: Tomasety III
                    txtVolume = "Volumen";
                    txtBGM = "Sonido de ambiente";
                    txtMixer = "Mezclador de Audio";
                    txtOpenMixer = "Editar";
                    break;
                case "es-419":
                    txtVolume = "Volumen";
                    txtBGM = "Volumen del sonido ambiental";
                    txtMixer = "Volumen del mezclador de sonido";
                    txtOpenMixer = "Editar";
                    break;
                case "fr":
                    txtVolume = "Volume";
                    txtBGM = "Fond sonore";
                    txtMixer = "Volume du mélangeur audio";
                    txtOpenMixer = "Editer";
                    break;
                case "it":
                    txtVolume = "Volume";
                    txtBGM = "Sottofondo";
                    txtMixer = "Volume mixer audio";
                    txtOpenMixer = "Modifica";
                    break;
                case "nl":
                    txtVolume = "Volume";
                    txtBGM = "Omgeving";
                    txtMixer = "Audio mixer volume";
                    txtOpenMixer = "Instellingen wijzigen";
                    break;
                case "pl":
                    //Credit: Dawid8
                    txtVolume = "Głośność";
                    txtBGM = "Muzyka w tle";
                    txtMixer = "Mikser Głośności";
                    txtOpenMixer = "Otwórz Mikser Głośności";
                    break;
                case "pt":
                case "pt-br":
                    //Credit: rubinho146
                    txtVolume = "Volume";
                    txtBGM = "Música de Fundo";
                    txtMixer = "Misturador de Volume";
                    txtOpenMixer = "Abrir misturador de volume";
                    break;
                case "ru":
                    txtVolume = "громкость";
                    txtBGM = "Фоновая музыка";
                    txtMixer = "Громкость аудио микшера";
                    txtOpenMixer = "открыта";
                    break;
                case "sv":
                    txtVolume = "Volym";
                    txtBGM = "Miljö";
                    txtMixer = "Audio mixer volym";
                    txtOpenMixer = "Editera";
                    break;
                default:
                    txtVolume = "Volume";
                    txtBGM = "Background Music";
                    txtMixer = "Volume Mixer";
                    txtOpenMixer = "Open Volume Mixer";
                break;
            }
            //Set text of controls
            this.Text = "Worms 2 " + txtVolume;
            lblBGM.Text = txtBGM;
            lblMixer.Text = txtMixer;
            btnMixer.Text = txtOpenMixer;

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
    }
}
