using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.Objects;
using Tokenization.Model.View;

namespace Tokenization.Model.BattleFlow
{
    public class BattleContext
    {
        public Player LocalPlayer { get; set; }
        public Player RemotePlayer { get; set; }
        public IBattleView View { get; set; }
    }
}
