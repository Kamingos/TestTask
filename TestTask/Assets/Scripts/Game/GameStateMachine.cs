using System;


public static class GameStateMachine
{
    public static event Action<GameMode> OnChange;

    public static GameMode CurrentState;

    public static void SetNothingMode() => ChangeGameMode(GameMode.Nothing);
    public static void SetDefaultMode() => ChangeGameMode(GameMode.Default);
    public static void SetBuildMode() => ChangeGameMode(GameMode.Building);

    private static void ChangeGameMode(GameMode gm)
    {
        CurrentState = gm;

        OnChange += _ => { };

        OnChange.Invoke(CurrentState);
    }
}
