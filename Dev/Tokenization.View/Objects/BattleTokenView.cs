using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace Tokenization.View.Objects
{
    class BattleTokenView : TextureObject2D
    {
        public IObservable<Unit> OnClicked => onClicked_;

        private readonly Subject<Unit> onClicked_ = new Subject<Unit>();

        public BattleTokenView(Model.Objects.BattleToken model)
        {
            Model = model;
            Texture = Engine.Graphics.CreateTexture2D(model.Property.Image);
        }

        public Model.Objects.BattleToken Model { get; }

        protected override void OnUpdate()
        {
            if (Engine.Mouse.LeftButton.ButtonState == ButtonState.Push)
            {
                var distance = Position - Engine.Mouse.Position;
                if (distance.SquaredLength <= 32 * 32)
                {
                    onClicked_.OnNext(Unit.Default);
                }
            }
        }
    }
}
