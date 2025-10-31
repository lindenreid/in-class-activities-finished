using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float _maxTime = 5.0f;
    private float _time;

    // ------------------------------------------------------------------------
    void Start()
    {
        _time = _maxTime;
    }

    // ------------------------------------------------------------------------
    void Update()
    {
        _time -= Time.deltaTime;
        if(_time <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
