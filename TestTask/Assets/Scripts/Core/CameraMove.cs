using UnityEngine;
using UnityEngine.EventSystems;



public class CameraMove : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 CameraDir = Vector3.zero;
    private float camSPEED = 30f;

    public void Update()
    {
        if (GameStateMachine.CurrentState == GameMode.Default) Camera.main.transform.position -= new Vector3(CameraDir.x, 0, 0) * Time.deltaTime * camSPEED;
        if (Camera.main.transform.position.x < -21f) Camera.main.transform.position = Vector3.left * 21;
        if (Camera.main.transform.position.x > 21f) Camera.main.transform.position = Vector3.right * 21;

        CameraDir = Vector3.zero;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        CameraDir = (eventData.position - eventData.pressPosition).normalized;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");
    }
}
