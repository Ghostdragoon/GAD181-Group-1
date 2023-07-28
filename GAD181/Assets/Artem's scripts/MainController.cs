using UnityEngine;
using UnityEngine.InputSystem;

public class MainController : MonoBehaviour
{
    public GameObject mainMenuUI; // Assign your Main Menu UI GameObject in the Inspector

    private Collider interactableObject = null;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Interact.performed += ctx => Interact();
    }

    private void Start()
    {
        mainMenuUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Bomb"))
        {
            interactableObject = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Bomb"))
        {
            interactableObject = null;
        }
    }

    private void Interact()
    {
        if (interactableObject != null)
        {
            if (interactableObject.CompareTag("Interactable"))
            {
                mainMenuUI.SetActive(true);
            }
            else if (interactableObject.CompareTag("Bomb"))
            {
                interactableObject.GetComponent<Bomb>().Interact();
            }
        }
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}

