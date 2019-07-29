using asd;
using Tokenization.Model.Math;

namespace Tokenization
{
    static class MathHelper
    {
        public static Vector2DF ToAsd(Vector2 source)
        {
            return new Vector2DF(source.X, source.Y);
        }
    }
}