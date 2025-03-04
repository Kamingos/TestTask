using UnityEngine;

public class FMRandom : AbstractObjectCreator
{
    private Sprite sprite;
    private Transform t;
    public override GameObject CreateObject()
    {
        sprite = AssetDownloader.GetSprite(Random.Range(0, AssetDownloader.GetAtlasLenght()));

        GameObject temp = new GameObject();

        SpriteRenderer renderer = temp.AddComponent<SpriteRenderer>();

        renderer.sprite = sprite;

        renderer.sortingOrder = 20;

        return temp;
    }
}
