using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class GameOverEffect : MonoBehaviour
{
    [SerializeField] private RectTransform gameOverTr;
    [SerializeField] private RectTransform scoreTr;

    [SerializeField] private Score nowScoreView;  // ゲームオーバー時。今のプレイの記録
    [SerializeField] private Score bestScoreView; // ゲームオーバー時。最高記録
    [SerializeField] private Image newObj;   // 新記録アイコン

    private bool finishAnimation = false;
    public bool FinishAnimation {get {return finishAnimation;}}

    public void StartAnimation (int now_score, int best_score, UnityAction after_effect_callback) {
        gameOverTr.gameObject.SetActive (true);
        scoreTr.gameObject.SetActive (true);
        gameOverTr.localPosition = new Vector2 (0f, 400f);
        scoreTr.localPosition = new Vector2 (0f, -500f);
        bestScoreView.SetScore (best_score);

        var seq = DOTween.Sequence ();
        seq.Append (gameOverTr.DOLocalMoveY (150f, 0.3f).SetEase (Ease.OutCubic));
        seq.AppendInterval (0.1f);
        seq.Append (scoreTr.DOLocalMoveY (-65f, 0.5f).SetEase (Ease.OutCubic));

        // スコアのアニメーション
        seq.AppendInterval (0.2f);

        bool is_new_score = false;
        var tw = DOTween.To(
            () => 0,
            it => {
                nowScoreView.SetScore (it);
                if (it > best_score) {
                    bestScoreView.SetScore (it);
                    if (is_new_score == false) {
                        newObj.gameObject.SetActive (true);
                        newObj.DOFade (0f, 0.2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
                        is_new_score = true;
                    }
                }
            },
            now_score,
            now_score * 0.1f
        ).SetEase (Ease.Linear);
        seq.Append (tw).OnComplete (() => {
            after_effect_callback ();
        });
    }
}
