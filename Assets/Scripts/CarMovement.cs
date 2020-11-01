using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 1.0f;

 
    //Set all of the end positions for the cars
    Vector3 blackCarEndPos = new Vector3(20, (float)-1.45, 9);
    Vector3 blueCarEndPos = new Vector3((float)-25.2, (float)-1.41688, (float)-15.12);
    Vector3 whiteCarEndPos = new Vector3((float)-1.63, (float)-1.416879, (float)19.82);

    //Create placeholders for the start positions for the cars.
    Vector3 blackCarStartPos = new Vector3(0, 0, 0);
    Vector3 blueCarStartPos = new Vector3(0, 0, 0);
    Vector3 whiteCarStartPos = new Vector3(0, 0, 0);

    void Start()
    {
        GameObject BlackCar = GameObject.Find("CarBlack");
        GameObject BlueCar = GameObject.Find("CarBlue");
        GameObject WhiteCar = GameObject.Find("CarWhite");
        //Set all of the start positions for the cars
        blackCarStartPos = BlackCar.transform.position;
        blueCarStartPos = BlueCar.transform.position;
        whiteCarStartPos = WhiteCar.transform.position;

        BlackCar.transform.Find("smokePoint");

    }

    // Update is called once per frame
    void Update()
    {
        // calculate distance to move
        float step = speed * Time.deltaTime;
        GameObject BlackCar = GameObject.Find("CarBlack");
        GameObject BlueCar = GameObject.Find("CarBlue");
        GameObject WhiteCar = GameObject.Find("CarWhite");
        //Make all cars face their destination
        BlackCar.transform.LookAt(blackCarEndPos);
        BlueCar.transform.LookAt(blueCarEndPos);
        WhiteCar.transform.LookAt(whiteCarEndPos);

        //Move the cars towards their destination
        BlackCar.transform.position = Vector3.MoveTowards(BlackCar.transform.position, blackCarEndPos, step);
        BlueCar.transform.position = Vector3.MoveTowards(BlueCar.transform.position, blueCarEndPos, step);
        WhiteCar.transform.position = Vector3.MoveTowards(WhiteCar.transform.position, whiteCarEndPos, step);

        //Check to see when each car is really close to the destination and swap the points.
        if (Vector3.Distance(BlackCar.transform.position, blackCarEndPos) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = blackCarEndPos;
            blackCarEndPos = blackCarStartPos;
            blackCarStartPos = temp;
        }
        if (Vector3.Distance(BlueCar.transform.position, blueCarEndPos) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = blueCarEndPos;
            blueCarEndPos = blueCarStartPos;
            blueCarStartPos = temp;
        }
        if (Vector3.Distance(WhiteCar.transform.position, whiteCarEndPos) < 0.001f)
        {
            Vector3 temp = new Vector3();
            temp = whiteCarEndPos;
            whiteCarEndPos = whiteCarStartPos;
            whiteCarStartPos = temp;
        }
    }
}
