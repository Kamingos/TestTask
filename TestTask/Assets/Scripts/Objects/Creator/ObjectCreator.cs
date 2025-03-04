using UnityEngine;

public class ObjectCreator : MonoBehaviour, IObjectCreator
{
    AbstractObjectCreator objectCreator;

    // фабрик методы
    FMUnion unionCreateor;
    FMSunflower sunflowerCreateor;
    FMRandom randomCreateor;

    // другое
    Transform parent;

    public void Init(Transform _parent)
    {
        unionCreateor = new();
        sunflowerCreateor = new();
        randomCreateor = new();

        parent = _parent;
    }

    public GameObject CreateObject(ObjectType objType)
    {
        switch (objType)
        {
            case ObjectType.Onion:
                objectCreator = unionCreateor;
                break;
            case ObjectType.Sunflower:
                objectCreator = sunflowerCreateor;
                break;
            case ObjectType.Random:
                objectCreator = randomCreateor;
                break;
            default:
                break;
        }


        GameObject temp = objectCreator.CreateObject();

        temp.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -2);

        temp.transform.parent = parent;

        return temp;
    }

}
