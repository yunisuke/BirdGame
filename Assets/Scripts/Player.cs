﻿using System.Collections;
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

    // private TapState InputCheck () {
    //     TapState t_state = TapState.None;

    //     if (Input.GetMouseButtonDown (0)) {
    //         tapCount++;
    //     }
        
    //     if (Input.GetMouseButton (0)) {
    //         tapFrame++;
    //     }

    //     if (Input.GetMouseButtonUp (0)) {
    //         if (tapCount > 0 && tapFrame <= JumpFrame) {
    //             t_state = TapState.Tap;
    //         }
    //         tapCount = 0;
    //         tapFrame = 0;
    //     }

    //     if (tapFrame > JumpFrame) {
    //         t_state = TapState.LongTap;
    //     }

    //     return t_state;
    // }

    private TapState InputCheck () {
        TapState t_state = TapState.None;

        if (Input.GetMouseButtonDown (0)) {
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
            _rigidbody.velocity = new Vector3 (0f, JumpSpeed, 0f);
        }

        //     _rigidbody.velocity = new Vector3 (0f, -0.5f, 0f);
        // } else if (Input.GetMouseButtonUp (0)) {
        //     _rigidbody.velocity = new Vector3 (0f, 8f, 0f);
        // }

        _animator.SetFloat ("v", _rigidbody.velocity.y);
    }

    public void StartGame () {
        waitTween.Kill ();
    }


    void OnTriggerEnter2D (Collider2D collider) {
        var tag = collider.gameObject.tag;

        if (tag == "Enemy") {
            enabledInput = false;
            _animator.SetTrigger ("death");
            gameoverCallback ();
        } else if (tag == "Point") {
            pointCallback ();
        }
    }
}
