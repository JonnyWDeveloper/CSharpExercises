namespace Ovn5
{
    internal interface IUI : IEnumerable<IUI>
        {
        void Animate(string text);
        void GetMainMenu();
        void GetSubMenuGarage();
        void InstructionsLeavingGarage();
        void SetConsoleTitle();
        void SnippetAnyKeyToExit();
    }
}