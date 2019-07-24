using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenization.Model.BattleFlow
{
    class BattleProcess
    {
        private readonly BattleContext context;

        public BattleProcess(BattleContext context)
        {
            this.context = context;
        }

        public async Task RunAsync()
        {
            var activeTurn = new ActiveTurn();
            while (true)
            {
                var commands = await activeTurn.RunAsync(context, context.LocalPlayer);
                foreach (var primitive in commands.Primitives)
                {
                    await primitive.RunAsync(context);
                }
            }
        }
    }
}
