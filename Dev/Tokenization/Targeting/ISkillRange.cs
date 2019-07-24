using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Objects;

namespace Tokenization.Model.Targeting
{
    public interface ISkillRange
    {
        Task<ISkillTarget> InputTargetAsync(BattleContext context, Player doer, BattleToken token);
    }
}
