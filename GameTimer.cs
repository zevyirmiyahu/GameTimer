using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

    // Timer duraction
    float totalSeconds = 0; // The total length the timer will be run for

    // timer execution
    float elapsedSeconds = 0; // how long timer has been running
    bool running = false; // flags needed to properly check timer completion

    // For finished property
    bool started = false; // flags needed to properly check timer completion

    // Starts the timer
    public void Run()
    {
        // Only runs for valid duration
        if(totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    // Update the game timer and check for finished
        if(running)
        {
            elapsedSeconds += Time.deltaTime;
            /*
             * Must check >= and NOT == since 'game' might 
             * skip over a 10th of a second and timer will continue to run 
             */
            if(elapsedSeconds >= totalSeconds) 
            {
                running = false; // stop timer from running
            }
        }
	}

    public float Duration
    {
        set
        {
            if(!running) // user can only set timer if NOT running
            {
                totalSeconds = value;
            }
        }
    }

    // Property tells whether timer has finished running
    public bool Finished
    {   // timer is finished IF it has already been started and NOT running
        // both flags must be checked
        get { return started && !running; }
    }

    // Property simply returns running boolean
    public bool Running
    {
        get { return running; }
    }
}
