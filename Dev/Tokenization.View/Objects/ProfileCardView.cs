using asd;
using System.Reactive;

namespace Tokenization.View.Objects
{
    class ProfileCardView : TextureObject2D
    {
        public IObservable<Unit> OnClicked => onClicked_;
        public Model.Objects.BattleToken Model { get; }

        private readonly Subject<Unit> onClicked_ = new Subject<Unit>();
        private readonly Vector2DF hitBoxOrigin;
        private readonly Vector2DI size;

        public ProfileCardView(Model.Objects.BattleToken model)
        {
            this.Model = model;

            var illust = new TextureObject2D()
            {
                Texture = Engine.Graphic.CreateTexture2D(model.Property.ProfileImage),
            };
            var overlay = new TextureObject2D()
            {
                Texture = Engine.Graphic.CreateTexture2D("Textures/ProfileOverlay.png"),
                DrawingPriority = 1,
            };

            AddChildObject(illust);
            AddChildObject(overlay);

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