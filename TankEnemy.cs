using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour {

    public AudioSource car_boom;
    private int n = 0;

	// Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            car_boom.Play();
            n += 1;
            if(n==2)
            {
                Destroy(this.gameObject);
            }

        }
    }


}
