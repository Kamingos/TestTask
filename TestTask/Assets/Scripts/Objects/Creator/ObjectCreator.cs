using UnityEngine;

public class ObjectCreator : MonoBehaviour, IObjectCreator
{
    AbstractObjectCreator objectCreator;

    // фабрик методы
    FMUnion unionCreateor;
    FMSunflower sunflowerCreateor;
    FMRandom randomCreateor;

    public void Init()
    {
        unionCreateor = new();
        sunflowerCreateor = new();
        randomCreateor = new();
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

        temp.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y);

        return temp;
    }

}
