using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Canvas uiCanvas;
    public Canvas messageCanvas;
    private Vector3 respawnCoordinates;
    private CharacterController character;
    private GameObject checkPointUsed;
    private float timeToPass;
    private bool checkPoint;
    private bool respawning;
    private float respawningTime;
    private void Start()
    {
        respawnCoordinates = this.transform.position;
        character = this.gameObject.GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SetCheckPoint();
        }

        if(checkPoint)
        {
            if(timeToPass < 1f)
            {
                timeToPass += Time.deltaTime;
            } else
            {
                messageCanvas.gameObject.SetActive(false);
                checkPoint = false;
            }
        }

        if (respawning)
        {
            if(respawningTime > 0.5f)
            {
                respawning = false;
            } else
            {
                respawningTime += Time.deltaTime;
            }
        }
    }
    public void Respawn()
    {
        character.enabled = false;
        respawning = true;
        respawningTime = 0;
        this.character.transform.position = (respawnCoordinates);
        character.enabled = true;
    }
    public void SetCheckPoint()
    {
        if (respawning == false)
        {
            respawnCoordinates = this.transform.position;
            timeToPass = 0;
            checkPoint = true;
            messageCanvas.gameObject.SetActive(true);
        }
    }
    public void SetCheckPoint(GameObject checkPointJustUsed)
    {
        if (respawning == false)
        {
            respawnCoordinates = this.transform.position;
            timeToPass = 0;
            checkPoint = true;
            messageCanvas.gameObject.SetActive(true);
            if(checkPointUsed != null)
                checkPointUsed.SetActive(true);
            checkPointUsed = checkPointJustUsed;
            checkPointUsed.SetActive(false);
        }
    }
}
