using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LayerModule : MonoBehaviour
{
    private List<Collider2D> overlapList;

    public void Init()
    {
        GameStateMachine.OnChange += _ => { if (_ == GameMode.Default) SortHandler(); };
    }

    private void SortHandler()
    {
        // первая часть - выпускаем колайдер
        overlapList = Physics2D.OverlapCircleAll(Pointer.MousePosition, 1f, 0x1).ToList();

        overlapList.Remove(overlapList.Find((x) => x.name == GetComponent<BoxCollider2D>().name));

        // вторая часть - ищем ближайший
        overlapList = overlapList.Where(o => o.isTrigger==true).ToList();
        overlapList = overlapList.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();

        Debug.Log(overlapList.Count);

        if (overlapList.Count<1) return;

        if (transform.position.y <= overlapList.First().gameObject.transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = overlapList.First().gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
        else if (transform.position.y > overlapList.First().gameObject.transform.position.y)
        {
            overlapList.First().gameObject.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }

    }

}
