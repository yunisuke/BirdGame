using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    [SerializeField] private ObjectHaiti obj;
    [SerializeField] private Rigidbody2D rb;

    public void RefreshObject () {
        if (obj != null) obj.Refresh ();
    }

    public void SetSpeed (float speed) {
        rb.velocity = new Vector2 (-speed, 0f);
    }
}
