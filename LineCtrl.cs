using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCtrl : MonoBehaviour
{

    public GameObject number;
    public GameObject pos_1;
    public GameObject pos_2;

    //线段渲染器  
    private LineRenderer lineRenderer;

    //设置线段的个数，标示一个曲线由几条线段组成  
    private int lineLength = 2;


    void Start()
    {
        //lineRenderer = this.GetComponent<LineRenderer>();
        //lineRenderer.SetVertexCount(lineLength);

        //lineRenderer.SetColors(Color.black, Color.white);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(number, Vector3.zero, Quaternion.identity);

        }
        //lineRenderer.SetPosition(0, pos_1.transform.position);
        //lineRenderer.SetPosition(1, pos_2.transform.position);

    }
}
