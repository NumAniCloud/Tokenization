using asd;

namespace Tokenization.View
{
    class ModelToViewCoordinateConverter
    {
        private readonly float PixelPerMeter = 300;

        public Vector2DF Convert(Vector2DF source)
        {
            return ConvertDelta(source) + new Vector2DF(640, 360);
        }

        public Vector2DF ConvertBack(Vector2DF source)
        {
            return ConvertDeltaBack(source - new Vector2DF(640, 360));
        }

        public Vector2DF ConvertDelta(Vector2DF delta)
        {
            return delta * PixelPerMeter;
        }

        public Vector2DF ConvertDeltaBack(Vector2DF delta)
        {
            return delta / PixelPerMeter;
        }
    }
}