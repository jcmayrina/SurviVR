using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<OutlineBorder>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Door") && highlight != selection)
            {
                if (highlight.gameObject.GetComponent<OutlineBorder>() != null)
                {
                    highlight.gameObject.GetComponent<OutlineBorder>().enabled = true;
                }
                else
                {
                    OutlineBorder outline = highlight.gameObject.AddComponent<OutlineBorder>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<OutlineBorder>().OutlineColor = Color.magenta;
                    highlight.gameObject.GetComponent<OutlineBorder>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<OutlineBorder>().enabled = false;
                }
                selection = raycastHit.transform;
                selection.gameObject.GetComponent<OutlineBorder>().enabled = true;
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.gameObject.GetComponent<OutlineBorder>().enabled = false;
                    selection = null;
                }
            }
        }
    }

}