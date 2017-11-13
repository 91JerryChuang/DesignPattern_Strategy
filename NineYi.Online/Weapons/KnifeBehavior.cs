using System;
using NineYi.Online.Enums;

namespace NineYi.Online.Weapons
{
    public class KnifeBehavior : WeaponBehavior
    {
        public KnifeBehavior(CharacterEnum characterType) 
            : base(characterType)
        {
        }

        public override void UseWeapon()
        {
            Console.WriteLine("匕首刺擊");
        }
    }
}
