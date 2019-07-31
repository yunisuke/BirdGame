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

    public void AppearEnemy () {
        layerEnemy.SetSpeed (4f);
        layerEnemy.Refresh ();
    }
}
