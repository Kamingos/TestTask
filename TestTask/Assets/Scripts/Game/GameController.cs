using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private ViewController viewController;
    private ObjectController objectController;

    public void Init(ViewController _viewController, ObjectController _objectController)
    {
        viewController = _viewController;
        objectController = _objectController;

        viewController.OnBtnPressed += (_) => objectController.CreateObject(_);
    }
}
