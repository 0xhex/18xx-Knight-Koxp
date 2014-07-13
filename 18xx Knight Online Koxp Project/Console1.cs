using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ZeusAFK_koxp.NET
{
    public partial class Console1 : Form1
    {

        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern Boolean AllocConsole();
        }

        public void openConsole()
        {
            NativeMethods.AllocConsole();
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }


    }
    }