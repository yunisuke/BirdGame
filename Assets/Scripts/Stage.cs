using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private BaseStageObject obj;
    [SerializeField] private Rigidbody2D rb;

    public void Initialize () {
        obj.Initialize ();
    }

    public void RefreshObject () {
        if (obj != null) obj.SetObjects ();
    }

    public void SetSpeed (float speed) {
        rb.velocity = new Vector2 (-speed, 0f);
    }
}
