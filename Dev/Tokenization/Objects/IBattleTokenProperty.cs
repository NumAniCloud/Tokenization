using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenization.Model.Objects
{
    public interface IBattleTokenProperty
    {
        string Id { get; }
        string Name { get; }
        string[] Skills { get; }
        string Image { get; }
        string ProfileImage { get; }
    }
}
