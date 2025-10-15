using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoccerBall : MonoBehaviour
{
    // STEP 2 -----------------------------------------------------------------
    // write member variables from scratch
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private ParticleSystem _goalVFX;

    private int _points;
    private float _timeSinceLastGoal;
    // STEP 2 -----------------------------------------------------------------

    // STEP 1 -----------------------------------------------------------------
    // just write method and Debug.Log line inside - read documentation
    private void OnTriggerEnter(Collider other)
    {
        // STEP 3 -------------------------------------------------------------
        // write if statement, move debug.log line to inside of if statement
        if (other.gameObject.tag.Equals("Goal"))
        {
            // STEP 5 ---------------------------------------------------------
            // call MadeGoal() after you write it
            MadeGoal();
            // STEP 5 ---------------------------------------------------------
        }
        // STEP 3 -------------------------------------------------------------
    }
    // STEP 1 -----------------------------------------------------------------

    // STEP 4 -----------------------------------------------------------------
    // write MadeGoal method - move the Debug.Log into here
    private void MadeGoal()
    {
        // STEP 6 -------------------------------------------------------------
        // play VFX - read documentation
        _goalVFX.Play();
        // STEP 6 -------------------------------------------------------------

        // STEP 7 -------------------------------------------------------------
        // update points and text
        _points++;
        _pointsText.text = "points: " + _points;
        // STEP 7 -------------------------------------------------------------

        // STEP 9 -------------------------------------------------------------
        _timeSinceLastGoal = 0.0f;
        // STEP 9 -------------------------------------------------------------
    }
    // STEP 4 -----------------------------------------------------------------
    
    // STEP 8 -----------------------------------------------------------------
    // write update method to keep track of time since last goal
    // also, update timer text
    private void Update()
    {
        _timeSinceLastGoal += Time.deltaTime;
        _timeText.text = "time since last goal: " + _timeSinceLastGoal;
    }
    // STEP 8 -----------------------------------------------------------------
}
