using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace School5FactoryPractice.Data
{
    public class HomeworkSubscription
    {
        public int HomeworkSubscriptionId { get; set; }
        public string HomeworkName { get; set; }
        public List<int>? Grades { get; set; } = new List<int>();
        public DateTime HomeworkRemainingTime { get; set; }
        public int StudentId {  get; set; }
        public byte[]? SolvedHomework { get; set; }
    }
}
