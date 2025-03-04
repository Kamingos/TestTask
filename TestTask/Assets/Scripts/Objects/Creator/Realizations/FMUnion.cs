using UnityEngine;

public class FMUnion : AbstractObjectCreator
{
    private Sprite sprite;
    public override GameObject CreateObject()
    {

        sprite = AssetDownloader.GetSprite(1);

        GameObject temp = new GameObject();

        // добавление компонентов
        SpriteRenderer renderer = temp.AddComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = temp.AddComponent<BoxCollider2D>();
        ObjectStateMachine objectStateMachine = temp.AddComponent<ObjectStateMachine>();

        MoveModule moveModule = temp.AddComponent<MoveModule>();
        SearchModule searchModule = temp.AddComponent<SearchModule>();

        // инит
        moveModule.Init(objectStateMachine);
        searchModule.Init(objectStateMachine);

        // настройки
        renderer.sprite = sprite;

        boxCollider2D.size = new Vector2(1, 1);

        renderer.sortingOrder = 20;

        return temp;
    }
}


