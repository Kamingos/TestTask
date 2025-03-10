using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //������������
    [SerializeField] View view;
    [SerializeField] public Transform TrParent;

    // �����������
    private GameController gameController;
    private ViewController viewController;
    private ObjectController objectController;
    private ObjectCreator objectCreator;

    private AssetDownloader assetDownloader;

    private void Awake()
    {
        // <-- ����������
        assetDownloader = new();
        assetDownloader.Init();

        GameStateMachine.SetDefaultMode();
        // <-- ����������

        // <-- UI ����
        view.Init();

        viewController = new();
        viewController.Init(view);
        // <-- UI ����

        // <-- Object ����
        objectCreator = new();
        objectCreator.Init(TrParent);

        objectController = new();
        objectController.Init(objectCreator);
        // <-- Object ����


        // <-- ����� ����
        gameController = new();
        gameController.Init(viewController, objectController);
        // <-- ����� ����
    }
}
