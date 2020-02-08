using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : BaseStageObject
{
    [SerializeField] private GameObject[] objs;
    [SerializeField] private float spaceX;
    [SerializeField] private float rangeX;

    [SerializeField] private float randomX;
    [SerializeField] private float randomY;

    private bool[] existObjs;
    private int length;

    void Start () {
        length = (int)(rangeX * 2 / spaceX);
        existObjs = new bool[length];

        SetObjects ();
    }

    public override void SetObjects () {
        for (int i=0; i<objs.Length; i++) objs[i].SetActive (false);
        for (int i=0; i<existObjs.Length; i++) existObjs[i] = false;

        for (int i=0; i<objs.Length; i++) {
            int count = 0;
            while (true) {
                int rand = Random.Range (0, length);
                if (existObjs[rand] == false || count >= 3) {
                    existObjs[rand] = true;

                    var rand_x = Random.Range (-randomX, randomX);
                    var rand_y = Random.Range (-randomY, randomY);
                    objs[i].transform.localPosition = new Vector2 (-rangeX + spaceX * rand + rand_x, rand_y);
                    objs[i].SetActive (true);
                    break;
                }
                count++;
            }
        }
    }
}
