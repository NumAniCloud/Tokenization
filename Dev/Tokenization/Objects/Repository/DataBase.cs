using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenization.Model.Objects.Repository
{
    public class DataBase
    {
        public IBattleTokenProperty[] Tokens { get; set; }
        public ISkillProperty[] Skills { get; set; }
    }
}
