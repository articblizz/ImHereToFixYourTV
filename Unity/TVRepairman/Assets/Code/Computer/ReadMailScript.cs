﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadMailScript : MonoBehaviour {

	public Text SubjectText;
	public Text SenderText;
	public Text BodyText;

    public MissionMng missionMng;

    public GameObject RemoveButton;
    public GameObject AcceptMissionButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void RemoveSelectedMail()
    {
        Destroy(selectedObj, 0.2f);

        SubjectText.text = "";
        SenderText.text = "";
        BodyText.text = "";
    }

    GameObject selectedObj;


    public void ReloadMail(MailScript mail)
    {
        SubjectText.text = mail.Subject;
        SenderText.text = "From: " + mail.Sender;
        BodyText.text = mail.Body;
        mail.Read();

        if (mail.isMission)
        {
            AcceptMissionButton.SetActive(true);
            RemoveButton.SetActive(false);
        }
        else
        {
            AcceptMissionButton.SetActive(false);
            RemoveButton.SetActive(true);

        }
        selectedObj = mail.gameObject;
    }

    public void AcceptMission()
    {
        //Application.LoadLevel(selectedObj.GetComponent<MailScript>().MissionTarget);
        missionMng.currentMission = selectedObj.GetComponent<MailScript>().MissionTarget;
        missionMng.missionIsActive = true;
        AcceptMissionButton.GetComponent<Button>().interactable = false;
    }

}
