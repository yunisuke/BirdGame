using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStateType {
    WaitGetReady, // 開始前演出待ち 
    GetReady,     // 開始待ち
    Game,         // ゲーム中
    WaitGameOver, // ゲームオーバー演出待ち
    GameOver,     // ゲームオーバー
}

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] LayerController lyCtr;
    [SerializeField] MainPanel mainPanel;
    [SerializeField] float gameSpeed = 1.0f;

    private int score;
    private GameStateType state;

    void Start () {
        state = GameStateType.WaitGetReady;
        player.gameoverCallback = GameOver;
        player.pointCallback = GetPoint;
        mainPanel.GetReady (AfterWaitGetReadyCallback);
        lyCtr.SetGameSpeed (gameSpeed);
    }

    void Update () {
        if (Input.GetMouseButtonDown (0) && state == GameStateType.GetReady) {
            StartGame ();
        } else if (Input.GetMouseButtonDown (0) && state == GameStateType.GameOver) {
            SceneManager.LoadSceneAsync ("GameScene");
        }
    }

    public void OnClickEasyButton () {
        lyCtr.SetGameSpeed (1.0f);
    }

    public void OnClickNormalButton () {
        lyCtr.SetGameSpeed (2.0f);
    }

    public void OnClickHardButton () {
        lyCtr.SetGameSpeed (3.0f);
    }

    private void AfterWaitGetReadyCallback () {
        state = GameStateType.GetReady;
    }

    private void AfterGameOverCallback () {
        state = GameStateType.GameOver;
    }

    public void StartGame () {
        state = GameStateType.Game;

        player.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        player.StartGame ();
        lyCtr.StartGame (gameSpeed);
        mainPanel.StartGame ();
    }

    private void GetPoint () {
        score ++;
        mainPanel.UpdateScore (score);
    }

    private void GameOver () {
        player.GetComponent <Rigidbody2D>().velocity = new Vector3 (-3, 10, 0);
        lyCtr.GameOver ();

        var best_score = PlayerPrefs.GetInt ("BestScore");
        if (score > best_score) PlayerPrefs.SetInt ("BestScore", score);

        StartCoroutine (GameOverAnimation (best_score));
    }

    private IEnumerator GameOverAnimation (int best_score) {
        yield return new WaitForSeconds (1.0f);
        state = GameStateType.WaitGameOver;
        mainPanel.GameOver (score, best_score, AfterGameOverCallback);
    }
}
