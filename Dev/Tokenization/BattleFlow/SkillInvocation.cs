using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.Objects;
using Tokenization.Model.Targeting;

namespace Tokenization.Model.BattleFlow
{
    public class SkillInvocation
    {
        private readonly BattleContext context;
        private readonly Player doer;
        private readonly BattleToken token;
        private readonly Skill skill;
        private readonly ISkillTarget target;

        internal SkillInvocation(BattleContext context, Player doer, BattleToken token, Skill skill, ISkillTarget target)
        {
            this.context = context;
            this.doer = doer;
            this.token = token;
            this.skill = skill;
            this.target = target;
        }

        public Player Doer => doer;

        public BattleToken Token => token;

        public Task<CommandsInTurn> DetermineNextStepAsync()
        {
            return skill.Property.DetermineCommandsAsync(this);
        }
    }
}
