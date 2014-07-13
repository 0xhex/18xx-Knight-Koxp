using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ZeusAFK_koxp.NET
{
    public partial class Form1 : Methods
    {

        public Form1()
        {
            InitializeComponent();
        }
        public Console1 console;
        public string Job;
        public int[] PartyLifes = new int[8];
        public int MyLife = 0;
        public string LastMaliced = "";

        public string[,] cSkills;

        public void MakeAttack(string skill)
        {

        }

        public int GetSkillIndex(string Skill)
        {
            for (int i = 0; i < cSkills.GetLength(0); i++)
                if (cSkills[i, 0].Equals(Skill))
                    return i;
            return -1;
        }

        public string ChoosenSkill()
        {

            return "";
        }

        public void StartKoxp()
        {
            AddressPointer = ToInt32(ReadMemory(new IntPtr(PTR_CHR)));
            LoadControls();
            SND_FIX();
   
            System.Media.SystemSounds.Asterisk.Play();
        
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\logs"))           
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\logs");
            //System.IO.File.Create(Application.StartupPath + "\\logs\\" + CharName() + ".log");
            writer = new System.IO.StreamWriter(System.IO.File.Create(Application.StartupPath + "\\logs\\" + CharName() + ".log"));
        }

        public void LoadControls()
        {
            if (CharJob().Equals("Rogue"))
            {
               
                cSkills = new string[,]
                {
                    {"Stab","6","6"},
                    {"Stab2","6","6"},
                    {"Jab","6","6"},
                    {"Pierce","11","11"},
                    {"Shock","6","6"},
                    {"Thrust","11","11"},
                    {"Cut","6","6"},
                    {"Spike","12","12"},
                    {"Blody Beast","6","6"},
                    {"Blinding","60","60"},
                    {"Archery","0","0"},
                    {"Through Shot","0","0"},
                    {"Fire Arrow","3","3"},
                    {"Poison Arrow","3","3"},
                    {"Multiple Shot","0","0"},
                    {"Guided Arrow","0","0"},
                    {"Perfect Shot","0","0"},
                    {"Fire Shot","4","4"},
                    {"Poison Shot","4","4"},
                    {"Arc Shot","0","0"},
                    {"Explosive Shot","4","4"},
                    {"Counter Strike","60","60"},
                    {"Arrow Shower","0","0"},
                    {"Shadow Shot","0","0"},
                    {"Shadow Hunter","0","0"},
                    {"Ice Shot","6","6"},
                    {"Lightning Shot","6","6"},
                    {"Dark Pursuer","0","0"},
                    {"Blow Arrow","0","0"},
                    {"Blinding Strafe","60","60"},
                    {"Super Archer","0","0"}
                };

               
            }

            if (CharJob().Equals("Warrior"))
            {
                
                cSkills = new string[,]
                {
                    {"Slash","3","3"},
                    {"Crash","3","3"},
                    {"Piercing","3","3"},
                    {"Hash","3","3"},
                    {"Hoodwink","0","0"},
                    {"Shear","3","3"},
                    {"Pierce","0","0"},
                    {"Carwing","0","0"},
                    {"Sever","3","3"},
                    {"Prick","0","0"},
                    {"Multiple Shock","3","3"},
                    {"Cleave","0","0"},
                    {"Mangling","3","3"},
                    {"Thrust","0","0"},
                    {"Sword Aura","0","0"},
                    {"Sword Dancing","0","0"},
                    {"Howling Sword","1","1"},
                    {"Blooding","21","21"},
                    {"Hell Blade","1","1"}
                };
              
            }

            if(CharJob().Equals("Priest"))
            {
               
                cSkills = new string[,]
                {
                    {"Stroke","0","0"},
                    {"Holy Attack","0","0"},
                    {"Wrath","0","0"},
                    {"Wield","0","0"},
                    {"Harsh","2","2"},
                    {"Collapse","3","3"},
                    {"Collision","0","0"},
                    {"Shuddering","0","0"},
                    {"Ruin","2","2"},
                    {"Hellish","3","3"},
                    {"Tilt","0","0"},
                    {"Bloody","0","0"},
                    {"Raving Edge","2","2"},
                    {"Hades","3","3"},
                    {"Judgment","0","0"},
                    {"Helis","0","0"}
                };
              
            }
            if (CharJob().Equals("Mage"))
            {
               
                cSkills = new string[,]
                {
                    {"Counter Spell","6","6"},
                    {"Lightining","5","5"},
                    {"Static Hemispher","1","1"},
                    {"Thunder","5","5"},
                    {"Thunder Blast","5","5"},
                    {"Charged Blade","1","1"},
                    {"Specter Of Thunder","1","1"},
                    {"Static Orb","6","6"},
                    {"Static Thorn","6","6"},
                    {"Manes Of Thunder","1","1"},
                    {"Thunder Impact","21","21"},
                    {"Burn","1","1"},
                    {"Ignition","1","1"},
                    {"Specter Of Fire","1","1"},
                    {"Manes Of Fire","1","1"},
                    {"Fire Blast","5","5"},
                    {"Blaze","6","6"},
                    {"Fire Spear","5","5"},
                    {"Hell Fire","5","5"},
                    {"Pillar Of Fire","6","6"},
                    {"Fire Thorn","6","6"},
                    {"Fire Impact","21","21"},
                    {"Fire Ball","5","5"},
                    {"Freeze","1","1"},
                    {"Chill","6","6"},
                    {"Solid","1","1"},
                    {"Frostbite","5","5"},
                    {"Frozen Blade","1","1"},
                    {"Specter Of Ice","1","1"},
                    {"Ice Comet","6","6"},
                    {"Ice Orb","5","5"},
                    {"Manes Of Ice","1","1"},
                    {"Ice Impact","21","21"},
                    {"Ice Staff","1","1"},
                    {"Flame Staff","1","1"},
                    {"Glacier Staff","1","1"},
                    {"Lightining Staff","1","1"},
                    {"Inferno","16","16"},
                    {"Blizzard","16","16"},
                    {"Thundercloud","16","16"},
                    {"Super Nova","16","16"},
                    {"Frost Nova","16","16"},
                    {"Static Nova","16","16"},
                    {"Chain Lightning","19","19"},
                    {"Ice Storm","19","19"},
                    {"Meteor Fall","19","19"},
                    {"Incineration", "22", "22"}
                };
            }

            TSkills[0, 0] = "Wolf"; TSkills[0, 1] = "120"; TSkills[0, 2] = "120";
            TSkills[1, 0] = "Swift"; TSkills[1, 1] = "600"; TSkills[1, 2] = "600";
            TSkills[2, 0] = "Light Feet"; TSkills[2, 1] = "10"; TSkills[2, 2] = "10";
            TSkills[3, 0] = "Evade"; TSkills[3, 1] = "30"; TSkills[3, 2] = "30";
            TSkills[4, 0] = "Safely"; TSkills[4, 1] = "30"; TSkills[4, 2] = "30";
            TSkills[5, 0] = "Skaled Skin"; TSkills[5, 1] = "30"; TSkills[5, 2] = "30";
            TSkills[6, 0] = "Lupin Eyes"; TSkills[6, 1] = "50"; TSkills[6, 2] = "50";
            TSkills[7, 0] = "Hide"; TSkills[7, 1] = "40"; TSkills[7, 2] = "40";

            TSkills[8, 0] = "Gain"; TSkills[8, 1] = "300"; TSkills[8, 2] = "300";
            TSkills[9, 0] = "Defense"; TSkills[9, 1] = "15"; TSkills[9, 2] = "15";
            TSkills[10, 0] = "Sprint"; TSkills[10, 1] = "10"; TSkills[10, 2] = "10";

            TSkills[11, 0] = "Strenght"; TSkills[11, 1] = "600"; TSkills[11, 2] = "600";
            TSkills[12, 0] = "Player Of Cronos"; TSkills[12, 1] = "100"; TSkills[12, 2] = "100";
            TSkills[13, 0] = "Prayer Of God's Power"; TSkills[13, 1] = "100"; TSkills[13, 2] = "100";
            TSkills[14, 0] = "Blasting"; TSkills[14, 1] = "400"; TSkills[14, 2] = "400";
            TSkills[15, 0] = "Wildness"; TSkills[15, 1] = "400"; TSkills[15, 2] = "400";
        }

        void ConfigAttack()
        {
          
        }

        public bool CanAttack(string Enemy)
        {
          
            return false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
          //  if (AttachProccess(txtWindowsName.Text))
              //  StartKoxp();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            ConfigAttack();
        }

        private void chkWallHack_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkWallHack.Checked)
                WriteMemory(new IntPtr(AddressPointer + OFF_WH), 0);
           // else
                WriteMemory(new IntPtr(AddressPointer + OFF_WH), 1);
        }


        

    
        private void timerAttack_Tick(object sender, EventArgs e)
        {
           
        }

        private void chkAllwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
           // if (chkAllwaysOnTop.Checked)
                SetWindowPos(new IntPtr(this.Handle.ToInt32()), new IntPtr(-1), this.Left, this.Top, this.Width, this.Height, (uint)0x2);
           // else
                SetWindowPos(new IntPtr(this.Handle.ToInt32()), new IntPtr(-2), this.Left, this.Top, this.Width, this.Height, (uint)0x2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteMemory(new IntPtr(AddressPointer + 0xD29), 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Job = "Archer"; 
            LoadControls();
        }

        

        private void txtWindowsName_DropDown(object sender, EventArgs e)
        {
           
            System.Diagnostics.Process[] Proceso = System.Diagnostics.Process.GetProcessesByName("KnightOnLine");
           // for (int i = 0; i < Proceso.Length; i++)
               // txtWindowsName.Items.Add(Proceso[i].MainWindowTitle);
        }

        public string[,] TSkills = new string[20, 3];

        private void chkAutoLoot_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAutoLoot.Checked)
                WriteMemory(new IntPtr(ToInt32(ReadMemory(new IntPtr(PTR_DLG))) + 0x7BC), 1);
          //  else
                WriteMemory(new IntPtr(ToInt32(ReadMemory(new IntPtr(PTR_DLG))) + 0x7BC), 0); // 7BC
        }

        public void TimedSkill(string Skill)
        {
            switch (Skill)
            {
                case "Wolf": Wolf(); break;
                case "Swift": Swift(); break;
                case "Light Feet": LightFeet(); break;
                case "Evade": Evade(); break;
                case "Safely": Safely(); break;
                case "Skaled Skin": SkaledSkin(); break;
                case "Lupin Eyes": LupinEyes(); break;
                case "Hide": RogueHide(); break;

                case "Gain": Gain(); break;
                case "Defense": Defense(); break;
                case "Sprint": Sprint(); break;

                case "Strenght": Strenght(CharID()); break;
                case "Prayer Of Cronos": PlayerOfCronos(); break;
                case "Prayer Of God's Power": PlayerOfGodPower(); break;
                case "Blasting": Blasting(); break;
                case "Wildness": Wildness(); break;
                default: return;
            }
        }

        private void TimerTSkills_Tick(object sender, EventArgs e)
        {

            if (CharDC() == 0)
                System.Media.SystemSounds.Exclamation.Play();

            int j = -1; int k = -1;
            switch (CharJob())
            {
                case "Rogue": j = 0; k = 8; break;
                case "Warrior": j = 8; k = 3; break;
                case "Priest": j = 11; k = 5; break;
                case "Mage": j = 0; k = 1; break;
                default: return;
            }
        
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xa1, 0x2, 0);
            }
        }

     

        //private void timer_query_Tick(object sender, EventArgs e)
        //{
        //    /*
        //    System.Net.HttpWebRequest myRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("koxp?x=123443211");
        //    myRequest.Method = "GET";
        //    System.Net.WebResponse myResponse = myRequest.GetResponse();
        //    System.IO.StreamReader sr = new System.IO.StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
        //    string result = sr.ReadToEnd();
        //    sr.Close();
        //    myResponse.Close();
        //    */
        //    timer_query.Enabled = false;
        //    string user = secure_string(txtIdentifier.Text.Substring(0, 4));
        //    string password = secure_string(txtIdentifier.Text.Substring(4, 4));
        //    String sql = "SELECT commands.command, commands.verification " +
        //                "FROM commands  " +
        //                "    INNER JOIN accounts " +
        //                "      ON commands.id = accounts.id " +
        //                "WHERE accounts.user = '" + user + "' and accounts.password = '" + password + "' and commands.channel = '" + ch1.Text + "'";
        //    ArrayList result = mysql_queryReturn(sql, 2);

        //    if (Last.Equals(""))
        //    {
        //        Last = (String)result[1];
        //        timer_query.Enabled = true;
        //        return;
        //    }

        //    string command = (String)result[0];
        //    New = (String)result[1];

        //    if (!New.Equals("") && New != Last)
        //    {
        //        Last = New;
        //        EjecutarComandos(command);
        //        //MessageBox.Show(command);
        //    }

        //    timer_query.Enabled = true;
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (writer != null)
                    writer.Close();
            }
            catch { }
            //if (conn.State != ConnectionState.Closed)
            //    conn.Close();
        }

        public void ApplyLanguaje(string file)
        {
            foreach (Control c in Controls)
                UpdateControl(c, file);
        }

        public void UpdateControl(Control c, string file)
        {
            if (c is GroupBox)
                foreach (Control c1 in c.Controls)
                    UpdateControl(c1, file);
            else if (c is TabControl)
                foreach (Control c1 in c.Controls)
                    UpdateControl(c1, file);
            else if (c is TabPage)
            {
                c.Text = ReadINI(file, "Controls", c.Name);
                foreach (Control c1 in c.Controls)
                    UpdateControl(c1, file);
            }
            else if (!c.Text.Equals(""))
                c.Text = ReadINI(file, "Controls", c.Name);
        }

        public string SelectLanguaje()
        {
            Form frm = new Form();
            Label lbl = new Label();
            ComboBox cmb = new ComboBox();
            Button btnOK = new Button();
            Button btnCancel = new Button();

            lbl.Text = "Select an languaje:";
            lbl.Location = new Point(10, 10);
            lbl.AutoSize = true;

            cmb.Size = new Size(250, 15);
            cmb.Location = new Point(10, 30);
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ArrayList files = LoadLanguajes();
            if (files.Count == 0)
            {
                MessageBox.Show("No languaje file was found in the current directory, you can download it from the forum.", "Languaje file not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            foreach (string[] file in files)
                cmb.Items.Add(file[0]);

            btnOK.Text = "Select";
            btnOK.Location = new Point(100, 60);
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(185, 60);
            btnCancel.DialogResult = DialogResult.Cancel;

            frm.Text = "Change languaje...";
            frm.Size = new Size(280, 120);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.AcceptButton = btnOK;
            frm.CancelButton = btnCancel;

            frm.Controls.AddRange(new Control[] { lbl, cmb, btnOK, btnCancel });

            while (frm.ShowDialog() == DialogResult.OK)
            {
                if (!cmb.Text.Trim().Equals("") && cmb.SelectedIndex != -1)
                    return ((string[])files[cmb.SelectedIndex])[1];
            }
            return string.Empty;
        }

        public ArrayList LoadLanguajes()
        {
            ArrayList result = new ArrayList();
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\lang")) Directory.CreateDirectory(Application.StartupPath + "\\lang");
            }
            catch { MessageBox.Show("An error has ocurred when try to create lang folder, create it manually and try again.", "Error creating lang folder", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
            string[] files = Directory.GetFiles(Application.StartupPath + "\\lang", "*.ini");
            foreach (string file in files)
            {
                try
                {
                    string title = "";
                    if (!(title = ReadINI(file, "Languaje", "Name")).Equals(""))
                    {
                        result.Add(new string[] { title, file });
                    }
                }
                catch { }
            }
            return result;
        }

        public void AnalizeControl(Control c)
        {
            if (c is GroupBox)
                foreach (Control c1 in c.Controls)
                    AnalizeControl(c1);
            else if (c is TabControl)
                foreach (Control c1 in c.Controls)
                    AnalizeControl(c1);
            else if (c is TabPage)
                foreach (Control c1 in c.Controls)
                    AnalizeControl(c1);
            else if (!c.Text.Equals(""))
                WriteINI("", "Controls", c.Name, c.Text);
        }

        private void btnLanguaje_Click(object sender, EventArgs e)
        {
            string file = SelectLanguaje();
            if (!file.Equals(string.Empty))
                ApplyLanguaje(file);
        }
     
    

        private void Form1_Load_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            console = null;
            console = new Console1();
            console.isOnScreen = true;
            console.openConsole();
        }
    }
}
