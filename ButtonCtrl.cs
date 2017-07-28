using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonCtrl : MonoBehaviour {

	public GameObject ble_menu;

    public GameObject connect_button;
    public GameObject connectUI;
    public GameObject imagetarget;

	bool isShow=true;

    public void SeleteTank1()
    {
        connect_button.SetActive(true);
    }

    public void ShowGameUI()
    {
        connectUI.SetActive(false);
        imagetarget.GetComponent<DefaultTrackableEventHandler>().enabled = true;
    }


    public void OpenBLE()
	{
		SendMessage ("Open");
	}

	public void CloseBLE()
	{
		SendMessage ("Close");
	}

	public void ScanBLE()
	{
		SendMessage ("Scan");
	}

	public void ConnectBLE()
	{
		SendMessage ("Connect");
	}

	public void ShowHideMenuBLE()
	{
		isShow = !isShow;
		ble_menu.GetComponent<Animator> ().SetBool ("isShow",isShow);

	}
	public void QuitAPP()
	{
		Application.Quit ();
	}

    public void Button1111()
    {
        SendMessage("SetAddress","1");
        
    }
    public void Button2222()
    {
        SendMessage("SetAddress", "2");
        
    }
    public void Button3333()
    {
        SendMessage("SetAddress", "3");
        
    }
    public void Button4444()
    {
        SendMessage("SetAddress", "4");
        
    }
    public void Button55555()
    {
        SendMessage("SetAddress", "5");
        
    }
    public void Button6666()
    {
        SendMessage("SetAddress", "6");
        
    }


}
