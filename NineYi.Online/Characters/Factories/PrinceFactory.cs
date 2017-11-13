namespace NineYi.Online.Characters
{
    public class PrinceFactory : ICharacterFactory
    {
        public CharacterBase CreateCharacter(string name)
        {
            var prince = new Prince(name);

            return prince;
        }
    }
}
