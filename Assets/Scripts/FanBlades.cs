using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBlades : MonoBehaviour {

    private void Update()
    {
        transform.Rotate(0, 0, 10);
        transform.Rotate(0, 0, 10);
    }
}
