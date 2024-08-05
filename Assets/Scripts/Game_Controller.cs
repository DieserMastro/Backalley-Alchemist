using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public enum gameState
    {
        MAIN_MENU,
        PAUSE,
        BAR,
        LAPTOP,
        LAB,
        ON_MISSION,
        COMBAT,
        PUZZLE
    }
    [SerializeField]
    private List<Scene> connectedScenes;


    void Start()
    {
        
    }

    
}
