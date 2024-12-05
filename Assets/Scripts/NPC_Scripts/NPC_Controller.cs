using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 pos;
    private Vector2 dialogueTriggerPos;

    //Gameplay Stuff
    
    private string npcName;
    [SerializeField]
    private float moveSpeed;
    private bool readyToWalk = false;

    public NPC_Controller(Vector2 dialogueTriggerPos, string npcName)
    {
        this.dialogueTriggerPos = dialogueTriggerPos;
        this.npcName = npcName ?? throw new ArgumentNullException(nameof(npcName));
    }

    //Technical stuff
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = rb.transform.position;
        StartWaiting(3f, readyToWalk);
        
    }

    
    void Update()
    {
       
    }
    private void StartWaiting(float waitTime, bool boolToSwitch)
    {
        StartCoroutine(WaitForSeconds(waitTime));
        boolToSwitch = !boolToSwitch;
    }
    private IEnumerator WaitForSeconds(float seconds)
    {
        Debug.Log("waiting..." + Time.time);
        yield return new WaitForSeconds(seconds);
        Debug.Log("Done waiting..." + Time.time);
    }
}
