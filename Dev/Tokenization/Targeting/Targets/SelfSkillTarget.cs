using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Common;
using Tokenization.Model.Objects;

namespace Tokenization.Model.Targeting.Targets
{
    class SelfSkillTarget : ISkillTarget
    {
        public BattleToken[] GetTargetTokens(SkillInvocation invocation)
        {
            return invocation.Token.Wrap();
        }
    }
}
