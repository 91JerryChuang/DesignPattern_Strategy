using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineYi.Online.Enums;

namespace NineYi.Online.Characters
{
    public interface ICharacterFactory
    {
        CharacterBase CreateCharacter(string name);
    }
}
