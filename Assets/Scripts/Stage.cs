using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private MapObject obj_1;
    [SerializeField] private MapObject obj_2;

    [SerializeField] private float Speed = 4.0f;

    void Awake () {
        MoveObj (obj_1, obj_2);
    }

    void Update () {
        obj_1.transform.position += Vector3.left * Speed * Time.deltaTime;
        obj_2.transform.position += Vector3.left * Speed * Time.deltaTime;

        MoveObj (obj_1, obj_2);
        MoveObj (obj_2, obj_1);
    }

    private void MoveObj (MapObject target, MapObject other) {
        if (target.transform.localPosition.x < -25f) {
            target.transform.localPosition = new Vector3 (other.transform.localPosition.x + 29.5f, 0f, 0f);
            target.RefreshObject ();
        }
    }
}
