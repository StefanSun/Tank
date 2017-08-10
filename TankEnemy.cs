using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{

    public GameObject number100;
    public GameObject number999;

    public AudioSource car_boom;
    private int n = 0;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            car_boom.Play();
            n += 1;
            if (n == 2)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Random.Range(0, 4) == 2)
        {
            GameObject a = Instantiate(number999, new Vector3(this.transform.position.x, this.transform.position.y + 5f, this.transform.position.z), Quaternion.identity) as GameObject;
            a.GetComponent<iTweenPositionTo>().valueFrom = this.transform.position;
            a.GetComponent<iTweenPositionTo>().valueTo = this.transform.position + new Vector3(0, 8, 0);
        }
        else
        {
            GameObject a = Instantiate(number100, new Vector3(this.transform.position.x, this.transform.position.y + 5f, this.transform.position.z), Quaternion.identity) as GameObject;
            a.GetComponent<iTweenPositionTo>().valueFrom = this.transform.position;
            a.GetComponent<iTweenPositionTo>().valueTo = this.transform.position + new Vector3(0, 10, 0);
        }
    }


}