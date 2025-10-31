using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BatManager : MonoBehaviour
{
    [SerializeField] private float _overlapDistance;
    [SerializeField] private float _interactDistance;
    [SerializeField] private float _timeBetweenNewMessages = 0.5f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private TMP_Text _reactionUiPrefab;
    [SerializeField] private Transform _canvasTransform;
    // STEP 1 -----------------------------------------------------------------
    [SerializeField] private BatW6[] _bats;
    // STEP 1 -----------------------------------------------------------------
    // STEP 3 -----------------------------------------------------------------
    [SerializeField] private string[] _messages;
    // STEP 3 -----------------------------------------------------------------

    [SerializeField] private float[] _newTextTimers;

    // ------------------------------------------------------------------------
    private void Start()
    {
        // STEP 6 -------------------------------------------------------------
        _newTextTimers = new float[_bats.Length];
        // STEP 6 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void Update()
    {
        // STEP 7 -------------------------------------------------------------
        for (int i = 0; i < _newTextTimers.Length; i++)
        {
            _newTextTimers[i] += Time.deltaTime;
        }
        // STEP 7 -------------------------------------------------------------

        // STEP 2 -------------------------------------------------------------
        for (int i = 0; i < _bats.Length; i++)
        {
            float distance = Vector3.Distance(_bats[i].transform.position, _playerTransform.position);
            // STEP 4 ---------------------------------------------------------
            if (distance < _overlapDistance)
            {
                CreateReactions(_bats[i]);
            }
            // STEP 4 ---------------------------------------------------------
            else if (distance <= _interactDistance)
            {
                _bats[i].EnableChase(_playerTransform);
            }
            else
            {
                _bats[i].DisableChase();
            }
        }
        // STEP 2 -------------------------------------------------------------

    }

    // ------------------------------------------------------------------------
    private void CreateReactions(BatW6 bat)
    {
        // STEP 5 -------------------------------------------------------------
        int randomIndex = Random.Range(0, _messages.Length - 1);
        string message = _messages[randomIndex];
        SpawnReactionUI(bat, message);
        // STEP 5 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    // This method creates the Text GameObject at the location & with the 
    //      message specified by the parameters.
    // It also resets the _newTextTimers entry for that bat to 0.
    private void SpawnReactionUI(BatW6 bat, string message)
    {
        int index = System.Array.IndexOf(_bats, bat);

        GridLayoutGroup layout = bat.GetComponentInChildren<GridLayoutGroup>();
        if(layout != null && _newTextTimers[index] >= _timeBetweenNewMessages)
        {
            _newTextTimers[index] = 0.0f;
            TMP_Text textObj = Instantiate(_reactionUiPrefab, layout.transform);  
            textObj.text = message; 
        }
    }
}
