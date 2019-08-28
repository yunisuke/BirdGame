using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStateType {
    WaitGetReady, // 演出待ち 
    GetReady,  // 開始待ち
    Game,      // ゲーム中
    GameOver,  // ゲームオーバー
}

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] LayerController lyCtr;
    [SerializeField] MainPanel mainPanel;

    private int score;
    private GameStateType state;

    void Start () {
        state = GameStateType.WaitGetReady;
        player.gameoverCallback = GameOver;
        player.pointCallback = GetPoint;
        mainPanel.GetReady (AfterWaitGetReadyCallback);
    }

    void Update () {
        if (Input.GetMouseButtonDown (0) && state == GameStateType.GetReady) {
            StartGame ();
        } else if (Input.GetMouseButtonDown (0) && state == GameStateType.GameOver) {
            SceneManager.LoadSceneAsync ("GameScene");
        }
    }

    private void AfterWaitGetReadyCallback () {
        state = GameStateType.GetReady;
    }

    public void StartGame () {
        state = GameStateType.Game;

        player.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        player.StartGame ();
        lyCtr.AppearEnemy ();
        mainPanel.StartGame ();
    }

    private void GetPoint () {
        score ++;
        mainPanel.UpdateScore (score);
    }

    private void GameOver () {
        player.GetComponent <Rigidbody2D>().velocity = new Vector3 (-5, 6, 0);
        player.GetComponent <BoxCollider2D>().enabled = false;
        lyCtr.GameOver ();

        var best_score = PlayerPrefs.GetInt ("BestScore");
        if (score > best_score) PlayerPrefs.SetInt ("BestScore", score);

        StartCoroutine (GameOverAnimation (best_score));
    }

    private IEnumerator GameOverAnimation (int best_score) {
        yield return new WaitForSeconds (1.0f);
        state = GameStateType.GameOver;
        mainPanel.GameOver (score, best_score);
    }
}
