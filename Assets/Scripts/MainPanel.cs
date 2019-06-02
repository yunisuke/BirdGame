using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private Player pl;

    [SerializeField] private Text tapCount;
    [SerializeField] private Text tapFrame;
    [SerializeField] private Text tapInterval;
    [SerializeField] private Text tapWait;

    void Update () {
        tapCount.text = pl.tapCount.ToString ();
        tapFrame.text = pl.tapFrame.ToString ();
        tapInterval.text = pl.tapInterval.ToString ();
        tapWait.text = pl.tapWait.ToString ();
    }
}
