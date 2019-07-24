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
        public int Index { get; private set; }
        public IBattleTokenProperty Property { get; private set; }
        public Vector2 Position { get; set; }
        public bool AlreadyActed { get; set; }

        public BattleToken(int index, IBattleTokenProperty property)
        {
            Index = index;
            Property = property;
        }
    }
}
