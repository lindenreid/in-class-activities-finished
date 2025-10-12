using TMPro;
using UnityEngine;

public class CatW3 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    // The speed that the player moves at
    [SerializeField] private float _speed;
    // The velocity of the player's jump
    [SerializeField] private float _jump;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _speechText;
    [SerializeField] private float _maxHealth = 5;
    [SerializeField] private bool _destroyCatWhenDead;

    private bool _facingLeft;
    private bool _isGrounded = true;
    private int _points = 0;
    private float _health;

    // ------------------------------------------------------------------------
    private void Start ()
    {
        _health = _maxHealth;
    }

    // ------------------------------------------------------------------------
    // Update is called every frame
    private void Update()
    {
        // Detect input to move player left/right
        _rigidbody.linearVelocity = new Vector2(
            Input.GetAxis("Horizontal") * _speed,
            _rigidbody.linearVelocity.y
        );

        // Detect input to jump
        if (Input.GetAxis("Vertical") > 0 && _isGrounded)
        {
            _isGrounded = false;

            _rigidbody.linearVelocity = new Vector2(
                _rigidbody.linearVelocity.x,
                _jump
            );
        }

        // Change character facing 
        if (Input.GetAxis("Horizontal") < 0 && !_facingLeft)
        {
            _spriteRenderer.flipX = true;
            _facingLeft = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 && _facingLeft)
        {
            _spriteRenderer.flipX = false;
            _facingLeft = false;
        }

        // Set animation state parameters
        _animator.SetBool("walking", _rigidbody.linearVelocity.x != 0.0f);
    }

    // ------------------------------------------------------------------------
    // This method is called by Unity whenever the cat hits something
    //      whose collider's "Is Trigger" option is checked.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Item"))
        {
            _points++;
            _pointsText.text = "points: " + _points;
            Destroy(other.gameObject);
        }
    }

    // ------------------------------------------------------------------------
    // This method is called by Unity whenever the cat hits something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            _isGrounded = true;
        }

        BallW3 ball = collision.gameObject.GetComponent<BallW3>();
        if (ball != null)
        {
            ChangeColor(ball);

            // STEP 2 ---------------------------------------------------------
            // Below this comment, CALL the method named DecreaseHealth.
            // Notice this method's return type is void- that means we don't
            //      have to store the result anywhere.
            DecreaseHealth();

            // STEP 2 ---------------------------------------------------------

            // STEP 6 ---------------------------------------------------------
            // Write an IF STATEMENT below that does the following:
            // IF the cat's health is below or equal to 0, AND
            //      the _destroyCatWhenDead flag is true,
            // then CALL the DestroyCat method.
            //
            // Try toggling the Destroy Cat When Dead setting on the Inspector,
            //      and see how the cat is removed ONLY when it's checked!
            if(_health <= 0 && _destroyCatWhenDead)
            {
                DestroyCat();
            }

            // STEP 6 ---------------------------------------------------------
        }
    }

    // STEP 3 -----------------------------------------------------------------
    // This method decreases the player's health and updates the UI.
    //
    // Fill in the method BODY.
    // You do NOT need to change the method signature (return or parameters).
    //
    // In this method:
    // 1. Decrease the value of _health by one point.
    // 2. Uncomment and fix the next line so that it change the value of
    //      _healthText.text to display "health = " and the new value of _health.
    //    '_healthText' is a TMP_Text Component, and 'text' is the variable that
    //     decides the text that displays in the UI for this Component.
    //      Hint: there's just one operator missing!
    private void DecreaseHealth()
    {
        // write Step 3 below this comment!
        _health--;
        _healthText.text = "health = " + _health;

        // STEP 5 -------------------------------------------------------------
        // Once you've finished Step 4, CALL the GetHealthSpeechText method
        //      and store the result in _speechText's text variable.
        // This will look very similar to the above line to change _healthText ;)
        _speechText.text = GetHealthSpeechText();

        // STEP 5 -------------------------------------------------------------
    }
    // STEP 3 -----------------------------------------------------------------

    // STEP 4 -----------------------------------------------------------------
    // This method decides what TEXT to display depending on how much health
    //      the cat has left, to warn the player about low health.
    //
    // First, UNCOMMENT the method signature and brackets.
    // Then, replace the ??? with the RETURN TYPE you think the method should use.
    //
    // Finally, fill out the method BODY. This method should:
    // 1. IF the value of _health is less than HALF of _maxHealth,
    //      return "OH NO!".
    // 2. Otherwise, return "ouch".

    private string GetHealthSpeechText()
    {
        // put the method body here!
        if (_health < _maxHealth / 2)
        {
            return "OH NO!";
        }
        else
        {
            return "ouch";
        }
    }
    
    // STEP 4 -----------------------------------------------------------------

    // ------------------------------------------------------------------------
    private void ChangeColor(BallW3 ball)
    {
        // STEP 7 -------------------------------------------------------------
        // Set the value of the _spriteRenderer's color variable to the value
        //      of the ball's ballRenderer's color variable.
        // This means you'll need to use the '.' twice to get to the color :)
        _spriteRenderer.color = ball.ballRenderer.color;
        // STEP 7 -------------------------------------------------------------
    }
    
    // ------------------------------------------------------------------------
    private void DestroyCat()
    {
        Destroy(gameObject);
    }
}