using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : BaseStageObject
{
    [SerializeField] private Transform[] enemyContainers;
    [SerializeField] private Enemy enemyPrefab;
    private List<Enemy> enemyList = new List<Enemy>();

    void Awake () {
        for (int i=0; i<enemyContainers.Length; i++) {
            var enemy = Instantiate (enemyPrefab, enemyContainers[i]);
            enemyList.Add (enemy);
        }
    }

    public override void SetObjects () {
        foreach (var enemy in enemyList) {
            enemy.SetEnemy ();
        }
    }
}
