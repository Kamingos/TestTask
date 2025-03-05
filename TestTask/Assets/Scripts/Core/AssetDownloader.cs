using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetDownloader : MonoBehaviour
{
    private static Dictionary<int, Sprite> spriteDic = new Dictionary<int, Sprite>();

    private string atlasPath = "farmAtlas";

    public void Init()
    {
        spriteDic = new();
        DownloadAtlas();
    }

    //загрузчик атласа
    private void DownloadAtlas()
    {
        AsyncOperationHandle<Sprite[]> handle = Addressables.LoadAssetAsync<Sprite[]>(atlasPath);

        handle.WaitForCompletion();

        if (handle.Status != AsyncOperationStatus.Succeeded) return;

        Sprite[] allSprites = handle.Result;

        if (allSprites == null || allSprites.Length <= 0)
        {
            Debug.Log("Ошибка загрузки");
            return;
        }

        for (int i = 0; i < allSprites.Length; i++)
        {
            spriteDic.Add(i, allSprites[i]);
        }
    }

    //получение спрайта из атласа
    public static Sprite GetSprite(int index)
    {
        if (index < 0 || index >= spriteDic.Count) return null;

        return spriteDic[index];
    }
    public static int GetAtlasLenght()
    {
        return spriteDic.Count;
    }
}
