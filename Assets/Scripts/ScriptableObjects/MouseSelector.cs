using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MouseSelector : MonoBehaviour {
        
    public TextManager tm;
    public Text toolTip;    

    private void Update()
    {
        toolTip.enabled = false;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (hit.collider.gameObject.GetComponent<Interactable>())
            {
                toolTip.enabled = true;
                toolTip.text = selection.name;
                toolTip.transform.position = new Vector3(Input.mousePosition.x + 70f, Input.mousePosition.y, Input.mousePosition.z);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                toolTip.color = Color.green;
            }
            else
            {
                toolTip.color = Color.white;
                EditorApplication.Beep();
            }
        }
        if (Input.GetMouseButtonUp(0))
            toolTip.color = Color.white;
        
    }

}

