using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    [SerializeField] private Layer layerEnemy;
    [SerializeField] private Layer layerFront;
    [SerializeField] private Layer layerMiddle;
    [SerializeField] private Layer layerBack;
    private bool appearEnemy = false;

    public void StartGame (float speed) {
        appearEnemy = true;

        layerEnemy.Initialize ();
        layerEnemy.Refresh ();
        SetGameSpeed (speed);
    }

    public void SetBackLayerSpeed (float speed) {
        layerBack.SetSpeed (speed * 0.3f);
    }

    public void SetGameSpeed (float speed) {
        if (appearEnemy) layerEnemy.SetSpeed (speed * 4);
        layerFront.SetSpeed (speed * 4);
        layerMiddle.SetSpeed (speed * 1.2f);
        layerBack.SetSpeed (speed * 0.3f);
    }

    public void GameOver () {
        layerEnemy.SetSpeed (0f);
        layerFront.SetSpeed (0f);
        layerMiddle.SetSpeed (0f);
        layerBack.SetSpeed (0f);
    }
}
