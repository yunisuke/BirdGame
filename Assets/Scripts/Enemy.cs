using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer upperEnemy;
    [SerializeField] private SpriteRenderer lowerEnemy;
    [SerializeField] private PointCollider pointCollider;

    public void SetEnemy () {
        int total_height = 5;

        int height = Random.Range (1, 4);
        upperEnemy.size = new Vector2 (1, height);
        upperEnemy.transform.localPosition = new Vector3 (0, -(height - 1) * 0.5f, 0);

        height = total_height - height;
        lowerEnemy.size = new Vector2 (1, height);
        lowerEnemy.transform.localPosition = new Vector3 (0, (height - 1) * 0.5f, 0);
    }
}
