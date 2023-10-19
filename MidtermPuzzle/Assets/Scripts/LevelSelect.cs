using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update

    public string Level_1;
    public string Level_2;
    public string ControlsAndRules;
    public string Credits;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        SceneManager.LoadScene(Level_1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(Level_2);
    }
    public void ControlsAndRulez()
    {
        SceneManager.LoadScene(ControlsAndRules);
    }
    public void Creditz()
    {
        SceneManager.LoadScene(Credits);
    }
    
}
