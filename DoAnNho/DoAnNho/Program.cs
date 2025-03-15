using DoAnNho.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginFormPL formMain = new LoginFormPL();
            formMain.ShowDialog();
        }
    }
}
