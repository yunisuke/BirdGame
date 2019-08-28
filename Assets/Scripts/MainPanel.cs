using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private Text[] pointTexts;

    [SerializeField] private GameObject readyText;
    [SerializeField] private GameObject gameOverText;

    [SerializeField] private Score scoreView;

    [SerializeField] private GetReadyEffect getReadyEffect;
    [SerializeField] private GameOverEffect gameOverEffect;

    public void GetReady (UnityAction after_effect_callback) {
        getReadyEffect.StartAnimation (after_effect_callback);
    }

    public void StartGame () {
        getReadyEffect.EndAnimation ();
        scoreView.gameObject.SetActive (true);
    }

    public void GameOver (int now_score, int best_score) {
        gameOverEffect.StartAnimation (now_score, best_score);
        scoreView.gameObject.SetActive (false);
    }

    public void UpdateScore (int score) {
        scoreView.SetScore (score);
    }
}
