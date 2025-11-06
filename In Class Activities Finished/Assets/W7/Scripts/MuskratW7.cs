using UnityEngine;

public class MuskratW7 : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce = 5.0f;

    private bool _orbitMode;
    private Transform _sphereTransform;

    // ------------------------------------------------------------------------
    private void Update()
    {
        if (_orbitMode)
        {
            MoveOrbitMode();
        }
        else
        {
            MoveNormal();
        }

        Jump();
    }

    // ------------------------------------------------------------------------
    private void MoveOrbitMode()
    {
        // STEP 3 -------------------------------------------------------------
        float leftright = Input.GetAxis("Horizontal");
        Vector3 worldUp = transform.TransformDirection(Vector3.up);
        transform.RotateAround(
            transform.position,
            worldUp,
            leftright * _rotationSpeed * Time.deltaTime
        );
        // STEP 3 -------------------------------------------------------------

        float forward = Input.GetAxis("Vertical");
        Vector3 axis = transform.TransformDirection(Vector3.right);
        transform.RotateAround(
            _sphereTransform.position,
            axis,
            forward * _rotationSpeed * Time.deltaTime
        );


        // STEP 5 -------------------------------------------------------------
        _animator.SetBool("flying", false);

        bool running = Mathf.Abs(leftright) != 0.0f || Mathf.Abs(forward) != 0.0f;
        _animator.SetBool("running", running);
        // STEP 5 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void MoveNormal()
    {
        // STEP 1 -------------------------------------------------------------
        float leftright = Input.GetAxis("Horizontal");
        transform.Rotate(leftright * Vector3.up * _rotationSpeed * Time.deltaTime);
        // STEP 1 -------------------------------------------------------------


        // STEP 2 -------------------------------------------------------------
        float movement = Input.GetAxis("Vertical");

        // incorrect movement code
        // transform.position += movement * Vector3.forward * _moveSpeed * Time.deltaTime;

        // correct movement code
        transform.Translate(movement * Vector3.forward * _moveSpeed * Time.deltaTime);
        // STEP 2 -------------------------------------------------------------


        // STEP 4 -------------------------------------------------------------
        bool flying = Mathf.Abs(_rigidbody.linearVelocity.y) >= 0.2f;
        _animator.SetBool("flying", flying);

        bool running = _rigidbody.linearVelocity.x != 0.0f;
        _animator.SetBool("running", running);
        // STEP 4 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            if (_sphereTransform != null)
            {
                Destroy(_sphereTransform.gameObject);
                _sphereTransform = null;
            }

            _orbitMode = false;
        }
    }

    // ------------------------------------------------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            _orbitMode = true;
            _rigidbody.isKinematic = true;

            _sphereTransform = collision.transform;

            ContactPoint contact = collision.GetContact(0);

            Vector3 tangent = Vector3.Cross(Vector3.right, contact.normal);

            transform.SetPositionAndRotation(
                contact.point,
                Quaternion.LookRotation(tangent, contact.normal)
            );
        }
    }
}
