using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Objects;
using Tokenization.Model.Objects.Implementations;
using Tokenization.Model.View;

namespace Tokenization.Model.Entry
{
    public class EntryFlow
    {
        private readonly IEntryView view;

        public EntryFlow(IEntryView view)
        {
            this.view = view;
        }

        public async Task RunAsync()
        {
            var tokenProp1 = new SampleMovingBattleTokenProperty();
            var skills = new Skill[]
            {
                new Skill(){ Property = new SampleMoveSkillProperty() }
            };

            var battleContext = new BattleContext()
            {
                LocalPlayer = new Player()
                {
                    Tokens = new BattleToken[]
                    {
                        new BattleToken(0, tokenProp1, skills),
                    },
                },
                RemotePlayer = new Player()
                {
                    Tokens = new BattleToken[]
                    {
                        new BattleToken(1, tokenProp1, skills),
                    },
                },
            };
            var battleView = view.GotoBattle(battleContext);
            battleContext.View = battleView;
            var battleProcess = new BattleProcess(battleContext);
            await battleProcess.RunAsync();
        }
    }
}
