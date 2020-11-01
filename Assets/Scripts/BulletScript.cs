using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject bullethit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("Rocket"))
        {
            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(explode, 2f);
        } 
        if (gameObject.CompareTag("Bullet"))
        {
            GameObject explode = Instantiate(bullethit, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(explode, 2f);
        }

    }
}
