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

    //��������� ������
    private void DownloadAtlas()
    {
        AsyncOperationHandle<Texture2D> handle = Addressables.LoadAssetAsync<Texture2D>(atlasPath);

        handle.WaitForCompletion();

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            texture = handle.Result;

            // �������������� Texture2D � ���.��������
            string atlasPath = AssetDatabase.GetAssetPath(texture);
            Object[] assets = AssetDatabase.LoadAllAssetsAtPath(atlasPath);

            foreach (Object asset in assets)
            {
                if (AssetDatabase.IsSubAsset(asset))
                {
                    // �������� ������� �� ������,
                    sprites.Add(asset as Sprite);
                }
            }
        }
        else
        {
            Debug.Log("������ ��������");
        }
    }

    // ��������� ������� �� ������
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
