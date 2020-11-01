using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorScript : MonoBehaviour
{

    Animator animator;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        GameObject door = GameObject.Find("01_low");
        animator = door.GetComponent<Animator>();
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("OpenDoor");
        canvas.SetActive(true);
        
    }

    public void OnTriggerExit(Collider other)
    {
        animator.enabled = true;
    }

    void pauseAnimationEvent()
    {
        animator.enabled = false;
    }
}
