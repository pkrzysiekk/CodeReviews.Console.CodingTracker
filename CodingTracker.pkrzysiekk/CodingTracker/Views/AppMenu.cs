using CodingTracker.Controllers;
using CodingTracker.Models;
using Spectre.Console;


namespace CodingTracker.Views
{
   public class AppMenu
    {

        private readonly DbController _dbController;
        public AppMenu()
        {
            _dbController = new DbController();
        }
        public void Show()
        {
            while (true)
            {
                var choice = UserInput.GetUserChoice();
                List<CodingSession> sessions= new List<CodingSession>();
                switch (choice)
                {
                    case MenuChoices.DisplayRecords:
                        sessions = _dbController.GetAllRecords();
                        TableView.ShowTable(sessions);
                        break;
                    case MenuChoices.InsertRecord:
                        var recordInput = UserInput.GetUserRecordInput();
                        _dbController.Insert(recordInput);
                        break;
                    case MenuChoices.RemoveRecord:
                         sessions= _dbController.GetAllRecords();
                        int? idToRemove = UserInput.GetUserId(sessions);
                        _dbController.Remove(idToRemove);
                        AnsiConsole.MarkupLine("[green] Removed succesfully! [/]");
                        break;
                    case MenuChoices.EditRecord:
                       sessions = _dbController.GetAllRecords();
                       int? idToUpdate= UserInput.GetUserId(sessions);
                       var updatedRecord= UserInput.GetUserRecordInput();
                        _dbController.Update(idToUpdate, updatedRecord);
                        break;
                    case MenuChoices.Exit:
                        AnsiConsole.MarkupLine("[Green] Goodbye! [/]");
                        return;

                }
            }
        }
    }
}
