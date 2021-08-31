namespace Faust.PetShopApp.UI
{
    public interface IMenu
    {
        public void StartUI();
        public string AskQuestion(string question);
        public void Print(string value);
        public void PrintNewLine();
        public void ShowGreeting();

        public void DisplayMainMenu();
        public int GetNumberSelection();
        public void Clear();
        public void ShowMainMenu();

        public void PrintShowAllPets();
        public void PrintSearchPets();
        public void PrintCreatePet();
        public void PrintDeletePet();
        public void PrintUpdatePet();
    }
}