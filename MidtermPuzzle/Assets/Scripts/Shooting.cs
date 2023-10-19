using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject Cannon;
    public GameObject CannonBall;

    GameObject[] pins;
    int score = 0;
    public Text scoreUI;

    public Transform shootingPoint;

    public float force;
    public float turningSpeed;
    


    private float xRotation;
    private float yRotation;
    private float timer;
    private Boolean running = true;
    private float delay = 5;
    private Boolean spacePressed = false;
    private int shotsFired = 0;
    private Boolean[] pinDown = new Boolean[10];

    public string Lose;
    public string Strike;
    public string Spare;



    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
    }

    // Update is called once per frame
    void Update()
    {
        AimCannon();
        ShootCannon();
        ShotCounter();
    }

    public void AimCannon()
    {
        xRotation = Cannon.transform.eulerAngles.x;
        yRotation = Cannon.transform.eulerAngles.y;

        if (yRotation <= 50f ||  yRotation >= 310f)
        {
            if (Input.GetKey("d"))
            {
                yRotation += turningSpeed;
            }
            if (Input.GetKey("a"))
            {
                yRotation += -turningSpeed;
            }
        }  
        else if (yRotation > 50F && yRotation < 180f)
        {
            yRotation = 49.9f;
        }
        else if (yRotation < 310f && yRotation > 180f)
        {
            yRotation = 310.1f;
        }

        Cannon.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        

        
    }
    public void ShootCannon()
    {
        if (Input.GetKeyDown("space"))
        {
            if(spacePressed == false)
            {
                spacePressed = true;
                

                if(shotsFired == 2) //do not shoot, both shots used up
                {
                    ShotCounter(); 
                }
                else
                { //shoot cannonball
                    shotsFired++;
                    GameObject ball = Instantiate(CannonBall, shootingPoint.transform.position, Quaternion.identity);
                    Rigidbody rb = ball.GetComponent<Rigidbody>();
                    rb.AddForce(shootingPoint.forward * force, ForceMode.Impulse);
                }

                
            }
        }
        if (Input.GetKeyUp("space"))
        {
            spacePressed = false;
        }

    }
    public void ShotCounter()
    {

        if (Input.GetKeyDown("s")) {
            for (int i = 0; i < pins.Length; i++)
            {

                if (pins[i].transform.position.y < 1) 
                {
                    if (pinDown[i] == false)
                    {
                        pinDown[i] = true;
                        score++;
                    }

                }

            }
            scoreUI.text = (pins.Length - score).ToString();


            if (shotsFired == 2)
            {
               

                if (score < 10)
                {
                    
                    SceneManager.LoadScene(Lose);
                }
                if (score == 10 && shotsFired == 2)
                {
                    SceneManager.LoadScene(Spare);
                }
            }
            
            if (score == 10 && shotsFired == 1)
            {
                SceneManager.LoadScene(Strike);
            }

            
        }
        



        
    }
 
 
}
