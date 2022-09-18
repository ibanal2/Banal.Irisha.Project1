using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using UnityEngine.Networking;

public class WeatherAPIScript : MonoBehaviour
{
    public GameObject weatherTextObject1;
    public GameObject weatherTextObject2;
        // add your personal API key after APPID= and before &units=
       string url1 = "http://api.openweathermap.org/data/2.5/weather?lat=14.48&lon=120.90&APPID=6271494856f3aa3782c258ca3042b1df&units=imperial";

       string url2 = "http://api.openweathermap.org/data/2.5/weather?lat=58.77&lon=94.17&APPID=14f92b00c7476897015b5b6453bf62c6&units=metric";


   
    void Start()
    {

    // wait a couple seconds to start and then refresh every 900 seconds

       InvokeRepeating("GetDataFromWeb", 2f, 900f);

   }

   void GetDataFromWeb()
   {

       StartCoroutine(GetRequest1(url1));
       StartCoroutine(GetRequest2(url2));
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

            	// grab the current temperature and simplify it if needed
            	int startTemp = webRequest.downloadHandler.text.IndexOf("temp",0);
            	int endTemp = webRequest.downloadHandler.text.IndexOf(",",startTemp);
				double tempF = float.Parse(webRequest.downloadHandler.text.Substring(startTemp+6, (endTemp-startTemp-6)));
				int easyTempF = Mathf.RoundToInt((float)tempF);
                //Debug.Log ("integer temperature is " + easyTempF.ToString());
                int startConditions = webRequest.downloadHandler.text.IndexOf("main",0);
                int endConditions = webRequest.downloadHandler.text.IndexOf(",",startConditions);
                string conditions = webRequest.downloadHandler.text.Substring(startConditions+7, (endConditions-startConditions-8));
                //Debug.Log(conditions);

                weatherTextObject1.GetComponent<TextMeshPro>().text = "" + easyTempF.ToString() + "°F\n" + conditions;
            }
        }
    }

        IEnumerator GetRequest2(string uri2)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri2))
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

            	// grab the current temperature and simplify it if needed
            	int startTemp = webRequest.downloadHandler.text.IndexOf("temp",0);
            	int endTemp = webRequest.downloadHandler.text.IndexOf(",",startTemp);
				double tempF = float.Parse(webRequest.downloadHandler.text.Substring(startTemp+6, (endTemp-startTemp-6)));
				int easyTempF = Mathf.RoundToInt((float)tempF);
                //Debug.Log ("integer temperature is " + easyTempF.ToString());
                int startConditions = webRequest.downloadHandler.text.IndexOf("main",0);
                int endConditions = webRequest.downloadHandler.text.IndexOf(",",startConditions);
                string conditions = webRequest.downloadHandler.text.Substring(startConditions+7, (endConditions-startConditions-8));
                //Debug.Log(conditions);

                weatherTextObject2.GetComponent<TextMeshPro>().text = "" + easyTempF.ToString() + "°C\n" + conditions;
            }
        }
    }
}

