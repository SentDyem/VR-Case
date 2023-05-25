using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

[Serializable]
public class QuestDB : MonoBehaviour
{
    public Transform quest;
    public NavMeshAgent agent;
    public AudioSource mainCharacter;
    public GameObject Mascot;
    public Animator animator;
    public int nums = 0;

    [System.Serializable]
    public class VRData
    {
        public int pointId;
        public string pointName;
        public bool pointCompleted;
        public string Task;
        public GameObject coordsPlace;
        public GameObject mainObject;
        public GameObject Button;
        public AudioSource clipForPoint;
        public string stateButton = "null";

        string pressedBtn;
        string movableJoystick;
    }

    [SerializeField]
    [System.Serializable]
    public class FullData
    {
        public int fullQuestCompleted;
        public string actualTask;
        public TMP_Text taskList;
        public int counterCompletedTasks;
        public bool VrStarted;
        public List<VRData> vrPoints;

    }

    public FullData dataArray = new FullData();


    public string Save()
    {
        return JsonUtility.ToJson(dataArray);

    }

    public void Load (string savedData)
    {
        JsonUtility.FromJsonOverwrite(savedData, this);

    }

    private void Start()
    {
        string boolData = JsonUtility.ToJson(dataArray);
        Debug.Log(boolData);
        File.WriteAllText(Application.dataPath + "/PotionData.txt", boolData);
        Debug.Log(Application.dataPath);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        dataArray.VrStarted = false;

    }

    public void StartVR()
    {
        dataArray.VrStarted = true;
    }
    public void UpdatePoint()
    {
        for (int i = 0; i < dataArray.vrPoints.Count; i++)
        {
            if (dataArray.vrPoints[i].pointCompleted != true && dataArray.VrStarted == true)
            {
                agent.SetDestination(dataArray.vrPoints[i].coordsPlace.transform.position);
                animator.SetBool("isWalking", true);

            }
        }
    }

    private void Update()
    {
         
        string boolData = JsonUtility.ToJson(dataArray);
        Debug.Log(boolData);
        UpdatePoint();


        for (int i = 0; i < dataArray.vrPoints.Count; i++)
        {

                if (dataArray.vrPoints[i].Button.GetComponent<HoverButton>().buttonDown == true)
                {
                    dataArray.vrPoints[i].stateButton = "Pressed";
                    dataArray.counterCompletedTasks += 1;
                    dataArray.vrPoints[i].Task += "Выполнено";
                dataArray.vrPoints[i].pointCompleted = true;
                if (dataArray.vrPoints[i].stateButton == "null" && dataArray.VrStarted == true)
                {
                    mainCharacter = dataArray.vrPoints[i].clipForPoint;
                    dataArray.vrPoints[i].stateButton = "NotPressed";
                }
            }

            if (dataArray.vrPoints[i].pointCompleted == true && dataArray.VrStarted == true)
            {
                if (Mascot.transform.localPosition == dataArray.vrPoints[i].coordsPlace.transform.position)
                {
                    animator.SetBool("isWalking", false);
                }

            }

        }
        

    }

}
