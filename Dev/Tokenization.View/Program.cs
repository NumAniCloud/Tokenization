using asd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenization.View.Entry;

namespace Tokenization.View
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Initialize("Meme Meets Me!", 1280, 720, new EngineOption() { IsFullScreen = false });
            Engine.File.AddRootDirectory("Resources");

            var entryView = new EntryView();
            var entryFlow = new Model.Entry.EntryFlow(entryView);
            var _ = entryFlow.RunAsync();

            while (Engine.DoEvents())
            {
                Engine.Update();
            }

            Engine.Terminate();
        }
    }
}
