using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] LayerController lyCtr;
    [SerializeField] MainPanel mainPanel;

    private bool isStartGame = false;

    void Update () {
        if (Input.GetMouseButtonDown (0) && isStartGame == false) {
            StartGame ();
        }
    }

    public void StartGame () {
        isStartGame = true;

        player.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        player.StartGame ();
        lyCtr.AppearEnemy ();
        mainPanel.StartGame ();
    }
}
