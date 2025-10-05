using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField] private TMP_Text _bouncesText;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;

    private int _bounces;

    // ------------------------------------------------------------------------
    // This code runs whenever the ball hits something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Uncomment ONE of the blow lines of code to ADD ONE
        //      to the value of the variable named '_bounces'.
        // _bounces = _bounces + 2;
        // _bounces + 1
        // _bounces --;
        _bounces++;
        // _bounces += 1

        // This line sets the value of the text on screen to the word "Bounces"
        //      plus the number of times the ball has bounced.
        // We can use the addition operator on strings too!
        // It concatenates (combines) the strings together into one long string.
        _bouncesText.text = "Bounces: " + _bounces;

        // In data, colors are usually stored as "RGB channels", meaning,
        //      Red, Green, and Blue are mixed together in different intensities
        //      to create the color.
        // These variables represent the Red, Green, and Blue values
        //      of the color of your ball.
        float r = _spriteRenderer.color.r;
        float g = _spriteRenderer.color.g;
        float b = _spriteRenderer.color.b;

        // Uncomment ONE of the below lines to ADD 0.1 to the value of 'r'.
        // r += 0.1f
        // r * 0.1;
        r = r + 0.1f;
        // r = r * 0.1f;
        // r += 0.1;

        // RGB values can only go from 0.0 - 1.0.
        // So, if the value of 'r' gets to above 1.0, we want to set it back to 0.0
        //      so that we can start over and keep increasing it again.
        if (r > 1.0f)
        {
            // Uncomment ONE of the below lines of code to set the value of 'r' to ZERO.
            // r = 0.0f
            r = 0.0f;
            // r 0.0f;
        }

        // Uncomment the below line and fix it to SUBTRACT 0.1 from the value of 'g'.
        g -= 0.1f;
        //g -= 0.1f

        if (g < 0.0f)
        {
            // Uncomment the below line and fix it to set the value of 'g' to ONE.
            g = 1.0f;
            // g = 1.0;
        }

        // Below this comment, write a line of code to MULTIPLY 'b' by 1.2.
        b *= 1.2f;

        // Below this comment, write an IF STATEMENT:
        // IF the value of 'b' is GREATER THAN **OR** EQUAL TO 1.0,
        //      set 'b' to 0.1. 
        if (b >= 1.0f)
        {
            b = 0.1f;
        }

        // This line assigns a new color to your Ball with the new RGB values
        //      we just created.
        // Don't worry about how it works yet; we'll learn about this later :)
        Color newColor = new Color(r, g, b);
        _spriteRenderer.color = newColor;

        // This line prints the value of your new color to the Console window.
        // We'll talk more about how this line works next week also :)
        Debug.Log(newColor);
    }
}