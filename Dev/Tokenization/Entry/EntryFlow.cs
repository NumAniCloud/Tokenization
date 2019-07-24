using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;

namespace Tokenization.Model.Entry
{
    class EntryFlow
    {
        public async Task RunAsync()
        {
            var battle = new BattleProcess();
            await battle.RunAsync();
        }
    }
}
