using UnityEngine;

public class PossessionInput : MonoBehaviour
{
    // Things to disable while the player is possessing something.
    public MonoBehaviour[] DisableWhilePossessing;
    // Possession target the player is able to possess.
    public PossessionTarget PossessionTarget;

    // Possession target the player is currently possessing.
    private PossessionTarget _currentPossession;

    private void Update()
    {
        // If we are possessing something.
        if (_currentPossession)
        {
            // Check if we should stop.
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Stop possession.
                _currentPossession.PossessionEnded.Invoke();
                _currentPossession = null;

                foreach (MonoBehaviour mono in DisableWhilePossessing)
                {
                    mono.enabled = true;
                }
            }
        }
        // Else, if we have a target and try to possess it.
        else if (Input.GetKeyDown(KeyCode.F) && PossessionTarget)
        {
            // Possess it.
            _currentPossession = PossessionTarget;
            _currentPossession.PossessionStarted.Invoke();

            foreach (MonoBehaviour mono in DisableWhilePossessing)
            {
                mono.enabled = false;
            }
        }
    }
}