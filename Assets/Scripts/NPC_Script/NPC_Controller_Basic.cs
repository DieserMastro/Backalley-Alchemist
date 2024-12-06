using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_Controller_Basic : MonoBehaviour
{
    //System Data
    private Rigidbody2D rb;
    private Vector2 pos;
    [SerializeField]
    private GameObject gameManager;
    private Game_Controller game_Controller;
    private Vector2 dTriggerPos;
    private Coroutine waitFunction;

    //Gameplay Data
    [SerializeField]
    protected float moveSpeed;
    private Vector2 moveVec;
    [SerializeField]
    private bool dialogueTriggered = false;
    [SerializeField]
    private float secToWait = 3.0f;
    private bool waitedAfterStart = false;
    

    IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = rb.transform.position;
        Debug.Log(pos.ToString());
        
        game_Controller = gameManager.gameObject.GetComponent<Game_Controller>();
        if( game_Controller != null) 
        {   
            game_Controller.TestReference();
            AssignDialogueTriggerPos();
            
        }
        if (!waitedAfterStart)
        {
            
            yield return StartCoroutine(waitForSeconds(secToWait, waitedAfterStart));
            waitedAfterStart = true;
            Debug.Log("waitedAfterStart: " + waitedAfterStart);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!dialogueTriggered && waitedAfterStart)
        {
            MoveToDTrigger();
        }
    }
    void MoveToDTrigger()

    {
        
        if (pos.x != dTriggerPos.x)
        {
            moveVec.x = 1 * Mathf.Sign(dTriggerPos.x - pos.x);
        }
        else
        {
            moveVec.x = 0; 
        }
        if (pos.y != dTriggerPos.y)
        {
            moveVec.y = 1 * Mathf.Sign(dTriggerPos.y - pos.y);
        }
        else 
        { 
            moveVec.y = 0;
        }

        rb.transform.position = pos +  (moveVec * moveSpeed * Time.deltaTime);
        if (pos.Equals(rb.transform.position))
        {
            Debug.Log("no position change");
        }
        pos = rb.transform.position;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogueTrigger"))
        {
            dialogueTriggered = true;
            game_Controller.TriggerDialogue();
        }
    }
    private void AssignDialogueTriggerPos()
    {
        dTriggerPos = game_Controller.GetDialogueTriggerPos();
    }

    private IEnumerator waitForSeconds(float seconds, bool boolToSwitch)
    {
        float currentTime = Time.time;
        yield return new WaitForSeconds(seconds);
        boolToSwitch = !boolToSwitch;
        Debug.Log("time Waited: " + (Time.time - currentTime));
        Debug.Log(boolToSwitch);
        
    }  
}
