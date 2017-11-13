using System;
using NineYi.Online.Enums;

namespace NineYi.Online.Weapons
{
    public class BowBehavior : WeaponBehavior
    {
        public BowBehavior(CharacterEnum characterType) 
            : base(characterType)
        {
        }

        public override void UseWeapon()
        {
            Console.WriteLine("拉弓射箭");
        }
    }
}
