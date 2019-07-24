using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.BattlePrimitive;
using Tokenization.Model.Targeting;
using Tokenization.Model.Targeting.Variants;

namespace Tokenization.Model.Objects.Implementations
{
    class SampleMoveSkillProperty : ISkillProperty
    {
        public ISkillRange Range => new SelfSkillRange();

        public string Id => "Nac.Sample.Skill.SampleMove";

        public string Name => "Move";

        public string Description => "Move forward.";

        public Task<CommandsInTurn> DetermineCommandsAsync(SkillInvocation invocation)
        {
            var commands = new IBattlePrimitive[]
            {
                new MoveBattlePrimitive(invocation.Token, new Math.Vector2(0, -3)),
            };
            return Task.FromResult(new CommandsInTurn(commands));
        }
    }
}
