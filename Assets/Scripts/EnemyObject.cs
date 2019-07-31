using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : BaseStageObject
{
    [SerializeField] private Enemy[] enemys;

    public override void SetObjects () {
        foreach (var enemy in enemys) {
            enemy.SetEnemy ();
        }
    }
}
