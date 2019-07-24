using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenization.Model.BattleFlow
{
    class ActiveTurn
    {
        public async Task<CommandsInTurn> RunAsync(BattleContext context, Player player)
        {
            var tokenSelection = new TokenSelection(context, player);
            var actionSelection = await tokenSelection.DetermineNextStepAsync();
            var targetSelection = await actionSelection.DetermineNextStepAsync();
            var invocation = await targetSelection.DetermineNextStepAsync();
            return await invocation.DetermineNextStepAsync();
        }
    }
}
