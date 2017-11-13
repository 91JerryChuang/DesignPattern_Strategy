using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using NineYi.Online.Characters;
using NineYi.Online.Enums;
using NineYi.Online.Utilities;

namespace NineYi.Online
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 創立角色。
            var choiceCharacterQuestion = Utility.GenerateMultipleChoiceQuestion<CharacterEnum>("請選擇欲創立的角色？");
            var characterTypeChoice = Utility.GetUserInput(
                choiceCharacterQuestion,
                (input) => (CharacterEnum)Enum.Parse(typeof(CharacterEnum), input),
                (result) => Enum.IsDefined(typeof(CharacterEnum), result));

            var characterFactory = Utility.GetCharacterFactory(characterTypeChoice);
            Console.WriteLine("請輸入角色名稱：");
            var characterName = Console.ReadLine();
            var character = characterFactory.CreateCharacter(characterName);
            Console.WriteLine($"角色創立完成，\"{characterName}\" 歡迎您。");

            Console.WriteLine("接下任鍵繼續遊戲...\n");
            Console.ReadKey();

            Console.WriteLine($"\"{characterName}\" 先攻擊木人椿3次，熟悉武器操作：\n");

            var fightCount = 1;
            do
            {
                var choiceWeaponQuestion = Utility.GenerateMultipleChoiceQuestion<WeaponEnum>("請選擇武器");
                var weaponChoice = Utility.GetUserInput(
                    choiceWeaponQuestion,
                    (input) => (WeaponEnum)Enum.Parse(typeof(WeaponEnum), input),
                    (result) => Enum.IsDefined(typeof(WeaponEnum), result));

                character.Fight(weaponChoice);

                Console.WriteLine($"對木人椿發動 \"{fightCount}\" 次攻擊\n");
                fightCount++;
            } while (fightCount <= 3);

            Console.WriteLine($"\"{characterName}\" 恭喜您剛成攻擊木人椿3次任務\n");
            Console.ReadLine();
        }
    }
}
