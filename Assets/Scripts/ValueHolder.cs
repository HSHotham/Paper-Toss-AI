using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueHolder : MonoBehaviour {

    public float positionX;
    public float positionZ;
    public float fanSpeed;
    public float angle;
    public bool ballDone;
    public bool ballWin;

    public void Randomize()
    {
        positionX = Random.Range(-.5f, .5f);
        positionZ = 1f + Random.Range(-.5f, .5f);
        fanSpeed = Random.Range(-.5f, .5f);
    }

    private void Start()
    {
        Randomize();
    }
}


