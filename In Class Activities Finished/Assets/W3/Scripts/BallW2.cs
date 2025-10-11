using TMPro;
using UnityEngine;

public class BallW2 : MonoBehaviour
{
    public SpriteRenderer ballRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _speedThreshold;

    // ------------------------------------------------------------------------
    // This method is called by Unity whenever the ball hits something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // STEP X -------------------------------------------------------------
        _rigidbody.linearVelocity *= _speedMultiplier;
        // STEP X -------------------------------------------------------------

        // STEP X -------------------------------------------------------------
        // just uncomment this
        ballRenderer.color *= GetColorMultiplier(Mathf.Abs(_rigidbody.linearVelocity.x), Mathf.Abs(_rigidbody.linearVelocity.y));
        // STEP X -------------------------------------------------------------
    }

    // STEP X -------------------------------------------------------------
    private float GetColorMultiplier(float speedx, float speedy)
    {
        float speed = (speedx + speedy) / 2.0f;
        if (speed > _speedThreshold)
        {
            return 1.5f;
        }
        return 1.0f;
    }
    // STEP X -------------------------------------------------------------
}
