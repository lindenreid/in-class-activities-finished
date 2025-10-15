using UnityEngine;

public class CatW4 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _turnSpeed = 1.0f;
    [SerializeField] private float _kickUpwardForce = 1.0f;
    [SerializeField] private float _kickForce = 1.0f;
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Animator _animator;

    private string _isWalkingName = "IsWalking";
    private string _groundName = "ground";
    private string _ballName = "Ball";

    private bool _isGrounded = true;

    // ------------------------------------------------------------------------
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody.linearVelocity = new Vector3(_rigidBody.linearVelocity.x, 0f, _rigidBody.linearVelocity.z);
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

        if (translation != 0.0f || rotation != 0.0f)
        {
            _animator.SetBool(_isWalkingName, true);
        }
        else
        {
            _animator.SetBool(_isWalkingName, false);
        }
    }

    // ------------------------------------------------------------------------
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_groundName))
        {
            _isGrounded = true;
        }
    }

    // ------------------------------------------------------------------------
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_groundName))
        {
            _isGrounded = false;
        }
    }

    // ------------------------------------------------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_ballName))
        {
            Rigidbody ballRigibody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigibody != null)
            {
                Vector3 kickDirection = (collision.transform.position - transform.position).normalized;
                kickDirection.y += _kickUpwardForce;

                ballRigibody.AddForce(kickDirection * _kickForce, ForceMode.Impulse);
                ballRigibody.AddTorque(Vector3.up * _kickForce * 0.2f, ForceMode.Impulse);
            }
        }
    }
}
