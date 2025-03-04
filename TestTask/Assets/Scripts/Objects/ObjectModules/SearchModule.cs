using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchModule : MonoBehaviour
{
    private ObjectStateMachine stateMachine;

    List<Collider2D> overlapList;
    Vector2 Direction;
    Vector3 tempPos;

    public void Init(ObjectStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;

        overlapList = new();
        tempPos = new Vector3();

        stateMachine.OnChangeState += (_) => { if (_ == ObjectState.Searching) StartCoroutine(Searching()); };
    }

    IEnumerator Searching()
    {
        // первая часть - выпускаем колайдер
        overlapList = Physics2D.OverlapCircleAll(Pointer.MousePosition, 1f, 1<<2).ToList();

        // вторая часть - ищем ближайший
        overlapList = overlapList.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();

        tempPos = (overlapList.Count>0) ? overlapList.First().transform.position : Vector3.down;

        // третья часть - выпускаем рейкаст до объекта и идём к нему
        Direction = (overlapList.Count > 0) ? (tempPos - transform.position).normalized : Vector3.down;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, 10f, 1 << 2);

        if (hit.collider != null)
        {
            tempPos = hit.point;
        }


        if (tempPos == Vector3.zero) yield break;

        tempPos = new Vector3(tempPos.x, tempPos.y, -2f);

        Tweener tween = transform.DOMove(tempPos, 0.3f).SetEase(Ease.OutBack);

        tempPos = Vector3.zero;

        stateMachine.SetRestState();
        GameStateMachine.SetDefaultMode();
    }
}
