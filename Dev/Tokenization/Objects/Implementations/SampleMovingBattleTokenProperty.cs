using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenization.Model.Objects.Implementations
{
    class SampleMovingBattleTokenProperty : IBattleTokenProperty
    {
        public string Id => "Nac.Sample.Token.SampleMoving";

        public string Name => "Sample Token";

        public string[] Skills => new string[]
        {
            "Nac.Sample.Skill.SampleMove"
        };

        public string Image => "Textures/Token1.png";

        public string ProfileImage => "Textures/SampleProfileGraphic.png";
    }
}
