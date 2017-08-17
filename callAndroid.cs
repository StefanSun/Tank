using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class BlueToochID
{
    public string name;
    public string address;
}


public class callAndroid : MonoBehaviour
{

    public GameObject[] shebei_list;
    public GameObject bt_list_ui;

    AndroidJavaClass unityPlayer;
    AndroidJavaObject currentActivity;
    AndroidJavaObject oj;
    // Use this for initialization

    float power = 100.0f;
    Text pos_text;
    Text BLE_state;
    Text power_text;
    BlueToochID[] bt_list = new BlueToochID[10];

    int A_pos_x;
    int A_pos_y;
    int B_pos_x;
    int B_pos_y;
    bool isConect = false;
    string order = "";
    string bt_address = "";
    string bluetooth_list = "";

    void Start()
    {
        //pos_text = GameObject.Find("Canvas/POS_Text/Text").GetComponent<Text>();
        BLE_state = GameObject.Find("Canvas/BLE_Text/BLE_state").GetComponent<Text>();
        power_text = GameObject.Find("Canvas/Power_Text/p_num").GetComponent<Text>();


        unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        oj = new AndroidJavaObject("com.funloong.sdk.bluetooth.BleManager", currentActivity);

    }



    //    void OnGUI()
    //    {
    //        GUI.skin.BLE_staterea.fontSize = 35;
    //        GUI.skin.button.fontSize = 35;
    //
    //        if (GUI.Button(new Rect(50, 50, 300, 90), "查看蓝牙状态"))
    //        {
    //
    //            string state = oj.Call<string>("getBluetoothState");
    //            //GetComponent<GUIText> ().text = "蓝牙状态: "+state;
    //            //player.guiText="蓝牙状态: "+state;
    //            text.text = "蓝牙状态: " + state;
    //
    //        }
    //
    //        if (GUI.Button(new Rect(50, 160, 300, 90), "手动打开蓝牙"))
    //        {
    //
    //            oj.Call("openBluetooth");
    //
    //        }
    //        if (GUI.Button(new Rect(50, 270, 300, 90), "手动关闭蓝牙"))
    //        {
    //
    //            oj.Call("closeBluetooth");
    //            ClearBLEData();
    //        }
    //        if (GUI.Button(new Rect(50, 380, 300, 90), "扫描蓝牙可用设备"))
    //        {
    //
    //            oj.Call("scanLeDevice", true);//true
    //            //bluetooth_list = bt_text.GetComponent<InputField>().text;//{"name":"nu  ll","address":"8F:5C:01:23:1K","sis":"-89"}
    //            StartCoroutine("BlueToochData");
    //            WaitCloseIE(8f, "BlueToochData");
    //            bt_list_ui.SetActive(true);
    //        }
    //        if (GUI.Button(new Rect(50, 490, 300, 90), "连接蓝牙设备"))
    //        {
    //            //mac "08:7C:BE:00:00:01"
    //            //String uuidQppService = "0000fee9-0000-1000-8000-00805f9b34fb";
    //            //String uuidQppCharWrite = "d44bc439-abfd-45a2-b575-925416129600";	
    //            if (bt_address != "")
    //            {
    //                string[] arr = { bt_address, "0000fee9-0000-1000-8000-00805f9b34fb", "d44bc439-abfd-45a2-b575-925416129600" };
    //                oj.Call("connectGATTServer", arr);
    //                DebugConsole.Log(bt_address);
    //            }
    //            bt_list_ui.SetActive(false);
    //        }
    //        if (GUI.Button(new Rect(50, 600, 300, 90), "发送指令"))
    //        {
    //            //TODO 必须在5003才能发送 表示BLE准备好了,可以连接
    //            oj.Call("sendData", "065A010E");//"065A010E"，0x 06A5 0000 0000 0000 0000 C201 0100 00BE 7C08 0E
    //
    //        }
    //        if (GUI.Button(new Rect(50, 710, 300, 90), "关闭蓝牙退出"))
    //        {
    //
    //            oj.Call("onDestroy");
    //            Application.Quit();
    //
    //        }
    //    }

    //蓝牙的打开、关闭、搜索、连接方法，供调用

    void Open()
    {
        oj.Call("openBluetooth");
    }

    void Close()
    {
        oj.Call("closeBluetooth");
        ClearBLEData();
    }

    void Scan()
    {
        oj.Call("scanLeDevice", true);//true
        StartCoroutine("BlueToochData");
        //10s后关闭搜索蓝牙
        WaitCloseIE(10f, "BlueToochData");
        bt_list_ui.SetActive(true);
    }

    void Connect()
    {
        string[] arr = { "08:7C:BE:00:00:01", "0000fee9-0000-1000-8000-00805f9b34fb", "d44bc439-abfd-45a2-b575-925416129600" };
        oj.Call("connectGATTServer", arr);
        //if (bt_address != "")
        //{
        //    //string[] arr = { bt_address, "0000fee9-0000-1000-8000-00805f9b34fb", "d44bc439-abfd-45a2-b575-925416129600" };
        //    string[] arr = { "08:7C:BE:00:00:01", "0000fee9-0000-1000-8000-00805f9b34fb", "d44bc439-abfd-45a2-b575-925416129600" };
        //    oj.Call("connectGATTServer", arr);
        //    DebugConsole.Log(bt_address);
        //}
        //bt_list_ui.SetActive(false);
    }

    //蓝牙的状态接收

    public void sendBleState(string json)
    {
        //BLE_state.text = "sendBleState: " + json;
        string state = json.Split(new char[] { ',' })[0].Split(new char[] { ':' })[1].Trim();
        switch (state)
        {
            case "12":
                BLE_state.text = "已打开";
                break;
            case "10":
                
                //BLE_state.text = "已打开";
                break;
            case "13":
                
                //BLE_state.text = "关闭中";
                break;
            case "5002":
                
                //BLE_state.text = "未连接";
                break;
            case "5003":
                
                //BLE_state.text = "未连接";
                break;
            case "5004":
                
                //BLE_state.text = "未连接";
                break;

        }


        /*
		 * 5004	BLE未连接
		 * 5002 
		 * 5003
		 * 13	关闭中
		 * 10	已关闭
		 * 12	已打开
		 * 
		*/
    }

    //蓝牙的搜索到的设备信息接收
    public void sendBleDevice(string json)
    {
        if (bluetooth_list.Length > 1)
        {
            bluetooth_list = bluetooth_list + "*" + json;
        }
        else
        {
            bluetooth_list = json;
        }
    }


    bool isSend = true;
    //蓝牙接收到的回调信息接收处理
    public void receiveData(string json)
    {

        order = json.Substring(json.IndexOf("receive_data"), json.IndexOf("device_name") - json.IndexOf("receive_data") - 2).Substring(21);
        if(isSend)
        {
            isSend = false;
            SendMessage("ShowGameUI");
        }
        
        string B_pos = order.Substring(1, 7);
        if (B_pos == "0000000")
        {
            //位置丢失
        }
        else
        {
            B_pos = TransFormHex16to2(B_pos);
            B_pos_y = System.Convert.ToInt32(B_pos.Substring(0, 14), 2);
            B_pos_x = System.Convert.ToInt32(B_pos.Substring(15), 2);
        }

        string A_pos = order.Substring(9, 7);
        if (A_pos == "0000000")
        {
            //位置丢失
        }
        else
        {
            A_pos = TransFormHex16to2(A_pos);
            A_pos_y = System.Convert.ToInt32(A_pos.Substring(0, 14), 2);
            A_pos_x = System.Convert.ToInt32(A_pos.Substring(15), 2);
        }
        //pos_text.text = "A点（" + A_pos_x + "," + A_pos_y + "）,B点（" + B_pos_x + "," + B_pos_y + ")";
        int[] pos = { A_pos_x, A_pos_y, B_pos_x , B_pos_y };
        SendMessage("SetPlayerPosition", pos);


        string s_num = order.Substring(18, 2) + order.Substring(16, 2);
        float d_num = float.Parse(System.Convert.ToInt32(s_num).ToString()) / 500.0f;
        float p = System.Convert.ToInt32((d_num / 4.097f) * 100);
        
        if (power > p)
        {
            power = p;
        }
        power_text.text = power.ToString() + "%";
    }


    //给蓝牙发送消息,供调用
    public void SendStringData(string data)
    {
        oj.Call("sendData", data);
    }


    //更新蓝牙列表方法，每2.5s刷新一次
    int bt_num = 0;
    bool isExist = false;
    IEnumerator BlueToochData()
    {
        //DebugConsole.Log("更新蓝牙列表:" + bluetooch_address);
        if (bluetooth_list.Length > 10)
        {
            bluetooth_list = bluetooth_list.Remove(0, 1);
            string[] bts;
            isExist = false;
            if (bluetooth_list.Contains("*"))
            {
                bts = bluetooth_list.Split(new char[] { '*' });

            }
            else
            {
                bts = new string[1];
                bts[0] = bluetooth_list;
            }

            for (int i = 0; i < bts.Length; i++)
            {
                string[] b = bts[i].Split(new char[] { ',' });
                string btname = b[0].Trim().Split(new char[] { ':' })[1].Replace("\"", "");
                string btaddress = b[1].Replace("\"", "").Substring(8);

                if (bt_list.Length > 0)
                {
                    foreach (var item in bt_list)
                    {
                        if (item != null)
                        {
                            //Debug.Log(item.address + "__" + btaddress);
                            if (btaddress == item.address)
                            {
                                isExist = true;
                            }
                        }
                    }
                }
                if (!isExist)
                {
                    // DebugConsole.Log("添加数据");//, "normal");//warning,error
                    // Debug.Log("添加数据");
                    bt_list[bt_num] = new BlueToochID();
                    bt_list[bt_num].name = btname;
                    bt_list[bt_num].address = btaddress;

                    shebei_list[bt_num].GetComponent<Text>().text = bt_list[bt_num].name + ">>>" + bt_list[bt_num].address;

                    bt_num += 1;
                }
                isExist = false;
            }
        }
        yield return new WaitForSeconds(2.5f);

        StartCoroutine("BlueToochData");
    }


    //延时关闭异步协程
    IEnumerator WaitCloseIE(float t, string mathname)
    {
        yield return new WaitForSeconds(t);
        StopCoroutine(mathname);
    }


    //用户用按钮选择蓝牙列表里的蓝牙ID
    public void SetAddress(string num)
    {
        bt_address = bt_list[int.Parse(num) - 1].address;
        //DebugConsole.Log(bt_address);

    }

    void ClearBLEData()
    {
        foreach (var item in shebei_list)
        {
            item.GetComponent<Text>().text = "Null...";
        }
        bt_num = 0;
        isExist = false;
        bt_address = "";
        bluetooth_list = "";
        bt_list = new BlueToochID[10];
        bt_list_ui.SetActive(false);
    }

    string TransFormHex16to2(string str)
    {
        string temp = "";
        foreach (var item in str)
        {
            switch (item)
            {
                case '0':
                    temp += "0000";
                    break;
                case '1':
                    temp += "0001";
                    break;
                case '2':
                    temp += "0010";
                    break;
                case '3':
                    temp += "0011";
                    break;
                case '4':
                    temp += "0100";
                    break;
                case '5':
                    temp += "0101";
                    break;
                case '6':
                    temp += "0110";
                    break;
                case '7':
                    temp += "0111";
                    break;
                case '8':
                    temp += "1000";
                    break;
                case '9':
                    temp += "1001";
                    break;
                case 'A':
                    temp += "1010";
                    break;
                case 'B':
                    temp += "1011";
                    break;
                case 'C':
                    temp += "1100";
                    break;
                case 'D':
                    temp += "1101";
                    break;
                case 'E':
                    temp += "1110";
                    break;
                case 'F':
                    temp += "1111";
                    break;
            }
        }
        return temp;
    }

}
