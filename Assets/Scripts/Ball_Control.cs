using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Control : MonoBehaviour {

    private GameObject valueHolder;
    public float angle;
    private float bucketZ;
    private float initialVelocities;
    public bool ball_reached_zero = false;
    private Rigidbody rb;
    private bool fan;

	void Awake () {
        valueHolder = GameObject.FindGameObjectWithTag("ValueHolder");
        angle = valueHolder.GetComponent<ValueHolder>().angle;
        bucketZ = valueHolder.GetComponent<ValueHolder>().positionZ;
        initialVelocities = Mathf.Sqrt(bucketZ / 2);
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector3(angle, initialVelocities, initialVelocities);
        fan = true;
    }

    IEnumerator EndSim()
    {
        yield return new WaitForSeconds(1);
        if (transform.position.x < valueHolder.GetComponent<ValueHolder>().positionX + .2 &&
            transform.position.x > valueHolder.GetComponent<ValueHolder>().positionX - .2 &&
            transform.position.z < valueHolder.GetComponent<ValueHolder>().positionZ + .2 &&
            transform.position.z > valueHolder.GetComponent<ValueHolder>().positionX - .2)
        {
            valueHolder.GetComponent<ValueHolder>().ballWin = true;
        }
        else
        {
            valueHolder.GetComponent<ValueHolder>().ballWin = false;
        }
        /*valueHolder.GetComponent<ValueHolder>().ballDistance = Mathf.Sqrt(Mathf.Pow(transform.position.x - valueHolder.GetComponent<ValueHolder>().positionX, 2) + 
            Mathf.Pow(transform.position.z - valueHolder.GetComponent<ValueHolder>().positionZ, 2));*/
        valueHolder.GetComponent<ValueHolder>().ballDone = true;
        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        if (fan)
        {
            rb.AddForce(new Vector3(valueHolder.GetComponent<ValueHolder>().fanSpeed, 0, 0));
        }
        //Force ball to stay at 0 in z direction
        if (transform.position.z > bucketZ)
        {
            ball_reached_zero = true;
            Vector3 temp = rb.velocity;
            transform.position = new Vector3(transform.position.x, transform.position.y, bucketZ);
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.velocity = temp;
            StartCoroutine(EndSim());
        }
    }
}
