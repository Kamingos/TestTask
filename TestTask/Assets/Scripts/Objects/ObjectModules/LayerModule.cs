using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LayerModule : MonoBehaviour
{
    private List<Collider2D> overlapList;

    public void Init(ObjectStateMachine objectStateMachine)
    {
        objectStateMachine.OnChangeState += _ => { if (_ == ObjectState.Rest) SortHandler(); };
    }

    private void SortHandler()
    {
        // первая часть - выпускаем колайдер
        overlapList = Physics2D.OverlapCircleAll(Pointer.MousePosition, 2f, 0x1).ToList();

        overlapList.Remove(overlapList.Find((x) => x.transform.position == gameObject.transform.position));

        // вторая часть - ищем ближайший
        overlapList = overlapList.Where(o => o.isTrigger==true).ToList();
        overlapList = overlapList.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();

        Debug.Log(overlapList.Count);

        if (overlapList.Count < 1) return;

        // временные файлы
        var tempPos = overlapList.First().gameObject.transform.position;
        var tempSortLevel = gameObject.GetComponent<SpriteRenderer>();
        var tempOtherSpriteRenderer = overlapList.First().gameObject.GetComponent<SpriteRenderer>();

        if (transform.position.y <= tempPos.y)
        {
            tempSortLevel.sortingOrder = tempOtherSpriteRenderer.sortingOrder + 1;
        }
        if (transform.position.y > tempPos.y)
        {
            tempOtherSpriteRenderer.sortingOrder = tempSortLevel.sortingOrder + 1;
        }

    }

}
