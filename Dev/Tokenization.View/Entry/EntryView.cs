using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.Model.BattleFlow;
using Tokenization.Model.View;

namespace Tokenization.View.Entry
{
    class EntryView : IEntryView
    {
        public IBattleView GotoBattle(BattleContext context)
        {
            var view = new BattleController(context);
            view.Transition();
            return view;
        }
    }
}
