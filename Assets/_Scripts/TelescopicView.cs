using UnityEngine;
public class TelescopicView : MonoBehaviour
{
    public float zoom = 2.0f;
    public float speedIn = 100.0f;
    public float speedOut = 100.0f;
    private float initFov;
    private float currFov;
    private float minFov;
    private float addFov;

    void Start()
    {
        initFov = Camera.main.fieldOfView;
        minFov = initFov / zoom;
    }

    void Update()
    {
        if (Camera.main)
        {
            if (Input.GetKey(KeyCode.Mouse1))
                ZoomView();
            else
                ZoomOut();
        }
    }

    void ZoomView()
    {
        currFov = Camera.main.fieldOfView;
        addFov = speedIn * Time.deltaTime;
        if (Mathf.Abs(currFov - minFov) < 0.5f)
            currFov = minFov;
        else if (currFov - addFov >= minFov)
            currFov -= addFov;

        Camera.main.fieldOfView = currFov;
    }

    void ZoomOut()
    {
        currFov = Camera.main.fieldOfView;
        addFov = speedOut * Time.deltaTime;
        if (Mathf.Abs(currFov - initFov) < 0.5f)
            currFov = initFov;
        else if (currFov + addFov <= initFov)
            currFov += addFov;
        Camera.main.fieldOfView = currFov;
    }
}