using System;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    private View view;

    // создаю ещё одно событие, которое будет передавать в GameController
    public event Action<ObjectType> OnBtnPressed;
    public void Init(View _view)
    {
        view = _view;
        view.OnBtnPressed += (_) =>
        {
            switch (_)
            {
                case 0:
                    OnBtnPressed.Invoke(ObjectType.Onion);
                    break;
                case 1:
                    OnBtnPressed.Invoke(ObjectType.Sunflower);
                    break;
                case 2:
                    OnBtnPressed.Invoke(ObjectType.Random);
                    break;
                default:
                    break;
            }
        };

        GameStateMachine.OnChange += StateMachineHandler;
    }

    private void StateMachineHandler(GameMode gm)
    {
        switch (gm)
        {
            case GameMode.Nothing:
                break;
            case GameMode.Default:
                view.ActivateButttons();
                break;
            case GameMode.Building:
                view.DisableButttons();
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        GameStateMachine.OnChange -= StateMachineHandler;
    }
}
