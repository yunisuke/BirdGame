using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingController : MonoBehaviour
{
    [SerializeField] LayerController lyCtr;
    [SerializeField] float gameSpeed = 1.0f;

    [SerializeField] Score[] rankingScoreViews = new Score[10];

    void Start () {
        SoundManager.Instance.Initialize ();
        lyCtr.SetBackLayerSpeed (gameSpeed);
        SetRanking ();
    }

    private void SetRanking () {
        var ranking_score = Ranking.GetRankingScore ();

        for(int i=0; i<10; i++) {
            var score = ranking_score[i];
            var view = rankingScoreViews[i];

            view.SetScore (score);
        }
    }

    public void OnClickTitleButton () {
        SoundManager.Instance.PlaySE (SEType.Button);
        SceneManager.LoadSceneAsync ("TitleScene");
    }

    public void OnClickResetScore () {
        Ranking.ResetScore ();
        SetRanking ();
    }
}
