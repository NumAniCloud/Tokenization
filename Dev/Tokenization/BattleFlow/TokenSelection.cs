using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.Objects;

namespace Tokenization.Model.BattleFlow
{
    class TokenSelection
    {
        private readonly BattleContext context;
        private readonly Player doer;

        public TokenSelection(BattleContext context, Player doer)
        {
            this.context = context;
            this.doer = doer;
        }

        public async Task<ActionSelection> DetermineNextStepAsync()
        {
            BattleToken token = await context.View.InputTokenAsync(context, doer);
            return new ActionSelection(context, doer, token);
        }
    }
}
