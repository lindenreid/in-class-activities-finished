using UnityEngine;

public class CatW5 : MonoBehaviour
{
    [SerializeField] private bool _flipWSControls;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _turnSpeed = 1.0f;
    [SerializeField] private Animator _animator;

    private string _isWalkingName = "IsWalking";

    private void Update()
    {
        // STEP X -------------------------------------------------------------
        Vector3 translation = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            translation += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            translation -= Vector3.forward;
        }

        // STEP X -------------------------------------------------------------
        if (_flipWSControls)
        {
            translation = -1 * translation;
        }
        // STEP X -------------------------------------------------------------

        transform.Translate(translation * _moveSpeed * Time.deltaTime);
        // STEP X -------------------------------------------------------------

        float rotation = Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if (translation.magnitude != 0.0f || rotation != 0.0f)
        {
            _animator.SetBool(_isWalkingName, true);
        }
        else
        {
            _animator.SetBool(_isWalkingName, false);
        }
    }
}
