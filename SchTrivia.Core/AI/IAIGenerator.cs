using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchTrivia.Core.AI
{
    public interface IAIGenerator
    {
        public Task<IQuestion> Generate(string prompt);
    }
}
