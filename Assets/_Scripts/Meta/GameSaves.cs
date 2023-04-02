using Tools;
using Tools.Reactive;

public class GameSaves : Singleton<GameSaves>
{
    public GameSaves()
    {
        selectedDroneName.ConnectToSaver(nameof(selectedDroneName));
        playerName.ConnectToSaver(nameof(playerName));
        playerMoney.ConnectToSaver(nameof(playerMoney));
    }
    public Reactive<string> selectedDroneName = new Reactive<string>();
    public Reactive<string> playerName = new();
    public Reactive<int> playerMoney = new();
}
