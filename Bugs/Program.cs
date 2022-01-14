using System;
using System.Data;
using System.IO;

namespace Bugs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DBBankBugs dB = new DBBankBugs();
            DataTable dt=dB.Load();
            dB.PrintDataTable(dt);
        }
    }
}
