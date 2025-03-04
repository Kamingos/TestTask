using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    IObjectCreator objectCreator;

    public static List<GameObject> ObjectsPool;

    // �������������
    public void Init(IObjectCreator _objectCreator)
    {
        ObjectsPool = new();
        objectCreator = _objectCreator;
    }

    // ��������
    public void CreateObject(ObjectType type)
    {
        var temp = objectCreator.CreateObject(type);

        if (!temp) return;

        ObjectsPool.Add(temp);
        Debug.Log("�������� ������: " + temp.name);
    }
}
