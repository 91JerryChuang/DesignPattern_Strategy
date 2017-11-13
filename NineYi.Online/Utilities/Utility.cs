using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineYi.Online.Characters;
using NineYi.Online.Enums;

namespace NineYi.Online.Utilities
{
    public static class Utility
    {
        /// <summary>
        /// 產生選擇題的問題文字。
        /// </summary>
        /// <typeparam name="TEnum">列舉型別。</typeparam>
        /// <param name="question">問題。</param>
        /// <returns>選擇題的問題文字。</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateMultipleChoiceQuestion<TEnum>(string question)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(TEnum);
            var paramsChecklist = new Dictionary<string, Func<bool>>
            {
                { nameof(TEnum), () => enumType.IsEnum == false },
                { nameof(question), () => string.IsNullOrWhiteSpace(question) }
            };

            var paramName = paramsChecklist.FirstOrDefault(x => x.Value() == true).Key;
            if (string.IsNullOrWhiteSpace(paramName) == false)
            {
                throw new ArgumentException(paramName);
            }

            var choiceOptions = GetChoiceOptions<TEnum>();

            var multipleChoiceQuestion = new StringBuilder()
                .AppendLine(question)
                .AppendLine(choiceOptions)
                .ToString();

            return multipleChoiceQuestion;
        }

        /// <summary>
        /// 取得選項文字。
        /// </summary>
        /// <typeparam name="TEnum">列舉型別。</typeparam>
        /// <returns>選項文字。</returns>
        /// <exception cref="ArgumentException">TEnum</exception>
        public static string GetChoiceOptions<TEnum>()
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(TEnum);
            if (enumType.IsEnum == false)
            {
                throw new ArgumentException(nameof(TEnum));
            }

            var descriptions = GetDescriptions<TEnum>();

            var choiceOptions = string.Join("、", descriptions.Select(x =>
                $"({Convert.ChangeType(x.Key, enumType.GetEnumUnderlyingType()).ToString()}){x.Value}"));

            return choiceOptions.ToString();
        }

        /// <summary>
        /// 取得使用者輸入值。
        /// </summary>
        /// <typeparam name="TResult">回傳值的型別。</typeparam>
        /// <param name="question">問題。</param>
        /// <param name="converter">輸入值的轉換器。</param>
        /// <param name="validator">輸入值的驗證器。</param>
        /// <returns>使用者輸入值。</returns>
        /// <exception cref="ArgumentException">question</exception>
        public static TResult GetUserInput<TResult>(string question, Func<string, TResult> converter, Func<TResult, bool> validator)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException(nameof(question));
            }

            TResult result = default(TResult);
            var isInputError = true;

            do
            {
                try
                {
                    Console.Write(question);
                    var input = Console.ReadLine();
                    result = converter(input);
                    isInputError = validator(result) == false;

                    if (isInputError)
                    {
                        Console.WriteLine($"輸入錯誤請重新輸入。{Environment.NewLine}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"輸入錯誤請重新輸入。{Environment.NewLine}");
                }
            } while (isInputError);

            return result;
        }

        /// <summary>
        /// 取得列舉描述集合。
        /// </summary>
        /// <typeparam name="TEnum">列舉型別。</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException">TEnum</exception>
        public static IDictionary<TEnum, string> GetDescriptions<TEnum>()
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var enumType = typeof(TEnum);
            if (enumType.IsEnum == false)
            {
                throw new ArgumentException(nameof(TEnum));
            }

            var descriptions = new Dictionary<TEnum, string>();

            foreach (TEnum enumValue in Enum.GetValues(enumType))
            {
                var enumName = enumValue.ToString();

                var descriptionAttributes =
                    enumValue.GetType().GetField(enumName)
                        .GetCustomAttributes(typeof(DescriptionAttribute), false);

                var description = descriptionAttributes.Length > 0
                    ? ((DescriptionAttribute)descriptionAttributes[0]).Description
                    : enumName;

                descriptions.Add(enumValue, description);
            }

            return descriptions;
        }

        /// <summary>
        /// GetCharacterFactory
        /// </summary>
        /// <param name="characterType"></param>
        /// <returns>ICharacterFactory</returns>
        public static ICharacterFactory GetCharacterFactory(CharacterEnum characterType)
        {
            switch (characterType)
            {
                case CharacterEnum.Prince:
                    return new PrinceFactory();
                case CharacterEnum.Knight:
                    return new KnightFactory();
                case CharacterEnum.Elf:
                    return new ElfFactory();
                case CharacterEnum.Wizard:
                    return new WizardFactory();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
