using asd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.Math;
using Tokenization.Model.Objects;
using Tokenization.Model.Targeting;
using Tokenization.Model.View;
using Tokenization.View.Objects;

namespace Tokenization.View
{
    class BattleController : IBattleView
    {
        private readonly Dictionary<int, BattleTokenView> Tokens = new Dictionary<int, BattleTokenView>();
        private readonly Scene Scene;
        private readonly Layer2D Layer;

        public BattleController(BattleContext context)
        {
            var random = new Random();
            Layer = new Layer2D();
            Scene = new Scene();

            foreach (var token in context.LocalPlayer.Tokens.Concat(context.RemotePlayer.Tokens))
            {
                var obj = new BattleTokenView(token);
                Tokens[token.Index] = obj;
                Layer.AddObject(obj);

                var x = (random.NextDouble() * 2 - 1) * 300 + 640;
                var y = (random.NextDouble() * 2 - 1) * 300 + 320;
                obj.Position = new Vector2DF((float)x, (float)y);
            }

            Scene.AddLayer(Layer);
        }

        public void Transition()
        {
            Engine.ChangeScene(Scene);
        }

        public Task EnsureSelfTarget(BattleToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> InputActionAsync(BattleContext context, Player player, BattleToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ISkillTarget> InputTargetAsync(BattleContext context, Player doer, BattleToken token, Skill skill)
        {
            throw new NotImplementedException();
        }

        public async Task<BattleToken> InputTokenAsync(BattleContext context, Player doer)
        {
            Console.WriteLine("トークン選択");
            var clickStreams = doer.Tokens.Join(Tokens, i => i.Index, o => o.Key, (i, o) => o)
                .Select(x => x.Value.OnClicked.Select(u => x.Value.Model));
            return await Observable.Merge(clickStreams).Take(1);
        }

        public Task ShowMove(BattleToken token, Vector2 distance)
        {
            throw new NotImplementedException();
        }
    }
}
