using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletB : MonoBehaviour
{

    public float timer = 2f;
    private void Start()
    {
        StartCoroutine(DestoryOBJ());
    }


    IEnumerator DestoryOBJ()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
