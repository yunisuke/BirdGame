using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private MapObject obj_1;
    [SerializeField] private MapObject obj_2;

    [SerializeField] private float Speed = 4.0f;

    [SerializeField] private float goalPosX;

    void Awake () {
        MoveObj (obj_1, obj_2);
    }

    void Start () {
        SetSpeed (Speed);
    }

    void Update () {
        // obj_1.transform.position += Vector3.left * Speed * Time.deltaTime;
        // obj_2.transform.position += Vector3.left * Speed * Time.deltaTime;

        MoveObj (obj_1, obj_2);
        MoveObj (obj_2, obj_1);
    }

    public void SetSpeed (float speed) {
        obj_1.SetSpeed (speed);
        obj_2.SetSpeed (speed);
    }

    private void MoveObj (MapObject target, MapObject other) {
        var goalX = -25f;
        if (goalPosX != 0) goalX = goalPosX;

        if (target.transform.localPosition.x < goalX) {
            target.transform.localPosition = new Vector3 (other.transform.localPosition.x + 24f, 0f, 0f);
            target.RefreshObject ();
        }
    }
}
