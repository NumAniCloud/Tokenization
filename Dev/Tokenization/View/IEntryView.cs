using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;

namespace Tokenization.Model.View
{
    public interface IEntryView
    {
        IBattleView GotoBattle(BattleContext context);
    }
}
