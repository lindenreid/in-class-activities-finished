using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoccerBall : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private ParticleSystem _goalVFX;

    private int _points;
    private float _timeSinceLastGoal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Goal"))
        {
            MadeGoal();
        }
    }

    private void MadeGoal()
    {
        _goalVFX.Play();

        _points++;
        _pointsText.text = "points: " + _points;

        _timeSinceLastGoal = 0.0f;
    }
    
    private void Update()
    {
        _timeSinceLastGoal += Time.deltaTime;
        _timeText.text = "time since last goal: " + _timeSinceLastGoal;
    }
}
