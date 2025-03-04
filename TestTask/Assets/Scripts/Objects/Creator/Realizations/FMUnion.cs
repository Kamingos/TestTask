using UnityEngine;

public class FMUnion : AbstractObjectCreator
{
    private Sprite sprite;
    private Transform t;
    public override GameObject CreateObject()
    {
        sprite = AssetDownloader.GetSprite(1);

        GameObject temp = new GameObject();

        SpriteRenderer renderer = temp.AddComponent<SpriteRenderer>();

        renderer.sprite = sprite;

        renderer.sortingOrder = 20;

        return temp;
    }
}
