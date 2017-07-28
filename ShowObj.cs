using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObj : MonoBehaviour {

    public GameObject map;
    public GameObject map_collider;
    public GameObject map_lizi;
    public GameObject tank_lizi;
    public GameObject player_joy;
    //public GameObject attak_button;

    private bool isShow=true;

	// Update is called once per frame
	void Update () {
		
        if(map_collider.GetComponent<BoxCollider>().enabled)
        {
            
            if (isShow)
            {
                
                isShow = false;
                StartCoroutine(WaitShowMap());
            }
        }
        //attak_button.SetActive(map_collider.GetComponent<BoxCollider>().enabled);
        player_joy.SetActive(map_collider.GetComponent<BoxCollider>().enabled);
    }


    IEnumerator WaitShowMap()
    {
        map_lizi.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        map.SetActive(true);
        yield return new WaitForSeconds(2f);
        tank_lizi.SetActive(true);
    }
}
