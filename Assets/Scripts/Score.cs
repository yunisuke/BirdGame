using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Sprite[] numberResource; 
    [SerializeField] private Image[] numbers;
    private List<int> pointList;

    void Awake () {
        pointList = new List<int>();
    }

    public void SetScore (int score) {
        pointList.Clear ();
        int count = 0;

        do {
            var p = score % 10;
            pointList.Add (p);

            score /= 10;
            count++;
        } while (score > 0);

        for (int i=0; i<numbers.Length; i++) {
            if (pointList.Count > i) {
                numbers[i].gameObject.SetActive (true);
                numbers[i].sprite = GetNumber (pointList[i]);
            } else {
                numbers[i].gameObject.SetActive (false);
            }
        }
    }

    private Sprite GetNumber (int num) {
        if (num / 10 >= 1) return numberResource[0];
        return numberResource[num];
    }
}
