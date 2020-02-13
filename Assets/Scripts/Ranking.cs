using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Ranking
{
    public static int SaveScore (int now_score) {
        var scores = GetRankingScore ();
        
        int rank = -1;
        for (int i=0; i<10; i++) {
            var score = scores[i];
            if (now_score > score) {
                rank = i;
                break;
            }
        }

        // ランクインしなかったら終了
        if (rank == -1) return -1;

        // ランクインしたらPlayerPrefsに保存
        var list = scores.ToList ();
        list.Add (now_score);
        list.Sort((a, b) => b - a);
        for (int i=0; i<10; i++) {
            var score = list[i];
            PlayerPrefs.SetInt (string.Format ("Score_{0}", i), score);
        }

        return rank;
    }

    public static void ResetScore () {
        for (int i=0; i<10; i++) {
            PlayerPrefs.SetInt (string.Format ("Score_{0}", i), 0);
        }
    }

    public static int GetBestScore () {
        var scoores = GetRankingScore ();
        return scoores[0];
    }

    public static int[] GetRankingScore () {
        var scores = new int[10];
        for (int i=0; i<10; i++) {
            var score = PlayerPrefs.GetInt(string.Format ("Score_{0}", i));
            scores[i] = score;
        }

        return scores;
    }
}
