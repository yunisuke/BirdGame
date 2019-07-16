using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] StageController stCtr;
    [SerializeField] MainPanel mainPanel;

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            StartGame ();
        }
    }

    public void StartGame () {
        player.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        player.StartGame ();
        stCtr.AppearEnemy ();
        mainPanel.StartGame ();
    }
}
