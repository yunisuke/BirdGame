using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : BaseStageObject
{
    [SerializeField] private Transform[] enemyContainers;
    [SerializeField] private Enemy enemyPrefab;
    private List<Enemy> enemyList = new List<Enemy>();

    private static float enemySpace;
    private const float InitEnemySpace = 3f;
    private const float SpaceLimit = 2.3f;

    void Awake () {
        for (int i=0; i<enemyContainers.Length; i++) {
            var enemy = Instantiate (enemyPrefab, enemyContainers[i]);
            enemyList.Add (enemy);
        }
    }

    public override void Initialize () {
        enemySpace = InitEnemySpace;
    }

    public override void SetObjects () {
        foreach (var enemy in enemyList) {
            ChangeEnemySpace ();
            enemy.SetEnemy (enemySpace);
        }
    }

    private void ChangeEnemySpace () {
        enemySpace -= 0.05f;
        if (enemySpace < SpaceLimit) enemySpace = SpaceLimit;
    }
}
