using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class HitTextShow : MonoBehaviour
{

    public float timer = 1f;
    // Use this for initialization
    void Start()
    {
        timer = Random.Range(8f, 15f) / 10f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            this.transform.Translate(Vector3.up * Time.deltaTime * 3.5f);
        }
        else
        {
            
            Destroy(this.gameObject);
        }
    }

}
