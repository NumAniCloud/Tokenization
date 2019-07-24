using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.Objects;
using Tokenization.Model.Targeting;

namespace Tokenization.Model.BattleFlow
{
    class TargetSelection
    {
        private readonly BattleContext context;
        private readonly Player doer;
        private readonly BattleToken token;
        private readonly Skill skill;

        public TargetSelection(BattleContext context, Player doer, BattleToken token, Skill skill)
        {
            this.context = context;
            this.doer = doer;
            this.token = token;
            this.skill = skill;
        }

        public async Task<SkillInvocation> DetermineNextStepAsync()
        {
            ISkillTarget target = await skill.Property.Range.InputTargetAsync(context, doer, token);
            return new SkillInvocation(context, doer, token, skill, target);
        }
    }
}
