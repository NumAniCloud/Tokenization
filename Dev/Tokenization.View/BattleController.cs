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
        private readonly Dictionary<int, ProfileCardView> Profiles = new Dictionary<int, ProfileCardView>();
        private readonly Scene Scene;
        private readonly Layer2D Layer;
        private readonly ModelToViewCoordinateConverter coordinateConverter;
        private readonly Font headerFont;
        private readonly Font planeFont;

        public BattleController(BattleContext context)
        {
            var random = new Random();
            Layer = new Layer2D();
            Scene = new Scene();
            coordinateConverter = new ModelToViewCoordinateConverter();
            headerFont = Engine.Graphics.CreateFont("Fonts/Header.aff");
            planeFont = Engine.Graphics.CreateFont("Fonts/Body.aff");

            var background = new GeometryObject2D()
            {
                Shape = new RectangleShape
                {
                    DrawingArea = new RectF(0, 0, 1280, 720),
                },
                Color = new Color(255, 255, 255),
                DrawingPriority = -2
            };
            Layer.AddObject(background);

            var localPlayerProfileObject = new TextureObject2D()
            {
                Position = new Vector2DF(1280, 720),
            };
            var remotePlayerProfileObject = new TextureObject2D()
            {
                Position = new Vector2DF(0, 0),
                Angle = 180,
            };
            Layer.AddObject(localPlayerProfileObject);
            Layer.AddObject(remotePlayerProfileObject);

            for (int i = 0; i < context.LocalPlayer.Tokens.Length; i++)
            {
                var token = context.LocalPlayer.Tokens[i];
                ShowToken(random, token, localPlayerProfileObject, i);
            }
            for (int i = 0; i < context.RemotePlayer.Tokens.Length; i++)
            {
                var token = context.RemotePlayer.Tokens[i];
                ShowToken(random, token, remotePlayerProfileObject, i);
            }

            Scene.AddLayer(Layer);
        }

        private void ShowToken(Random random, BattleToken token, Object2D parent, int index)
        {
            var tokenObj = new BattleTokenView(token);
            Tokens[token.Index] = tokenObj;
            Layer.AddObject(tokenObj);

            var x = (float)random.NextDouble() * 2 - 1;
            var y = (float)random.NextDouble() * 2 - 1;
            tokenObj.Position = coordinateConverter.Convert(new Vector2DF(x, y));

            var profileObj = new ProfileCardView(token, headerFont, planeFont);
            Profiles[token.Index] = profileObj;
            parent.AddChild(profileObj, ChildManagementMode.Disposal | ChildManagementMode.RegistrationToLayer,
                ChildTransformingMode.All);

            var sizeX = 160.0f;
            var px = (index % 2) * (sizeX + 4);
            var py = (index / 2) * (sizeX * 1.61805f + 4);
            profileObj.Position = new Vector2DF(-px, -py) - new Vector2DF(sizeX, sizeX * 1.61805f);

            var scale = sizeX / profileObj.CardSize.X;
            profileObj.Scale = new Vector2DF(scale, scale);
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
            var tokenStream = doer.Tokens.Join(Tokens, i => i.Index, o => o.Key, (i, o) => o)
                .Select(x => x.Value.OnClicked.Select(u => x.Value.Model));
            var profileStream = doer.Tokens.Join(Profiles, i => i.Index, o => o.Key, (i, o) => o)
                .Select(x => x.Value.OnClicked.Select(u => x.Value.Model));
            return await Observable.Merge(tokenStream.Concat(profileStream)).Take(1);
        }

        public Task ShowMove(BattleToken token, Vector2 distance)
        {
            throw new NotImplementedException();
        }
    }
}
