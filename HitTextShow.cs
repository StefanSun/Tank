using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NumberText
{
    putong,
    baoji
}
public class HitTextShow : MonoBehaviour
{
    //public NumberText hit_text = NumberText.putong;
    //public float timer = 1f;
    // Use this for initialization
    void Start()
    {
        //timer = Random.Range(8f, 15f) / 10f;
    }

    // Update is called once per frame
    void Update()
    {

        //if (timer > 0)
        //{
        //    timer -= Time.deltaTime;
        //    this.transform.Translate(Vector3.up * Time.deltaTime * 5f);
        //    if (hit_text == NumberText.baoji)
        //    {
        //        this.transform.localScale = this.transform.localScale+ new Vector3(0.05f, 0.05f, 0.05f);
        //    }
        //}
        //else
        //{

        //    Destroy(this.gameObject);
        //}
    }
    public void ScaleToBig()
    {
        iTween.ScaleTo(this.gameObject, new Vector3(3, 3, 3), 2);
    }
    public void CloseText()
    {
        Destroy(this.gameObject);
    }
}
