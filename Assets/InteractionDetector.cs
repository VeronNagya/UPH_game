using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private InteractableInterface interactableInRange = null; //closest Interactable
    public GameObject interactionIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        interactionIcon.SetActive(false); //won't be shown right away
    }*/

    private PlayerInputActions inputActions;
    void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    void OnEnable()
    {
        inputActions.Player.Interact.performed += OnInteract;
        inputActions.Player.Enable();
    }
    void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInteract;
        inputActions.Player.Disable();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactableInRange?.Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out InteractableInterface interactable) && interactable.CanInteract()) //can be interacted
        {
            interactableInRange = interactable;
            interactionIcon.SetActive(true); //icon will pop-up
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out InteractableInterface interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon.SetActive(false); //icon will disappear
        }
    }
}
