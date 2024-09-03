using Nova;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Utilities;

public class TouchInputSample : UnityEngine.MonoBehaviour
{
    private void OnEnable()
    {
        // Since we use the polling-based EnhancedTouchSupport APIs, we need
        // to explicitly enable them
        EnhancedTouchSupport.Enable();
    }

    private void Update()
    {
        ReadOnlyArray<Touch> touches = Touch.activeTouches;

        for (int i = 0; i < touches.Count; i++)
        {
            Touch touch = touches[i];

            // Convert the touch point to a world-space ray.
            UnityEngine.Ray ray = UnityEngine.Camera.current.ScreenPointToRay(touch.screenPosition);

            // Create a new Interaction from the ray, and give it a source ID.
            Interaction.Update interaction = new Interaction.Update(ray, (uint)touch.finger.index);

            // If the touch phase is valid, hasn't ended, and hasn't been canceled, then pointerDown == true.
            bool pointerDown = touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled;

            // Feed the update and pressed state to Nova's Interaction APIs
            Interaction.Point(interaction, pointerDown);
        }
    }
}