using TMPro;
using UnityEngine;

public class BallW3 : MonoBehaviour
{
    public SpriteRenderer ballRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speedMultiplier = 1.0f;
    [SerializeField] private float _speedThreshold = 10.0f;

    // ------------------------------------------------------------------------
    // This method is called by Unity whenever the ball hits something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // STEP 1 -------------------------------------------------------------
        // We can access the member variables of another class using the '.' symbol.
        // For example, we can use the variabled named 'linearVelocity' on
        //      our _rigidbody object by typing '_rigidbody.linearVelocity'.
        //
        // Uncomment and fix this line to multiply the _rigidbody.linearVelocity
        //      times the _speedMultiplier variable. 
        //
        // This will make the ball go faster (or slower!) depending on the value
        //      of _speedMultiplier. TUNE that value in the Inspector and see
        //      what happens!

        _rigidbody.linearVelocity *= _speedMultiplier;

        // STEP 1 -------------------------------------------------------------

        // STEP 9 -------------------------------------------------------------
        // After you write the GetColorMultiplier method, simply uncomment
        //      the below line.
        ballRenderer.color *= GetColorMultiplier(Mathf.Abs(_rigidbody.linearVelocity.x), Mathf.Abs(_rigidbody.linearVelocity.y));
        // STEP 9 -------------------------------------------------------------
    }

    // STEP 8 -----------------------------------------------------------------
    // The GetColorMultiplier method creates a multiplier that will be used to
    //      make the balls brighter each time they bounce, IF they are moving
    //      at a certain speed.
    // Input: two floats - one for the X speed of the ball, one for the Y speed
    // Output: a multiplier number (with decimals)
    //
    // Uncomment the method SIGNATURE and brackets below.
    // Fill in the ???s with the RETURN type and 2 PARAMETERS of the method.
    //
    // Then, fill in the method BODY.
    // First, calculate the average value of the speed input values.
    // Then, IF the average speed is greater than _speedThreshold,
    //      return a value of 1.5,
    //      otherwise, return a value of 1.0. 

    private float GetColorMultiplier(float speedX, float speedY)
    {
        // write the method body here!
        float avgValue = (speedX + speedY) / 2.0f;
        if (avgValue > _speedThreshold)
        {
            return 1.5f;
        }
        return 1.0f;
    }

    // STEP 8 ------------------------------------------------------------------
}
