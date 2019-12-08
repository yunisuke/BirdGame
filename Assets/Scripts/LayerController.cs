using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    [SerializeField] private Layer layerEnemy;
    [SerializeField] private Layer layerFront;
    [SerializeField] private Layer layerMiddle;
    [SerializeField] private Layer layerBack;

    void Awake () {
        layerEnemy.SetSpeed (0f);
        layerFront.SetSpeed (4f);
        layerMiddle.SetSpeed (2f);
        layerBack.SetSpeed (1f);
    }

    public void StartGame (float speed) {
        layerEnemy.Refresh ();
        SetGameSpeed (speed);
    }

    public void SetGameSpeed (float speed) {
        layerEnemy.SetSpeed (speed * 4);
        layerFront.SetSpeed (speed * 4);
        layerMiddle.SetSpeed (speed * 2);
        layerBack.SetSpeed (speed);
    }

    public void GameOver () {
        layerEnemy.SetSpeed (0f);
        layerFront.SetSpeed (0f);
        layerMiddle.SetSpeed (0f);
        layerBack.SetSpeed (0f);
    }
}
