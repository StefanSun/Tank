using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletParticle : MonoBehaviour {

    public GameObject bullet_model;
    public GameObject bt_par;
    public AudioSource bullet_audio;
    public void BulletBoom()
    {
        bullet_audio.Play();
        bullet_model.SetActive(false);
        Instantiate(bt_par, this.transform.position, Quaternion.identity);
    }

}
