using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private float JumpSpeed = 12f;
    public UnityAction gameoverCallback;
    public UnityAction pointCallback;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool enabledInput = true;
    private bool isStartGame = false;

    public int tapFrame;    // タップし続けたフレーム数
    public int tapInterval; // タップ間隔フレーム数
    public int tapCount;    // タップ数
    public bool tapWait;    // 入力待ち

    private static readonly int JumpFrame = 8;
    private Tween waitTween;

    private enum TapState {
        None = 0,
        Tap,
        LongTap,
    }

    private TapState InputCheck () {
        if (Input.GetMouseButtonDown (0)) {
            return TapState.Tap;
        }

        if (Input.GetMouseButton (0)) {
            return TapState.LongTap;
        }

        return TapState.None;
    }

    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        tapFrame = 0;
        tapCount = 0;

        waitTween = transform.DOMoveY (1.0f, 1.0f).SetEase(Ease.OutQuad).SetLoops (-1, LoopType.Yoyo);
    }

    void Update () {
        if (enabledInput == false || isStartGame == false) return;

        var state = InputCheck ();

        if (state == TapState.Tap || state == TapState.LongTap) {
            if (state == TapState.Tap) SoundManager.Instance.PlaySE (SEType.Flap);
            _rigidbody.AddForce (Vector2.up * 230f);
        }

        SetAnimation (state);
    }

    public void StartGame () {
        waitTween.Kill ();
        isStartGame = true;
    }

    private void SetAnimation (TapState tap_state) {
        switch (tap_state) {
            case TapState.None:
                _animator.SetTrigger ("gliding");
                break;

            case TapState.Tap:
            case TapState.LongTap:
                _animator.SetTrigger ("jump");
                break;
        }
    }

    private bool isDead = false;
    void OnTriggerEnter2D (Collider2D collision) {
        var tag = collision.gameObject.tag;

        if (tag == "Ground" && isDead) {
            _animator.SetTrigger ("dead");
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
            _rigidbody.velocity = new Vector2 (0, 0);
            transform.localPosition = new Vector2 (transform.localPosition.x, -3.32f);
        } else if (isDead == false && (tag == "Enemy" || tag == "Ground")) {
            enabledInput = false;
            isDead = true;
            _animator.SetTrigger ("death");
            gameoverCallback ();
        } else if (tag == "Point" && isDead == false) {
            pointCallback ();
        }
    }
}
