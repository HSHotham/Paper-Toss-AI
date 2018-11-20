using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSide : MonoBehaviour {

    private GameObject valueHolder;

    private void Start()
    {
        valueHolder = GameObject.FindGameObjectWithTag("ValueHolder");
    }

    void Update () {
		if (valueHolder.GetComponent<ValueHolder>().fanSpeed < 0)
        {
            transform.position = new Vector3(-.2f, .1f, .287f);
            transform.eulerAngles = new Vector3(0, 135, 0);
        }
        else if (valueHolder.GetComponent<ValueHolder>().fanSpeed > 0)
        {
            transform.position = new Vector3(.2f, .1f, .287f);
            transform.eulerAngles = new Vector3(0, 45, 0);
        }
        else
        {
            transform.position = new Vector3(-1, -5, -1);
        }
	}
}
