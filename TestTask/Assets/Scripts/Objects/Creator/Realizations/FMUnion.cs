using UnityEngine;

public class FMUnion : AbstractObjectCreator
{
    private Sprite sprite;
    public override GameObject CreateObject()
    {

        sprite = AssetDownloader.GetSprite(1);

        GameObject temp = new GameObject();

        // ���������� �����������
        SpriteRenderer renderer = temp.AddComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = temp.AddComponent<BoxCollider2D>();
        ObjectStateMachine objectStateMachine = temp.AddComponent<ObjectStateMachine>();
        LayerModule layer = temp.AddComponent<LayerModule>();

        MoveModule moveModule = temp.AddComponent<MoveModule>();
        SearchModule searchModule = temp.AddComponent<SearchModule>();

        // ����
        moveModule.Init(objectStateMachine);
        searchModule.Init(objectStateMachine);
        layer.Init();

        // ���������
        renderer.sprite = sprite;

        boxCollider2D.size = new Vector2(1, 1);

        renderer.sortingOrder = 20;

        boxCollider2D.isTrigger = true;

        temp.tag = "Object";

        return temp;
    }
}


