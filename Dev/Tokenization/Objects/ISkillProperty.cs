using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Targeting;

namespace Tokenization.Model.Objects
{
    public interface ISkillProperty
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }
        ISkillRange Range { get; }
        Task<CommandsInTurn> DetermineCommandsAsync(SkillInvocation invocation);
    }
}
