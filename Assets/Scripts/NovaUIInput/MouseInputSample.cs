using Nova;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputSample : MonoBehaviour
{
    public const uint MousePointerControlID = 1;
    public const uint ScrollWheelControlID = 2;

    /// <summary>
    /// Inverts the mouse wheel scroll direction.
    /// </summary>
    public bool InvertScrolling = true;

    private void Update()
    {
        if (Mouse.current == null)
        {
            return;
        }

        // Get the mouse ray in world space
        Vector2 position = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(position);

        Vector2 mouseScrollDelta = Mouse.current.scroll.ReadValue();

        // Check if there is any scrolling this frame
        if (mouseScrollDelta != Vector2.zero)
        {
            // Normalize the scroll delta to be more consistent with
            // the legacy Input.mouseScrollDelta API
            mouseScrollDelta = mouseScrollDelta.normalized;

            if (InvertScrolling)
            {
                mouseScrollDelta.y *= -1f;
            }

            // Create a new Interaction.Update from the mouse ray and scroll wheel control id
            Interaction.Update scrollInteraction = new Interaction.Update(mouseRay, ScrollWheelControlID);

            // Feed the scroll update and scroll delta into Nova's Interaction APIs
            Interaction.Scroll(scrollInteraction, mouseScrollDelta);
        }

        // Create a new Interaction.Update from the mouse ray and pointer control id
        Interaction.Update pointInteraction = new Interaction.Update(mouseRay, MousePointerControlID);

        // Feed the pointer update and pressed state to Nova's Interaction APIs
        bool pressed = Mouse.current.leftButton.isPressed;
        Interaction.Point(pointInteraction, pressed);
    }
}