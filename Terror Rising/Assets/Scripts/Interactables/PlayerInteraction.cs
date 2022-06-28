using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public float interactionDistance;

    public TMPro.TextMeshProUGUI interactionText;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfullHit = false;

        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if(interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfullHit = true;
            }
        }
        if (!successfullHit) interactionText.text = "";
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        if (Input.GetKeyDown(key))
        {
            interactable.Interact();
        }
    }
}
