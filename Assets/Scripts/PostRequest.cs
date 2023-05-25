using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MyBehavior : MonoBehaviour
{
    bool completedState = false;
    Vector3 locationInfo;
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("CompleteState", "copmpletedState");
        form.AddField("locationInfo", "locationInfo");

        using (UnityWebRequest www = UnityWebRequest.Post("test", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}