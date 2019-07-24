using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
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
            var tokenProp1 = new Objects.Implementations.SampleMovingBattleTokenProperty();

            var battleContext = new BattleContext()
            {
                LocalPlayer = new Player()
                {
                    Tokens = new Objects.BattleToken[]
                    {
                        new Objects.BattleToken(0, tokenProp1),
                    },
                },
                RemotePlayer = new Player()
                {
                    Tokens = new Objects.BattleToken[]
                    {
                        new Objects.BattleToken(1, tokenProp1),
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
