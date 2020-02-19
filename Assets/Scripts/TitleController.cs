using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] LayerController lyCtr;
    [SerializeField] float gameSpeed = 1.0f;

    void Start () {
        SoundManager.Instance.Initialize ();
        AdManager.Instance.Initialize ();
        FPSManager.Instance.Initialize ();
        AdManager.Instance.ShowAds ();

        lyCtr.SetGameSpeed (gameSpeed);
    }

    public void OnClickNewGameButton () {
        SoundManager.Instance.PlaySE (SEType.Button);
        SceneManager.LoadSceneAsync ("GameScene");
    }

    public void OnClickRankingButton () {
        SoundManager.Instance.PlaySE (SEType.Button);
        SceneManager.LoadSceneAsync ("RankingScene");
    }
}
