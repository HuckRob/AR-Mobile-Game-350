using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    public int ID;
    public TextMeshProUGUI inventoryPositionText;
    public bool clicked = false;
    private LevelEditorManager editor;
    void Start()
    {
        inventoryPositionText.text = (ID+1).ToString();
        editor = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
    }

    public void ButtonClicked()
    {
        //reference the mouse position
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        clicked = true;

        //Create A floting image of the obeject before you place it
        Instantiate(editor.ItemImage[ID], new Vector3(worldPosition.x, worldPosition.y, worldPosition.z), Quaternion.identity);
        //after you place it destroy the placeholder showing where it will go
        Destroy(GameObject.FindGameObjectWithTag("ItemImage"));

        //Will set the current button pressed in the LevelEditorManager.cs to the current ID
        editor.CurrentButtonPressed = ID;
    }
}
