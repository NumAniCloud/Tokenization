using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Math;
using Tokenization.Model.Objects;

namespace Tokenization.Model.BattlePrimitive
{
    class MoveBattlePrimitive : IBattlePrimitive
    {
        private readonly BattleToken token;
        private readonly Vector2 distance;

        public MoveBattlePrimitive(BattleToken token, Vector2 distance)
        {
            this.token = token;
            this.distance = distance;
        }

        public async Task RunAsync(BattleContext context)
        {
            await context.View.ShowMove(token, distance);
        }
    }
}
