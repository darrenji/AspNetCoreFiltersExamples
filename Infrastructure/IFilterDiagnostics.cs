using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFiltersExamples.Infrastructure
{
    public interface IFilterDiagnostics
    {
        IEnumerable<string> Messages { get; }
        void AddMessage(string message);
    }
}
