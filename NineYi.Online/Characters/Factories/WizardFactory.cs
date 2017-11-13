namespace NineYi.Online.Characters
{
    public class WizardFactory : ICharacterFactory
    {
        public CharacterBase CreateCharacter(string name)
        {
            var wizard = new Wizard(name);

            return wizard;
        }
    }
}
