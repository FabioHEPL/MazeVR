using MazeVR;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send_Player_Position : MonoBehaviour
{
    private OSC osc;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool send = true;

    [SerializeField]
    private int tickrate = 1;

    [SerializeField]
    private bool sending = false;

    private void Awake()
    {
        this.osc = FindObjectOfType<OSC>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!sending && send)
        {
            StartCoroutine(Send_Position());
        }
        else if (sending && !send)
        {
            StopCoroutine(Send_Position());
        }


    }

    private IEnumerator Send_Position()
    {
        sending = true;

        while (send)
        {
            NetworkPositionUpdate();
            yield return new WaitForSecondsRealtime(1 / tickrate);
        }

        sending = false;
    }

    private void NetworkPositionUpdate()
    {
        OscMessage message = new OscMessage();
        message.address = "/PositionUpdate";
        message.values.Add(player.transform.position.x);
        message.values.Add(player.transform.position.y);
        message.values.Add(player.transform.position.z);
        osc.Send(message);

        Debug.Log($"Tickrate : {tickrate} | Sending player position.");
    }


}
