using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    [SerializeField] private ObjectHaiti obj;

    public void RefreshObject () {
        if (obj != null) obj.Refresh ();
    }
}
