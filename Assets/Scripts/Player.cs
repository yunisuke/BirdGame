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
        TapState t_state = TapState.None;

        if (Input.GetMouseButton (0)) {
            t_state = TapState.Tap;
        }

        return t_state;
    }

    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        tapFrame = 0;
        tapCount = 0;

        waitTween = transform.DOMoveY (1.0f, 1.0f).SetEase(Ease.OutQuad).SetLoops (-1, LoopType.Yoyo);
    }

    void Update () {
        if (enabledInput == false) return;

        var state = InputCheck ();
        if (state == TapState.LongTap) {
            _rigidbody.velocity = new Vector3 (0f, -0.5f, 0f);
        }

        if (state == TapState.Tap) {
            _rigidbody.AddForce (Vector2.up * 230f);
            // _rigidbody.velocity = new Vector3 (0f, JumpSpeed, 0f);
        }

        _animator.SetFloat ("v", _rigidbody.velocity.y);
    }

    public void StartGame () {
        waitTween.Kill ();
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
        } else if (tag == "Point") {
            pointCallback ();
        }
    }
}
