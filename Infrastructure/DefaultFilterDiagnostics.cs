using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFiltersExamples.Infrastructure
{
    public class DefaultFilterDiagnostics : IFilterDiagnostics
    {
        //就是把一些诊断信息放到集合中
        private List<string> messages = new List<string>();
        public IEnumerable<string> Messages
        {
            get
            {
                return messages;
            }
        }

        public void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
}
