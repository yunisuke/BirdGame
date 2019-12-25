using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject upperEnemy;
    [SerializeField] private GameObject lowerEnemy;
    [SerializeField] private PointCollider pointCollider;

    private readonly float LowerLimit = -2.7f;
    private readonly float UpperLimit = 4f;

    public void SetEnemy (float enemy_space) {
        var lower_enemy_max = UpperLimit - enemy_space;
        var lower_position = Random.Range (LowerLimit, lower_enemy_max);
        var upper_position = lower_position + enemy_space;
        lowerEnemy.transform.localPosition = new Vector2 (0, lower_position);
        upperEnemy.transform.localPosition = new Vector2 (0, upper_position);
    }
}
