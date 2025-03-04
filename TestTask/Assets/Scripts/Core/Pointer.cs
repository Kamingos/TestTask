using UnityEngine;

public class Pointer : MonoBehaviour
{
    RaycastHit2D aHit;
    public static Vector3 MousePosition { get; private set; }

    private void Start()
    {
        aHit = new RaycastHit2D(); //инициализируем луч.
    }
    void Update()
    {
        if (Camera.main.orthographic)
        {
            // Присваиваем нашему лучу позицию мыши при клике .
            aHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100f, 0b111);

            MousePosition = aHit.point;
        }
    }
}
