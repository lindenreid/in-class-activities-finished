using TMPro;
using UnityEngine;

public class CatW2 : MonoBehaviour
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
    [SerializeField] private float _health = 5;
    [SerializeField] private bool _destroyCatWhenDead;

    private bool _facingLeft;
    private bool _isGrounded = true;
    private int _points = 0;

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
    // This method is called by Unity whenever the cat hits something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            _isGrounded = true;
        }
        
        BallW2 ball = collision.gameObject.GetComponent<BallW2>();
        if (ball != null)
        {
            ChangeColor(ball);

            // STEP X ---------------------------------------------------------
            DecreaseHealth();
            Debug.Log("health: " + _health);

            if (_health <= 0 && _destroyCatWhenDead)
            {
                DestroyCat();
            }
            // STEP X -------------------------------------------------------------
        }
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

    // STEP X -----------------------------------------------------------------
    private void DecreaseHealth()
    {
        _health--;
        _healthText.text = "health: " + _health;
        _speechText.text = GetHealthSpeechText();
    }
    // STEP X -----------------------------------------------------------------
    
    // STEP X -----------------------------------------------------------------
    // decide the return type here & write the method
    private string GetHealthSpeechText ()
    {
        string response = "ouch";
        if (_health <= _health / 2)
        {
            response = "OH NO!";
        }
        return response;
    }
    // STEP X -----------------------------------------------------------------

    // ------------------------------------------------------------------------
    private void DestroyCat()
    {
        Destroy(gameObject);
    }
    
    // ------------------------------------------------------------------------
    private void ChangeColor(BallW2 ball)
    {
        // STEP X -------------------------------------------------------------
        _spriteRenderer.color = ball.ballRenderer.color;
        // STEP X -------------------------------------------------------------
    }
}