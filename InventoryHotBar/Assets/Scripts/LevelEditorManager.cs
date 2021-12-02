using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelEditorManager : MonoBehaviour
{
    public ItemController[] InvetoryButtons;
    public GameObject[] ItemPrefabs;
    public GameObject[] ItemImage;
    public int CurrentButtonPressed; //Item ID of pressed button
    private TextMeshProUGUI debugScreenText;

    private void Start()
    {
        debugScreenText = GameObject.FindGameObjectWithTag("DebugTextOnScreen").GetComponent<TextMeshProUGUI>();
        debugScreenText.text = "";
    }

    private void Update()
    {
        //find out where the mouse in on the screen
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 150.0f);
        //screenPosition.z = Camera.main.nearClipPlane;
        //Find the mouse position relative to the world
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition) ;


        //When GetMouseButtonDown is  0 it's left click and 1 is right click
        if (Input.GetMouseButtonDown(0) && InvetoryButtons[CurrentButtonPressed].clicked)
        {
            //Add new object to the screen where the mouse is
            Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(worldPosition.x, worldPosition.y,1), Quaternion.identity);
            Debug.Log("screenPosition.x:" + screenPosition.x);
            Debug.Log("screenPosition.y:" + screenPosition.y);
            Debug.Log("screenPosition.z:" + screenPosition.z);
            Debug.Log("World Position :" + worldPosition);
            InvetoryButtons[CurrentButtonPressed].clicked = false;
        } 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 150f);
            Vector3 touchCords = Camera.main.ScreenToWorldPoint(touchPosition);
            //Add new object to the screen where the mouse is
            Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(touchCords.x, touchCords.y, 1), Quaternion.identity);

            debugScreenText.text = ("Touch Position" + touch.position +  "\n Touch Position.x:" + touch.position.x + "\n Touch Position.y:" + touch.position.y);
            InvetoryButtons[CurrentButtonPressed].clicked = false;
        }
    }

}
