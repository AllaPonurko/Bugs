using System;
using System.Collections.Generic;
using System.Text;

namespace Bugs
{
    public class BankBug
    {
        public string Key { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Assignee { get; set; }
        public string Labels { get; set; }
        public string FixVersion { get; set; }
        public string Reporter { get; set; }
        public string IssueType { get; set; }
        public string OriginalEstimate { get; set; }
        public string Priority { get; set; }
        public string Sprint { get; set; }
        public string DueDate { get; set; }
        public string Created { get; set; }
        public string QADueDate { get; set; }
        public List<string> listBug()
        {
            List<string> list=new List<string>();
            list.Add(Key);
            list.Add(Summary);
            list.Add(Status);
            list.Add(Assignee);
            list.Add(Labels);
            list.Add(FixVersion);
            list.Add(Reporter);
            list.Add(IssueType);
            list.Add(OriginalEstimate);
            list.Add(Priority);
            list.Add(Sprint);
            list.Add(DueDate);
            list.Add(Created);
            list.Add(QADueDate);
            return list;
        }
    }
}
