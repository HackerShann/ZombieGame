//////////code for MyGameManager/////
//////paste INSTEAD of existing code////////
///make sure the name of the script you are pasting into is EXACTLY MyGameManager//////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public static class ApplicationData
{
    public static bool MakeNewBullet = false;
    public static bool MakeNewTarget = false;
    public static float BulletsFired;
    public static float BulletsMax;//number of shots available
    public static float BulletsHit;
    public static float BulletsMissed;
    public static float Percentage;
    public static float HighScore;
}
public class MyGameManager : MonoBehaviour
{
    // Reference to the Prefab/gameobject. Drag a Prefab into this field in the Inspector.
    public GameObject Bullet;
    public GameObject Target;
    public GameObject Launcher;
    public GameObject Lighting;
    public Text FiredDisplay;
    public Text HitDisplay;
    public Text MissedDisplay;
    public Text PercentDisplay;
    public Text MessageDisplay;
    public Text HighScoreDisplay;

    public GameObject ReplayButton;

    void Start() // On first frame, happens once
    {
        ApplicationData.BulletsFired = 0;
        ApplicationData.BulletsMax = 10;//IMPORTANT: bullets available in every round
        ApplicationData.BulletsHit = 0;
        ApplicationData.BulletsMissed = 0;
        ApplicationData.Percentage = 0;
        ///innitialize counters

        PercentDisplay.text = "Percentage: 0.00%";
        MessageDisplay.text = "";
        HighScoreDisplay.text = "Highest Score so far: " + ApplicationData.HighScore.ToString("P1");
        ///innitialize text display

        Instantiate(Bullet, Launcher.transform.position, Launcher.transform.rotation);//make a new, first bullet


        Instantiate(Target, new Vector3(UnityEngine.Random.Range(-15.0f, 15.0f), 0.5f, 7f), Quaternion.identity);
        //make a new target, random x from __ to __
    }

    // Update is called once per frame
    void Update()
    {



        FiredDisplay.text = "Bullets Fired: " + ApplicationData.BulletsFired.ToString() + " out of " + ApplicationData.BulletsMax.ToString();
        HitDisplay.text = "Bullets hit: " + ApplicationData.BulletsHit.ToString();
        ApplicationData.BulletsMissed = ApplicationData.BulletsFired - ApplicationData.BulletsHit;
        MissedDisplay.text = "Bullets missed: " + ApplicationData.BulletsMissed.ToString();

        //now we calculate percentage of success
        if (ApplicationData.BulletsHit > 0)
        { //so we don't devide by 0
            ApplicationData.Percentage = ApplicationData.BulletsHit / ApplicationData.BulletsFired;
            PercentDisplay.text = "Percentage: " + ApplicationData.Percentage.ToString("P1");
        }
        else
        {
            ApplicationData.Percentage = 0;
            PercentDisplay.text = "Percentage: " + ApplicationData.Percentage.ToString("P1");
        }







        if (ApplicationData.BulletsFired < ApplicationData.BulletsMax)
        { //if there are still bullets left

            ///update text display

            if (ApplicationData.MakeNewBullet == true)
            {//if something told us its time to instaciate a new bullet (a hit or a miss)....

                ApplicationData.MakeNewBullet = false;

                Instantiate(Bullet, Launcher.transform.position, Launcher.transform.rotation);
                ApplicationData.BulletsFired++;

            }

            if (ApplicationData.MakeNewTarget == true)
            {//if something told us its time to instaciate a new target (prev one destroyed)
                ApplicationData.MakeNewTarget = false;

                Instantiate(Target, new Vector3(UnityEngine.Random.Range(-15.0f, 15.0f), 0.5f, 7f), Quaternion.identity);//make a new target, random x from __ to __
                ApplicationData.BulletsHit++;
                print("add hit");

            }

        }
        else//no bullets left
        {
            ApplicationData.MakeNewTarget = false;
            ApplicationData.MakeNewBullet = false;
            MessageDisplay.text = "GAME OVER!";

            ReplayButton.SetActive(true);//show replay button
            Lighting.SetActive(false);//turn off the lights

        }//end if not out of bullets
    }//end update

    public void MyReplay()
    {

        if (ApplicationData.Percentage > ApplicationData.HighScore)//if got a higher score than prev so far...
        {
            ApplicationData.HighScore = ApplicationData.Percentage; //make that the new higbhr score

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//go to same scene we are on now, reload

        // print("replay");
    }//end MyReplay



    public void ExitGame()//a function to be called by the exit button
    {
        Application.Quit();
    }

}//class
