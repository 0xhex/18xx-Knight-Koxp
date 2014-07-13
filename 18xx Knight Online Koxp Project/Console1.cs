using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
namespace ZeusAFK_koxp.NET

{
    public partial class Console1 : Form1
    {
        public bool isOnScreen;
        public bool isActivated;
       static internal class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        [DllImport("kernel32.dll")]
        public extern static IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool FreeConsole();

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;


        public void openConsole()
        {
            NativeMethods.AllocConsole();
            Console.WriteLine("Console activated.To open menu write help");
            isActivated = true;
              while (true)
              {
                  
                  string command = Console.ReadLine();
                  if (command.First() != '+' && command.First() != '/')
                  {
                      Console.WriteLine("Unrecognizable command!");
                  }
                  else if (command == "+exit")
                  {
                      FreeConsole();
                      return;
                  }
                  else
                  {
                      //parse command
                      string opcode = command.Substring(0, ((command.IndexOf(' ') == -1) ? command.Length : command.IndexOf(' ')));
                      string Data = command.Substring(opcode.Length);
                      //send to execute command
                      executeCommand(opcode, Data);

                  }
              }
        }
        public void executeCommand(string opcode, string Data /*null*/)
        {
            switch (opcode)
            {
               

            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Console1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Name = "Console1";
            this.ResumeLayout(false);
            this.isActivated = false;
        }

       




    }
}