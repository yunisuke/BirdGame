using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private Stage stageEnemy;
    [SerializeField] private Stage stageFront;
    [SerializeField] private Stage stageMiddle;
    [SerializeField] private Stage stageBack;

    void Awake () {
        stageEnemy.SetSpeed (0f);
        stageFront.SetSpeed (4f);
        stageMiddle.SetSpeed (2f);
        stageBack.SetSpeed (1f);
    }

    public void AppearEnemy () {
        stageEnemy.SetSpeed (4f);
    }
}
