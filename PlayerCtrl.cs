using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Xft;

public enum BulletState
{
    putong,
    sanlianfa,
    gaobaodan,
    ranshaodan,
    jiguangpao,
    sanxing,
    dazhao
}

public class PlayerCtrl : MonoBehaviour
{


    /*
     * 0X06A5 75F5\0000 0000\C057 FF07 0100\00BE\7C08 0E   ‭01110101111101010000000000000000‬
     * 0X06A5 0000\0000 BA00\00A0 FF07 0100\00BE\7C08 0E
     * 0X06A5 55F5\0000 0000\00C0 FF07 0100\00BE\7C08 0E
     * 0055 4050 005F 0051
     * 55F5 0000 0000 00C0
     */

    public BulletState bt_state = BulletState.putong;
    public EasyJoystick player_joy;
    public GameObject player_obj;
    public GameObject bullet_pos;

    public GameObject pt_bullet;
    public GameObject sanlian_bullet;
    public GameObject zhunxing;
    public GameObject jiguangpao;
    public GameObject jgp_zhunxing;
    public GameObject sanxing;
    public GameObject sx_zhunxing;
    public GameObject gaobaodan;
    public GameObject gbd_zhunxing;
    public GameObject ranshaodan;
    public GameObject rsd_zhunxing;
    public GameObject dazhao;
    public GameObject dz_zhunxing;

    public AudioSource kaipao;
    public AudioSource jiguang_kp;
    public AudioSource feiji_kp;
    public AudioSource dz_audio;
    public AudioSource ranshaodan_audio;
    public AudioSource gaobaodan_audio;


    public float zx_speed = 30f;

    private GameObject tank_bullet;
    private bool lineMove = false;
    private float joy_x;
    private float joy_y;
    float timer = 0;
    bool isSend = true;
    bool isFir = true;

    private void Start()
    {
        tank_bullet = pt_bullet;

    }



    // Update is called once per frame
    void Update()
    {


        #region 坦克的移动和开火按钮
        joy_x = player_joy.JoystickAxis.x;
        joy_y = player_joy.JoystickAxis.y;
        // DebugConsole.Log(player_joy.JoystickAxis.x.ToString() + "   " + player_joy.JoystickAxis.y.ToString());
        if (joy_y > 0.5f)
        {

            if (joy_x > 0.5f)
            {
                //DebugConsole.Log("右前方");
                WaitSendData("065A060E");

            }
            else if (joy_x < -0.5f)
            {
                //DebugConsole.Log("左前方");
                WaitSendData("065A050E");
            }
            else
            {
                //向前
                WaitSendData("065A010E");

            }
            //			isSend = true;

        }
        else if (joy_y < -0.5f)
        {

            if (joy_x > 0.5f)
            {
                //DebugConsole.Log("右");
                WaitSendData("065A080E");
            }
            else if (joy_x < -0.5f)
            {
                //DebugConsole.Log("左");
                WaitSendData("065A070E");
            }
            else
            {
                // DebugConsole.Log("下");
                WaitSendData("065A020E");

            }
            //			isSend = true;
        }
        else if (joy_x > 0.5f)
        {
            //DebugConsole.Log("右");
            WaitSendData("065A040E");
            //			isSend = true;
        }
        else if (joy_x < -0.5f)
        {
            //DebugConsole.Log("左");
            WaitSendData("065A030E");
            //			isSend = true;
        }
        else
        {
            if (isSend)
            {
                SendMessage("SendStringData", "065A000E");
                isSend = false;
            }
        }

        #endregion

    }

    //X:738,Y:727
    public void SetPlayerPosition(int[] pos)
    {
        Vector3 a_pos = new Vector3(float.Parse(pos[1].ToString()) / 727f * 100f, 5, float.Parse(pos[0].ToString()) / 738f * 100f);
        Vector3 b_pos = new Vector3(float.Parse(pos[3].ToString()) / 727f * 100f, 5, float.Parse(pos[2].ToString()) / 738f * 100f);
        player_obj.transform.position = b_pos;

        player_obj.transform.LookAt(a_pos);


    }


    public void FireButtonDown1()
    {
        if (isFir)
        {

            bt_state = BulletState.putong;
            int n = Random.Range(0, 5);
            if (n == 2)
            {
                bt_state = BulletState.sanlianfa;
            }
            zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1);
            zhunxing.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
    public void FireButtonDown2()
    {
        if (isFir)
        {
            bt_state = BulletState.gaobaodan;
            gbd_zhunxing.SetActive(true);
            gbd_zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1.8f);
        }


    }
    public void FireButtonDown3()
    {
        if (isFir)
        {
            bt_state = BulletState.jiguangpao;
            jgp_zhunxing.SetActive(true);
        }




    }
    public void FireButtonDown4()
    {
        if (isFir)
        {
            bt_state = BulletState.ranshaodan;
            rsd_zhunxing.SetActive(true);

        }

    }
    public void FireButtonDown5()
    {
        if (isFir)
        {
            bt_state = BulletState.dazhao;
            dz_zhunxing.SetActive(true);
        }
    }
    public void FireButtonDown000()
    {
        bt_state = BulletState.putong;
        switch (bt_state)
        {
            case BulletState.putong:
                zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1);
                zhunxing.SetActive(true);

                break;
            case BulletState.sanlianfa:
                zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1);
                zhunxing.SetActive(true);

                break;

            case BulletState.jiguangpao:
                jgp_zhunxing.SetActive(true);

                break;
            case BulletState.gaobaodan:
                gbd_zhunxing.SetActive(true);
                gbd_zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1.5f);
                break;
            case BulletState.sanxing:
                break;
            case BulletState.ranshaodan:
                rsd_zhunxing.SetActive(true);
                rsd_zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1.5f);

                break;
            case BulletState.dazhao:
                dz_zhunxing.SetActive(true);
                dz_zhunxing.transform.localPosition = new Vector3(0, -0.5f, 5.2f);

                break;
        }


    }

    public void FireButtonPress()
    {

        if (isFir)
        {
            switch (bt_state)
            {
                case BulletState.putong:
                    if (zhunxing.transform.position.x > 100 || zhunxing.transform.position.z > 100 || zhunxing.transform.position.x < 0 || zhunxing.transform.position.z < 0)
                    {
                        zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1);
                    }
                    else
                    {
                        zhunxing.transform.Translate(Vector3.forward * zx_speed * Time.deltaTime);
                    }
                    break;
                case BulletState.sanlianfa:
                    if (zhunxing.transform.position.x > 100 || zhunxing.transform.position.z > 100 || zhunxing.transform.position.x < 0 || zhunxing.transform.position.z < 0)
                    {
                        zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1);
                    }
                    else
                    {
                        zhunxing.transform.Translate(Vector3.forward * zx_speed * Time.deltaTime);
                    }

                    break;

                case BulletState.jiguangpao:

                    break;
                case BulletState.gaobaodan:

                    if (gbd_zhunxing.transform.position.x > 100 || gbd_zhunxing.transform.position.z > 100 || gbd_zhunxing.transform.position.x < 0 || gbd_zhunxing.transform.position.z < 0)
                    {
                        gbd_zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1.8f);
                    }
                    else
                    {
                        gbd_zhunxing.transform.Translate(Vector3.forward * zx_speed * Time.deltaTime);
                    }
                    break;
                case BulletState.sanxing:
                    break;
                case BulletState.ranshaodan:
                    if (rsd_zhunxing.transform.position.x > 100 || rsd_zhunxing.transform.position.z > 100 || rsd_zhunxing.transform.position.x < 0 || rsd_zhunxing.transform.position.z < 0)
                    {
                        rsd_zhunxing.transform.localPosition = new Vector3(0, -0.5f, 1.8f);
                    }
                    else
                    {
                        rsd_zhunxing.transform.Translate(Vector3.forward * zx_speed * Time.deltaTime);
                    }

                    break;
                case BulletState.dazhao:
                    if (dz_zhunxing.transform.position.x > 100 || dz_zhunxing.transform.position.z > 100 || dz_zhunxing.transform.position.x < 0 || dz_zhunxing.transform.position.z < 0)
                    {
                        dz_zhunxing.transform.localPosition = new Vector3(0, -0.5f, 5.2f);
                    }
                    else
                    {
                        dz_zhunxing.transform.Translate(Vector3.forward * zx_speed * Time.deltaTime);
                    }

                    break;
            }

        }

    }
    public void FireButton()
    {
        if (isFir)
        {
            switch (bt_state)
            {
                case BulletState.putong:
                    zhunxing.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    GameObject a = Instantiate(pt_bullet, bullet_pos.transform.position, Quaternion.identity) as GameObject;
                    a.transform.rotation = bullet_pos.transform.rotation;
                    a.GetComponent<EffectSettings>().Target = zhunxing;
                    kaipao.Play();
                    break;
                case BulletState.sanlianfa:
                    kaipao.Play();
                    zhunxing.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    GameObject sl = Instantiate(sanlian_bullet, bullet_pos.transform.position, Quaternion.identity) as GameObject;
                    sl.transform.rotation = bullet_pos.transform.rotation;
                    EffectSettings[] efs = sl.GetComponentsInChildren<EffectSettings>();
                    for (int i = 0; i < efs.Length; i++)
                    {
                        efs[i].Target = zhunxing;
                    }
                    break;

                case BulletState.jiguangpao:
                    jiguang_kp.Play();
                    jgp_zhunxing.SetActive(false);
                    jiguangpao.SetActive(true);

                    break;
                case BulletState.gaobaodan:
                    kaipao.Play();
                    gaobaodan_audio.Play();
                    gbd_zhunxing.SetActive(false);

                    GameObject gb = Instantiate(gaobaodan, gbd_zhunxing.transform.position, Quaternion.identity) as GameObject;
                    gb.transform.Rotate(new Vector3(-90, 0, 0));

                    break;
                case BulletState.sanxing:

                    break;
                case BulletState.ranshaodan:

                    kaipao.Play();
                    ranshaodan_audio.Play();
                    GameObject rsd = Instantiate(ranshaodan, rsd_zhunxing.transform.position, Quaternion.identity) as GameObject;
                    //rsd.transform.Rotate(new Vector3(-90, 0, 0));

                    rsd_zhunxing.SetActive(false);
                    break;
                case BulletState.dazhao:

                    feiji_kp.Play();
                    dz_audio.Play();
                    GameObject dz = Instantiate(dazhao, dz_zhunxing.transform.position, Quaternion.identity) as GameObject;
                    dz.transform.rotation = bullet_pos.transform.rotation;

                    dz_zhunxing.SetActive(false);
                    break;
            }
            isFir = false;
            SendMessage("SendStringData", "065A090E");
            StartCoroutine(WaitStopTank());
        }
    }


    IEnumerator WaitStopTank()
    {
        yield return new WaitForSeconds(0.8f);
        SendMessage("SendStringData", "065A000E");
        isFir = true;

        StopCoroutine(WaitStopTank());
    }

    void WaitSendData(string data)
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0.3f)
        {
            SendMessage("SendStringData", data);
            timer = 0;
            isSend = true;
        }
    }

}
