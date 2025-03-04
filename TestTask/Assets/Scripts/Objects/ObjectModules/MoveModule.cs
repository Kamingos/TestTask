using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveModule : MonoBehaviour
{
    private ObjectStateMachine stateMachine;
    private Color myColor = new Color(0.7f, 0.7f, 0.7f);
    public void Init(ObjectStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }


    private void OnMouseDown()
    {
        stateMachine.SetDragState();
        GameStateMachine.SetBuildMode();
        transform.DOScale(1.2f, 0.1f).SetEase(Ease.OutBack);
        GetComponent<SpriteRenderer>().color = myColor;
    }
    private void OnMouseDrag()
    {
        transform.position = Pointer.MousePosition;
    }

    private void OnMouseUp()
    {
        stateMachine.SetSearchingState();
        transform.DOScale(1f, 0.1f).SetEase(Ease.OutBack);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
