using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {

    public GameObject bullet_lizi;
    public const float g = 9.8f;

    public GameObject target;
    public float speed = 10;
    private float verticalSpeed;
    private Vector3 moveDirection;

    private float angleSpeed;
    private float angle;
    void Start()
    {
        target = GameObject.Find("zhunxing");
        float tmepDistance = Vector3.Distance(transform.position, target.transform.position);
        float tempTime = tmepDistance / speed;
        float riseTime, downTime;
        riseTime = downTime = tempTime / 2;
        verticalSpeed = g * riseTime;
        transform.LookAt(target.transform.position);

        float tempTan = verticalSpeed / speed;
        double hu = Mathf.Atan(tempTan);
        angle = (float)(180 / Mathf.PI * hu);
        transform.eulerAngles = new Vector3(-angle, transform.eulerAngles.y, transform.eulerAngles.z);
        angleSpeed = angle / riseTime;

        moveDirection = target.transform.position - transform.position;
    }
    private float time;
    void Update()
    {
        if (transform.position.y < target.transform.position.y)
        {
            //finish  
            return;
        }
        time += Time.deltaTime;
        float test = verticalSpeed - g * time ;
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime*2f, Space.World);
        transform.Translate(Vector3.up * test * Time.deltaTime, Space.World);
        float testAngle = -angle + angleSpeed * time;
        transform.eulerAngles = new Vector3(testAngle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tank1")
        {
            BulletBoom(collision);
            StartCoroutine(WaitHideBullet());

        }else if(collision.gameObject.tag == "wall")
        {
            BulletBoom(collision);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void BulletBoom(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;    //这个就是碰撞点
        Instantiate(bullet_lizi, pos, rot);  //在碰撞点产生爆炸火焰
    }

    IEnumerator WaitHideBullet()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

}
