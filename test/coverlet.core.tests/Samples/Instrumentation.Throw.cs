using System;
using System.Collections.Generic;
using System.Linq;

namespace Coverlet.Core.Samples.Tests
{
    public partial class Issue_890
    {
        private List<string> _values = new List<string>() { "value" };

        public void AddSkillRequired(string str)
        {
            if (_values.Any(v => v == str))
            {
                throw new InvalidOperationException();
            }
        }
    }
}
