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
        Debug.Log("MainController Awake");
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Interact.performed += ctx => Interact();
    }

    private void Start()
    {
        Debug.Log("MainController Start");
        mainMenuUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered with " + other.tag);
        if (other.CompareTag("Interactable") || other.CompareTag("Bomb"))
        {
            interactableObject = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited with " + other.tag);
        if (other.CompareTag("Interactable") || other.CompareTag("Bomb"))
        {
            interactableObject = null;
        }
    }

    private void Interact()
    {
        Debug.Log("Interact function called");
        if (interactableObject != null)
        {
            Debug.Log("Interactable object is not null, it's tag is " + interactableObject.tag);
            if (interactableObject.CompareTag("Interactable") && interactableObject.GetComponent<InteractableObject>().GetIsPlayerNearby())
            {
                Debug.Log("Interactable object detected and player is nearby");
                mainMenuUI.SetActive(true);
            }
            
        }
        else
        {
            Debug.Log("No interactable object");
        }
    }

    private void OnEnable()
    {
        Debug.Log("MainController enabled");
        onFoot.Enable();
    }

    private void OnDisable()
    {
        Debug.Log("MainController disabled");
        onFoot.Disable();
    }
}


