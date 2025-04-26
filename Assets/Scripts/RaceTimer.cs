using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private LeaderBoards leaderbord;
    
    private float raceTime = 0;
    private bool raceRunning;



    private void Update()
    {
        if(raceRunning)
            raceTime += Time.deltaTime;
    }
    private void OnEnable()
    {
        GameEvents.RaceStart += StartRace;
        GameEvents.PenaltyFlag += PenaltyPoint;
        GameEvents.RaceEnd += EndRace;
    }

    private void OnDisable()
    {
        GameEvents.RaceStart -= StartRace;
        GameEvents.PenaltyFlag -= PenaltyPoint;
        GameEvents.RaceEnd -= EndRace;
    }
    private void StartRace()
    {
        raceTime = 0;
        raceRunning = true;
        Debug.Log("Race started!");

    }

    private void PenaltyPoint()
    {
        raceTime += 2;
        Debug.Log("Player recieved penalty");

    }
    private void EndRace()
    {
        
        raceRunning = false;
        GameData.Instance.racesCompleted++;
        leaderbord.AddResult(raceTime);
        Debug.Log("Race ended! Time: "+ raceTime);
        Debug.Log("Races completed: " + 
            GameData.Instance.racesCompleted);

    }




}
