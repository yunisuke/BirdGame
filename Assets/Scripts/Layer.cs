using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField] private Stage stg_1;
    [SerializeField] private Stage stg_2;
    [SerializeField] private float stgOffset;

    [SerializeField] private float Speed = 4.0f;

    [SerializeField] private float goalPosX;

    void Awake () {
        MoveObj (stg_1, stg_2);
    }

    void Start () {
        SetSpeed (Speed);
    }

    void Update () {
        MoveObj (stg_1, stg_2);
        MoveObj (stg_2, stg_1);
    }

    public void SetSpeed (float speed) {
        stg_1.SetSpeed (speed);
        stg_2.SetSpeed (speed);
    }

    private void MoveObj (Stage target, Stage other) {
        var goalX = -25f;
        if (goalPosX != 0) goalX = goalPosX;

        if (target.transform.localPosition.x < goalX) {
            target.transform.localPosition = new Vector3 (other.transform.localPosition.x + stgOffset, 0f, 0f);
            target.RefreshObject ();
        }
    }

    public void Refresh () {
        stg_1.RefreshObject ();
        stg_2.RefreshObject ();
    }
}
