using UnityEngine;

public interface IObjectCreator
{
    public GameObject CreateObject(ObjectType objType);
}