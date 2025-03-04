using UnityEngine;

public class FMSunflower : AbstractObjectCreator
{
    private Sprite sprite;
    private Transform t;
    public override GameObject CreateObject()
    {
        sprite = AssetDownloader.GetSprite(11);

        GameObject temp = new GameObject();

        SpriteRenderer renderer = temp.AddComponent<SpriteRenderer>();

        renderer.sprite = sprite;

        renderer.sortingOrder = 20;

        return temp;
    }
}
