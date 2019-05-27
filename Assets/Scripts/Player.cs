using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = new Vector3 (0f, 8f, 0f);
        }
        if (Input.GetKey (KeyCode.Space)) {
            if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = new Vector3 (0f, -0.5f, 0f);
        }
    }

    void OnTriggerEnter2D (Collider2D collider) {
        Debug.Log ("Hit!");
    }

    private void Move () {

    }
}
