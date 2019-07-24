using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.Objects;

namespace Tokenization.Model.BattleFlow
{
    class ActionSelection
    {
        private readonly BattleContext context;
        private readonly Player player;
        private readonly BattleToken token;

        public ActionSelection(BattleContext context, Player player, BattleToken token)
        {
            this.context = context;
            this.player = player;
            this.token = token;
        }

        public async Task<TargetSelection> DetermineNextStepAsync()
        {
            Skill skill = await context.View.InputActionAsync(context, player, token);
            return new TargetSelection(context, player, token, skill);
        }
    }
}
