using UnityEngine;
using UnityEngine.U2D;

public class FMRandom : AbstractObjectCreator
{
    private Sprite sprite;
    public override GameObject CreateObject()
    {
        sprite = AssetDownloader.GetSprite(Random.Range(0, AssetDownloader.GetAtlasLenght()));

        GameObject temp = new GameObject();

        // добавление компонентов
        SpriteRenderer renderer = temp.AddComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = temp.AddComponent<BoxCollider2D>();
        ObjectStateMachine objectStateMachine = temp.AddComponent<ObjectStateMachine>();
        LayerModule layer = temp.AddComponent<LayerModule>();

        MoveModule moveModule = temp.AddComponent<MoveModule>();
        SearchModule searchModule = temp.AddComponent<SearchModule>();

        // инит
        moveModule.Init(objectStateMachine);
        searchModule.Init(objectStateMachine);
        layer.Init(objectStateMachine);

        // настройки
        renderer.sprite = sprite;

        boxCollider2D.size = new Vector2(1, 1);

        renderer.sortingOrder = 20;

        temp.tag = "Object";

        boxCollider2D.isTrigger = true;

        return temp;
    }
}

