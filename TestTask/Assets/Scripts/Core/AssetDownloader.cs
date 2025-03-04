using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetDownloader : MonoBehaviour
{
    private string atlasPath = "farmAtlas";

    private Texture2D texture;

    private static List<Sprite> sprites;
    public void Init()
    {
        sprites = new();

        DownloadAtlas();
    }

    //загрузчик атласа
    private void DownloadAtlas()
    {
        AsyncOperationHandle<Texture2D> handle = Addressables.LoadAssetAsync<Texture2D>(atlasPath);

        handle.WaitForCompletion();

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            texture = handle.Result;

            // преобразование Texture2D в суб.текстуры
            string atlasPath = AssetDatabase.GetAssetPath(texture);
            Object[] assets = AssetDatabase.LoadAllAssetsAtPath(atlasPath);

            foreach (Object asset in assets)
            {
                if (AssetDatabase.IsSubAsset(asset))
                {
                    // Получаем спрайты из атласа,
                    sprites.Add(asset as Sprite);
                }
            }
        }
        else
        {
            Debug.Log("Ошибка загрузки");
        }
    }

    // получение спрайта из атласа
    public static Sprite GetSprite(int index)
    {
        if (index < 0 || index >= sprites.Count) return null;

        return sprites[index];
    }
    public static int GetAtlasLenght()
    {
        return sprites.Count;
    }
}
