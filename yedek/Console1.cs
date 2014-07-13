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
       public Form1 KO;
        public void writeConsol(string text) {
            Console.WriteLine(text);
        }
        public Console1(Form1 bufferKO)
        {
            KO = bufferKO;
        }

       static internal class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }


        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool FreeConsole();

        public void openConsole()
        {
            
            NativeMethods.AllocConsole();
            Console.WriteLine("Console activated.To open menu write help");
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
                      string Data = command.Substring(opcode.Length+1);
                      //send to execute command
                      executeCommand(opcode, Data);

                  }
              }
        }
        public void executeCommand(string opcode, string Data /*null*/)
        {
            switch (opcode)
            {
                case "+sendPacket":
                    KO.Packet(Data);
                    break;

            }

        }

     

        private void Console1_Load(object sender, EventArgs e)
        {

        }

       




    }
}