using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHaiti : MonoBehaviour
{
    [SerializeField] private GameObject[] objs;
    [SerializeField] private float spaceX;
    [SerializeField] private float rangeX;

    private bool[] hairetu;
    private int length;

    void Start () {
        length = (int)(rangeX * 2 / spaceX);
        hairetu = new bool[length];

        Refresh ();
    }

    public void Refresh () {
        for (int i=0; i<objs.Length; i++) objs[i].SetActive (false);
        for (int i=0; i<hairetu.Length; i++) hairetu[i] = false;

        for (int i=0; i<objs.Length; i++) {
            int count = 0;
            while (true) {
                int rand = Random.Range (0, length - 1);
                if (hairetu[rand] == false || count >= 3) {
                    hairetu[rand] = true;
                    objs[i].transform.localPosition = new Vector2 (-rangeX + spaceX * rand, 0f);
                    objs[i].SetActive (true);
                    break;
                }
                count++;
            }
        }
    }
}
