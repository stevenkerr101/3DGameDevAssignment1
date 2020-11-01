using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    public float speed = 1.0f;


    //Set all of the end positions for the cars
    Vector3 endPointP1 = new Vector3((float)-5.78, (float)-1.450999, (float)-19.02);
    Vector3 endPointP2 = new Vector3((float)20.78, (float)-1.450999, (float)-19.07);
    Vector3 endPointP3 = new Vector3((float)-5.61, (float)-1.450999, (float)6.11);
    Vector3 endPointP4 = new Vector3((float)0.33, (float)-1.450999, (float)-13.11);
    Vector3 endPointP5 = new Vector3((float)20.97, (float)-1.450999, (float)12.66);
    Vector3 endPointP6 = new Vector3((float)-5.6, (float)-1.450999, (float)12.83529);

    //Create placeholders for the start positions for the cars.
    Vector3 startPointP1 = new Vector3(0, 0, 0);
    Vector3 startPointP2 = new Vector3(0, 0, 0);
    Vector3 startPointP3 = new Vector3(0, 0, 0);
    Vector3 startPointP4 = new Vector3(0, 0, 0);
    Vector3 startPointP5 = new Vector3(0, 0, 0);
    Vector3 startPointP6 = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GameObject Pedestrian1 = GameObject.Find("Pedestrian1");
        GameObject Pedestrian2 = GameObject.Find("Pedestrian2");
        GameObject Pedestrian3 = GameObject.Find("Pedestrian3");
        GameObject Pedestrian4 = GameObject.Find("Pedestrian4");
        GameObject Pedestrian5 = GameObject.Find("Pedestrian5");
        GameObject Pedestrian6 = GameObject.Find("Pedestrian6");

        //Set all of the start positions for the cars
        startPointP1 = Pedestrian1.transform.position;
        startPointP2 = Pedestrian2.transform.position;
        startPointP3 = Pedestrian3.transform.position;
        startPointP4 = Pedestrian4.transform.position;
        startPointP5 = Pedestrian5.transform.position;
        startPointP6 = Pedestrian6.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // calculate distance to move
        float step = speed * Time.deltaTime;

        GameObject Pedestrian1 = GameObject.Find("Pedestrian1");
        GameObject Pedestrian2 = GameObject.Find("Pedestrian2");
        GameObject Pedestrian3 = GameObject.Find("Pedestrian3");
        GameObject Pedestrian4 = GameObject.Find("Pedestrian4");
        GameObject Pedestrian5 = GameObject.Find("Pedestrian5");
        GameObject Pedestrian6 = GameObject.Find("Pedestrian6");

        Pedestrian1.transform.LookAt(endPointP1);
        Pedestrian2.transform.LookAt(endPointP2);
        Pedestrian3.transform.LookAt(endPointP3);
        Pedestrian4.transform.LookAt(endPointP4);
        Pedestrian5.transform.LookAt(endPointP5);
        Pedestrian6.transform.LookAt(endPointP6);

        Pedestrian1.transform.position = Vector3.MoveTowards(Pedestrian1.transform.position, endPointP1, step);
        Pedestrian2.transform.position = Vector3.MoveTowards(Pedestrian2.transform.position, endPointP2, step);
        Pedestrian3.transform.position = Vector3.MoveTowards(Pedestrian3.transform.position, endPointP3, step);
        Pedestrian4.transform.position = Vector3.MoveTowards(Pedestrian4.transform.position, endPointP4, step);
        Pedestrian5.transform.position = Vector3.MoveTowards(Pedestrian5.transform.position, endPointP5, step);
        Pedestrian6.transform.position = Vector3.MoveTowards(Pedestrian6.transform.position, endPointP6, step);

        if (Vector3.Distance(Pedestrian1.transform.position, endPointP1) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = endPointP1;
            endPointP1 = startPointP1;
            startPointP1 = temp;
        }
        if (Vector3.Distance(Pedestrian2.transform.position, endPointP2) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = endPointP2;
            endPointP2 = startPointP2;
            startPointP2 = temp;
        }
        if (Vector3.Distance(Pedestrian3.transform.position, endPointP3) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = endPointP3;
            endPointP3 = startPointP3;
            startPointP3 = temp;
        }
        if (Vector3.Distance(Pedestrian4.transform.position, endPointP4) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = endPointP4;
            endPointP4 = startPointP4;
            startPointP4 = temp;
        }
        if (Vector3.Distance(Pedestrian5.transform.position, endPointP5) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = endPointP5;
            endPointP5 = startPointP5;
            startPointP5 = temp;
        }
        if (Vector3.Distance(Pedestrian6.transform.position, endPointP6) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = endPointP6;
            endPointP6 = startPointP6;
            startPointP6 = temp;
        }

    }
}
