using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GetReadyEffect : MonoBehaviour
{
    [SerializeField] private RectTransform getReadyTr;
    [SerializeField] private RectTransform tutorialTr;

    private bool finishAnimation = false;
    public bool FinishAnimation {get {return finishAnimation;}}

    public void StartAnimation (UnityAction after_effect_callback) {
        getReadyTr.gameObject.SetActive (true);
        tutorialTr.gameObject.SetActive (true);
        getReadyTr.localPosition = new Vector2 (0f, 450f);
        tutorialTr.localPosition = new Vector2 (0f, -500f);

        getReadyTr.DOLocalMoveY (200f, 1f).SetEase (Ease.OutCubic).OnComplete (() => {
            after_effect_callback ();
        });
        tutorialTr.DOLocalMoveY (-80f, 1f).SetEase (Ease.OutCubic);
    }

    public void EndAnimation () {
        getReadyTr.gameObject.SetActive (false);
        tutorialTr.gameObject.SetActive (false);
    }
}
