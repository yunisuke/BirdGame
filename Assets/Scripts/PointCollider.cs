using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointCollider : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter (PointerEventData event_data) {
        var pl = event_data.pointerDrag.GetComponent<Player>();
        if (pl == null) return;

        Debug.Log ("player got points");
    }
}
