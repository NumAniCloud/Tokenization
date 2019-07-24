using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattlePrimitive;

namespace Tokenization.Model.BattleFlow
{
    public class CommandsInTurn
    {
        public CommandsInTurn(IBattlePrimitive[] primitives)
        {
            Primitives = primitives;
        }

        public IBattlePrimitive[] Primitives { get; }
    }
}
