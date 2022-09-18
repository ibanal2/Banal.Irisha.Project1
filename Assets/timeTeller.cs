using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeTeller : MonoBehaviour
{

    public GameObject timeTextObject1;
    public GameObject timeTextObject2;

        string url1 = "http://worldtimeapi.org/api/timezone/Asia/Singapore";
        // string url2 = "http://worldtimeapi.org/api/timezone/America/Winnipeg";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 10f);
    }

    // // Update is called once per frame
    // void Update()
    // {

    //     timeTextObject1.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("h:mm tt");
    // }

    void UpdateTime()
   {

       StartCoroutine(GetRequest1(url1));
    //    StartCoroutine(GetRequest2(url2));

   }

    IEnumerator GetRequest1(string uri1)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri1))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.result ==  UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                // this code will NOT fail gracefully, so make sure you have
                // your API key before running or you will get an error

            	int startDate = webRequest.downloadHandler.text.IndexOf("datetime",0);
            	int endDate = webRequest.downloadHandler.text.IndexOf(",",startDate);
				string time = webRequest.downloadHandler.text.Substring(startDate+23, (endDate-startDate-23));
                Debug.Log("time: " + time);
                // // Debug.Log ("integer temperature is " + easyTempF.ToString());
                
                // // string time = float.Parse(webRequest.downloadHandler.text.Substring(startDate+23, (endDate-startDate-23)));
				// // int easyTime = Mathf.RoundToInt(()time);
                // // //Debug.Log ("integer temperature is " + easyTempF.ToString());


                // timeTextObject1.GetComponent<TextMeshPro>().text = "" + time.ToString( "h:mm tt");
            }
        }
    }


    // 

    //     IEnumerator GetRequest2(string uri2)
    // {
    //     using (UnityWebRequest webRequest = UnityWebRequest.Get(uri2))
    //     {
    //         // Request and wait for the desired page.
    //         yield return webRequest.SendWebRequest();


    //         if (webRequest.result ==  UnityWebRequest.Result.ConnectionError)
    //         {
    //             Debug.Log(": Error: " + webRequest.error);
    //         }
    //         else
    //         {
    //             // print out the weather data to make sure it makes sense
    //             Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

    //             // this code will NOT fail gracefully, so make sure you have
    //             // your API key before running or you will get an error

    //         	// grab the current temperature and simplify it if needed
    //         	int startTemp = webRequest.downloadHandler.text.IndexOf("temp",0);
    //         	int endTemp = webRequest.downloadHandler.text.IndexOf(",",startTemp);
	// 			double tempF = float.Parse(webRequest.downloadHandler.text.Substring(startTemp+6, (endTemp-startTemp-6)));
	// 			int easyTempF = Mathf.RoundToInt((float)tempF);
    //             //Debug.Log ("integer temperature is " + easyTempF.ToString());
    //             int startConditions = webRequest.downloadHandler.text.IndexOf("main",0);
    //             int endConditions = webRequest.downloadHandler.text.IndexOf(",",startConditions);
    //             string conditions = webRequest.downloadHandler.text.Substring(startConditions+7, (endConditions-startConditions-8));
    //             //Debug.Log(conditions);

    //             timeTextObject2.GetComponent<TextMeshPro>().text = ("h:mm tt");
    //         }
    //     }
    // }

}
