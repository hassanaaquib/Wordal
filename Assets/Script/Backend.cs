using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Net;
using System;
using System.IO;



public class Backend : MonoBehaviour
{
    public TextAsset textJson;
    Manager manager;

    public class Wordly
    {
        public string word;
    }

    void Start()
    {

        manager = FindAnyObjectByType<Manager>();
        // A correct website page.
        StartCoroutine(GetRequest("https://asia-south1-dj-ui-dev.cloudfunctions.net/wordlewordV2"));

      /*  // A non-existing page.
        StartCoroutine(GetRequest("https://error.html"));*/
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    string str = webRequest.downloadHandler.text;

                    Wordly root = new Wordly();
                    root = JsonUtility.FromJson<Wordly>(str);
                    Debug.Log(root.word);
                    manager.GETAnswer(root.word);
                    break;
            }
        }
    }

}
