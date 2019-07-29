using Altseed.Reactive;
using asd;
using System;
using System.Reactive;
using System.Reactive.Subjects;

namespace Tokenization.View.Objects
{
    class ProfileCardView : TextureObject2D
    {
        public IObservable<Unit> OnClicked => onClicked_;
        public Model.Objects.BattleToken Model { get; }
        public Vector2DI CardSize => size;

        private readonly Subject<Unit> onClicked_ = new Subject<Unit>();
        private readonly Vector2DF hitBoxOrigin;
        private readonly Vector2DI size;

        public ProfileCardView(Model.Objects.BattleToken model, Font headerFont, Font planeFont)
        {
            void AddChild(Object2D obj)
            {
                base.AddChild(obj, ChildManagementMode.Disposal | ChildManagementMode.RegistrationToLayer,
                    ChildTransformingMode.All);
            }

            this.Model = model;

            var illust = new TextureObject2D()
            {
                Texture = Engine.Graphics.CreateTexture2D(model.Property.ProfileImage),
                TextureFilterType = TextureFilterType.Linear,
            };
            var overlay = new TextureObject2D()
            {
                Texture = Engine.Graphics.CreateTexture2D("Textures/ProfileOverlay.png"),
                DrawingPriority = 1,
                TextureFilterType = TextureFilterType.Linear,
            };
            var name = new TextObject2D()
            {
                Font = headerFont,
                Position = new Vector2DF(overlay.Texture.Size.X / 2, 40),
                Text = model.Property.Name,
                Color = new Color(0, 0, 0),
                DrawingPriority = 2,
            };
            name.SetCenterPosition(Altseed.Reactive.CenterPosition.CenterCenter);

            int skillIndex = 0;
            foreach (var skill in model.Skills)
            {
                var header = new TextObject2D()
                {
                    Font = headerFont,
                    Scale = new Vector2DF(1, 1) / 1.5f,
                    Color = new Color(0, 0, 0),
                    Position = new Vector2DF(25, 359 + skillIndex * 88),
                    Text = skill.Property.Name,
                    DrawingPriority = 2,
                };
                var body = new TextObject2D()
                {
                    Font = planeFont,
                    Scale = new Vector2DF(1, 1) * 3 / 4,
                    Color = new Color(0, 0, 0),
                    Position = new Vector2DF(51, 389 + skillIndex * 88),
                    Text = skill.Property.Description,
                    DrawingPriority = 2,
                };
                AddChild(header);
                AddChild(body);
            }

            AddChild(illust);
            AddChild(overlay);
            AddChild(name);

            size = overlay.Texture.Size;
        }
        
        protected override void OnUpdate()
        {
            if (Engine.Mouse.LeftButton.ButtonState == ButtonState.Push)
            {
                var position = Engine.Mouse.Position;
                if(hitBoxOrigin.X <= position.X
                    && hitBoxOrigin.X + size.X >= position.X
                    && hitBoxOrigin.Y <= position.Y
                    && hitBoxOrigin.Y + size.Y >= position.Y)
                {
                    onClicked_.OnNext(Unit.Default);
                }
            }
        }
    }
}