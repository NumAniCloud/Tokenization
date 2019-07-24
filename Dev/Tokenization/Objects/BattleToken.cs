using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.Math;

namespace Tokenization.Model.Objects
{
    public class BattleToken
    {
        public int Index { get; set; }
        public IBattleTokenProperty Property { get; set; }
        public Vector2 Position { get; set; }
        public bool AlreadyActed { get; set; }

        public BattleToken(IBattleTokenProperty property)
        {
            Property = property;
        }
    }
}
