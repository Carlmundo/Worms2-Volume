using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Windows.Forms;

namespace w2_volume
{
    public partial class Main : Form
    {
        //Files with Volume values
        private string fileVolumeBGM = "volumeBGM.txt";
        private string fileVolumeSFX = "volumeSFX.txt";

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
            //Fix flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, tblDesign, new object[] { true });

            //Check Language
            string langFile = "language.txt";
            string[] langArr = {"cs","de","en","es","es-419","fr","it","nl","pl","pt","pt-br","ru","sv","zh-Hans"};
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

            string txtVolume, txtBGM, txtSFX, txtMixer, txtOpenMixer;
            switch (langVal)
            {
                case "cs":
                    //Credit: JPEXS
                    txtVolume = "Hlasitost";
                    txtBGM = "Hudba v pozadí";
                    txtSFX = "Zvukové efekty";
                    txtMixer = "Směšovač hlasitosti";
                    txtOpenMixer = "Otevřít směšovač hlasitosti";
                    break;
                case "de":
                    txtVolume = "Lautstärke";
                    txtBGM = "Audio-Hintergrund";
                    txtSFX = "Soundeffekte";
                    txtMixer = "Ton-Mischpult";
                    txtOpenMixer = "Einstellungen";
                break;
                case "es":
                    //Credit: Tomasety III
                    txtVolume = "Volumen";
                    txtBGM = "Sonido de ambiente";
                    txtSFX = "Efectos de sonido";
                    txtMixer = "Mezclador de Audio";
                    txtOpenMixer = "Editar";
                    break;
                case "es-419":
                    txtVolume = "Volumen";
                    txtBGM = "Volumen del sonido ambiental";
                    txtSFX = "Efectos de sonido";
                    txtMixer = "Volumen del mezclador de sonido";
                    txtOpenMixer = "Editar";
                    break;
                case "fr":
                    txtVolume = "Volume";
                    txtBGM = "Fond sonore";
                    txtSFX = "Effets sonores";
                    txtMixer = "Volume du mélangeur audio";
                    txtOpenMixer = "Editer";
                    break;
                case "it":
                    txtVolume = "Volume";
                    txtBGM = "Sottofondo";
                    txtSFX = "Effetti sonori";
                    txtMixer = "Volume mixer audio";
                    txtOpenMixer = "Modifica";
                    break;
                case "nl":
                    txtVolume = "Volume";
                    txtBGM = "Omgeving";
                    txtSFX = "Geluidseffecten";
                    txtMixer = "Audio mixer volume";
                    txtOpenMixer = "Instellingen wijzigen";
                    break;
                case "pl":
                    //Credit: Dawid8
                    txtVolume = "Głośność";
                    txtBGM = "Muzyka w tle";
                    txtSFX = "Efekty dźwiękowe";
                    txtMixer = "Mikser Głośności";
                    txtOpenMixer = "Otwórz Mikser Głośności";
                    break;
                case "pt":
                case "pt-br":
                    //Credit: rubinho146
                    txtVolume = "Volume";
                    txtBGM = "Música de Fundo";
                    txtSFX = "Efeitos Sonoros";
                    txtMixer = "Misturador de Volume";
                    txtOpenMixer = "Abrir misturador de volume";
                    break;
                case "ru":
                    txtVolume = "громкость";
                    txtBGM = "Фоновая музыка";
                    txtSFX = "Звуковые эффекты";
                    txtMixer = "Громкость аудио микшера";
                    txtOpenMixer = "открыта";
                    break;
                case "sv":
                    txtVolume = "Volym";
                    txtBGM = "Miljö";
                    txtSFX = "Ljudeffekter";
                    txtMixer = "Audio mixer volym";
                    txtOpenMixer = "Editera";
                    break;
                case "zh-Hans": //Credit: 萌の少年@Bilibili
                    txtVolume = "音量";
                    txtBGM = "背景音乐";
                    txtSFX = "音响效果";
                    txtMixer = "音量混音器";
                    txtOpenMixer = "打开音量混音器";
                    break;
                default:
                    txtVolume = "Volume";
                    txtBGM = "Background Music";
                    txtSFX = "Sound Effects";
                    txtMixer = "Volume Mixer";
                    txtOpenMixer = "Open Volume Mixer";
                break;
            }
            //Set text of controls
            this.Text = "Worms 2 " + txtVolume;
            lblBGM.Text = txtBGM;
            lblSFX.Text = txtSFX;
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

            //Create files if they don't exist and set default value 
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
            if (!File.Exists(fileVolumeSFX)) {
                File.WriteAllText(fileVolumeSFX, "100");
            }
            else {
                //Read value and set the trackbar to match if it is a valid number
                string readVolumeSFX = File.ReadAllText(fileVolumeSFX).Trim();
                try {
                    tbSFX.Value = int.Parse(readVolumeSFX);
                }
                catch { }
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

        private void tbSFX_ValueChanged(object sender, EventArgs e)
        {
            string strSFX = tbSFX.Value.ToString();
            //Update the label
            lblSFXval.Text = strSFX;
            //Write the volume to file
            File.WriteAllText(fileVolumeSFX, strSFX);
        }

        private void btnMixer_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:apps-volume");
        }
    }
}
