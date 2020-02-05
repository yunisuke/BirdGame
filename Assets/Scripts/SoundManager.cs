using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundManager
{
    private static SoundManager _instance;

    // SE
    private List<AudioClip> seList = new List<AudioClip>();
    private readonly string[] AudioPath = {"Hit", "Score"};

    private AudioSource audio = new AudioSource ();

    private SoundManager () {

    }

    public static SoundManager Instance {get {
        if (_instance == null) _instance = new SoundManager ();
        return _instance;
    }}

    public void Initialize () {
        if (audio == null) {
            var obj = new GameObject("Sound");
            GameObject.DontDestroyOnLoad(obj);
            audio = obj.AddComponent<AudioSource>();
        }

        seList = Resources.LoadAll<AudioClip> ("SE").ToList ();
    }

    public void PlaySE (SEType se_type) {
        var se = seList.Find (x => x.name == SE_Names[(int)se_type]);
        if (se == null) return;

        audio.PlayOneShot (se);
    }

    private readonly string[] SE_Names = {
        "Button",
        "Score",
        "Hit",
        "Flap",
    };
}

public enum SEType {
    Button = 0,
    Score,
    Hit,
    Flap,
}


