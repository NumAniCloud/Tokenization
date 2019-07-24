using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;

namespace Tokenization.Model.BattlePrimitive
{
    public interface IBattlePrimitive
    {
        Task RunAsync(BattleContext context);
    }
}
