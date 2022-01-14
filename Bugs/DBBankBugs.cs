using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugs
{
    class DBBankBugs
    { string[] BugTypes = new string[] { "Blocker", "Critical", "Major", "Medium", "Minor", "Normal" };
        string inFileName = @"C:\Users\Asus\source\repos\Bugs\Bugs\bugs-2002.csv";
        private List<BankBug> bugs = new List<BankBug>();
        Dictionary<string, ErrorSummary> errorReport = new Dictionary<string, ErrorSummary>();
        public DataTable Load()
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(inFileName, Encoding.Default))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }

        }
        public void PrintDataTable(DataTable dt)
        {
            foreach (DataRow r in dt.Rows)
            {
                foreach (var c in r.ItemArray)
                    Console.Write("\t{0}", c);
                Console.WriteLine();
            }

        }
        //public List<BankBug> BankBugLoad()\\недоработано
        //{
        //    using (StreamReader sr = new StreamReader(inFileName, Encoding.Default)) 
        //    {
        //        string[] headers = sr.ReadLine().Split(',');
        //        BankBug bankBug = new BankBug();
        //        for (int i=0;i< bankBug.listBug().Count;i++)
        //        {
        //            bankBug.listBug()[i]= headers[i];
        //        }
        //        while (!sr.EndOfStream)
        //        {
        //            string[] rows = sr.ReadLine().Split(',');

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                bugs[i] = rows[i];
        //            }
        //            bugs.Add( bankBug) ;
        //            }
                    
        //        }

        //    }
        //    return bugs;
        //}
        public void BuildHeader()
        {
            foreach(var n in from b in bugs select b.Labels)
            {
                var nn = n.Split(',');
               foreach( var na in nn)
                {
                    try
                    {
                        errorReport.Add(na.Trim(), new ErrorSummary());
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
        public void ByBugType()
        {foreach(var bugtype in BugTypes)
            {
             Console.Write("\n\n" + bugtype + " ");
             var c = from t in errorReport
                    select t.Value.GetType().GetProperty(bugtype).GetValue(t.Value);
                foreach(int tmp in c)
            {
                Console.Write(tmp + ",");
            }
                var countAll = errorReport.Select(e => (int)e.Value.GetType().GetProperty(bugtype).GetValue(e.Value)).Sum();
                Console.Write("total " + countAll);
            }
            
        }
        public void PrintReport()
        {
            foreach(var t in errorReport)
            {
                Console.WriteLine("-------------\n Team: " + t.Key);
                int total = 0;
                foreach(var item in t.Value.GetType().GetProperties())
                {
                    int c = (int)item.GetValue(t.Value);
                    total += c;
                    Console.WriteLine(item.Name + " " + item.GetValue(t.Value));
                }
                Console.WriteLine("--------------\n Total in team: " + total);
            }
        }
    }
}
