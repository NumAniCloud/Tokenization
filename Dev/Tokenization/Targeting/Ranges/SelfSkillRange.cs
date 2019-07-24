using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Objects;
using Tokenization.Model.Targeting.Targets;

namespace Tokenization.Model.Targeting.Variants
{
    class SelfSkillRange : ISkillRange
    {
        public async Task<ISkillTarget> InputTargetAsync(BattleContext context, Player doer, BattleToken token)
        {
            await context.View.EnsureSelfTarget(token);
            return new SelfSkillTarget();
        }
    }
}
