using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Control : MonoBehaviour {

    public float respawnTime;
    public GameObject paper;
    private GameObject valueHolder;
    private NeuralNetwork net;

    void Start () {
        valueHolder = GameObject.FindGameObjectWithTag("ValueHolder");
        net = new NeuralNetwork(new int[] { 3, 25, 25, 1 }); //intiilize network
        //Create Net, create first spawn
        //Wait for net to spawn
        //StartCoroutine(Spawn());
        testNetwork(net, 10000);
    }

    /*void Update()
    {
        while (valueHolder.GetComponent<ValueHolder>().ballDone == false)
        {
            testNetwork(net);
        }
    }*/

    /*IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        Instantiate(paper);
        //StartCoroutine(Spawn());
    }*/

    void testNetwork(NeuralNetwork netw, int iterations)
    {
        float[] dist = netw.FeedForward(new float[] {valueHolder.GetComponent<ValueHolder>().positionX,
        valueHolder.GetComponent<ValueHolder>().positionX,
        valueHolder.GetComponent<ValueHolder>().fanSpeed });
        valueHolder.GetComponent<ValueHolder>().angle = dist[0];
        //StartCoroutine(Spawn());

        Instantiate(paper);
        StartCoroutine(result(netw, iterations));
    }

    IEnumerator result(NeuralNetwork netw, int iter)
    {
        yield return new WaitForSeconds(5);
        valueHolder.GetComponent<ValueHolder>().ballDone = false;
        valueHolder.GetComponent<ValueHolder>().Randomize();
        if (valueHolder.GetComponent<ValueHolder>().ballWin)
        {
            netw.BackProp(new float[] { 1 });
        }
        else
        {
            netw.BackProp(new float[] { 0 });
        }
        iter--;
        if (iter != 0)
        {
            testNetwork(netw, iter);
        }
    }









}
