/*using UnityEngine;

public class PossessionInput : MonoBehaviour
{
    // The player's movement component.
    public PlayerMovement PlayerMovement;
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

                // Enable player movement.
                PlayerMovement.enabled = true;
            }
        }
        // Else, if we have a target and try to possess it.
        else if (Input.GetKeyDown(KeyCode.F) && PossessionTarget)
        {
            // Possess it.
            _currentPossession = PossessionTarget;
            _currentPossession.PossessionStarted.Invoke();

            // Disable player movement.
            PlayerMovement.enabled = false;
        }
    }
}*/