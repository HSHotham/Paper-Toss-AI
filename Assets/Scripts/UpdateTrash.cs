using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTrash : MonoBehaviour {

    public GameObject valueHolder;

	void Update () {
        transform.position = new Vector3(valueHolder.GetComponent<ValueHolder>().positionX, 0, valueHolder.GetComponent<ValueHolder>().positionZ);
    }
}
