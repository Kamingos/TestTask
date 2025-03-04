using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //накидываемые
    [SerializeField] View view;
    [SerializeField] Transform transformObjects;

    // создаваемые
    private GameController gameController;
    private ViewController viewController;
    private ObjectController objectController;
    private ObjectCreator objectCreator;

    private AssetDownloader assetDownloader;

    private void Awake()
    {
        // <-- подготовка
        assetDownloader = new();
        assetDownloader.Init();
        // <-- подготовка

        // <-- UI блок
        view.Init();

        viewController = new();
        viewController.Init(view);
        // <-- UI блок

        // <-- Object блок
        objectCreator = new();
        objectCreator.Init();

        objectController = new();
        objectController.Init(objectCreator);
        // <-- Object блок


        // <-- Общий блок
        gameController = new();
        gameController.Init(viewController, objectController);
        // <-- Общий блок
    }
}
