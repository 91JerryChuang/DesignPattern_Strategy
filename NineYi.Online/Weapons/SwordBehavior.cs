using System;
using NineYi.Online.Enums;

namespace NineYi.Online.Weapons
{
    public class SwordBehavior : WeaponBehavior
    {
        public SwordBehavior(CharacterEnum characterType) 
            : base(characterType)
        {
        }

        public override void UseWeapon()
        {
            Console.WriteLine("揮舞長劍");
        }
    }
}
