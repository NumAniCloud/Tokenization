using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Math;
using Tokenization.Model.Objects;
using Tokenization.Model.Targeting;

namespace Tokenization.Model.View
{
    public interface IBattleView
    {
        Task<BattleToken> InputTokenAsync(BattleContext context, Player doer);
        Task<Skill> InputActionAsync(BattleContext context, Player player, BattleToken token);
        Task EnsureSelfTarget(BattleToken token);
        Task<ISkillTarget> InputTargetAsync(BattleContext context, Player doer, BattleToken token, Skill skill);
        Task ShowMove(BattleToken token, Vector2 distance);
    }
}
