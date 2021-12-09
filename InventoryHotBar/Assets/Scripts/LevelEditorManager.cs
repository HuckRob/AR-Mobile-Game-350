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
    private GameObject[] currentPlayerPrefab;

    private void Start()
    {
        debugScreenText = GameObject.FindGameObjectWithTag("DebugTextOnScreen").GetComponent<TextMeshProUGUI>();
        debugScreenText.text = "";
    }

    private void Update()
    {
        //find out where the mouse in on the screen
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100.0f);
        //screenPosition.z = Camera.main.nearClipPlane;
        //Find the mouse position relative to the world
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition) ;


        //When GetMouseButtonDown is  0 it's left click and 1 is right click
        if (Input.GetMouseButtonDown(0) && InvetoryButtons[CurrentButtonPressed].clicked)
        {
            if (CurrentButtonPressed != 0) { 
                //Add new object to the screen where the mouse is
                Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(worldPosition.x, worldPosition.y, (worldPosition.z - 10)), Quaternion.identity);
                Debug.Log("screenPosition.x:" + screenPosition.x);
                Debug.Log("screenPosition.y:" + screenPosition.y);
                Debug.Log("screenPosition.z:" + screenPosition.z);
                Debug.Log("World Position :" + worldPosition);
                InvetoryButtons[CurrentButtonPressed].clicked = false;
            }
            else if(currentPlayerPrefab.Length == 0)
            {
                currentPlayerPrefab[0].push(ItemPrefabs[CurrentButtonPressed]);
                Instantiate(currentPlayerPrefab[0], new Vector3(worldPosition.x, worldPosition.y, (worldPosition.z - 10)), Quaternion.identity);
            }else if(currentPlayerPrefab[0] != null)
            {
                Destroy(currentPlayerPrefab[0]);
                currentPlayerPrefab[0] = ItemPrefabs[CurrentButtonPressed];
                Instantiate(currentPlayerPrefab[0], new Vector3(worldPosition.x, worldPosition.y, (worldPosition.z - 10)), Quaternion.identity);
            }
        } 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && InvetoryButtons[CurrentButtonPressed].clicked)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 100f);
            Vector3 touchCords = Camera.main.ScreenToWorldPoint(touchPosition);
            //Add new object to the screen where the mouse is
            Instantiate(ItemPrefabs[CurrentButtonPressed], new Vector3(touchCords.x, touchCords.y, (worldPosition.z-10)), Quaternion.identity);

            //debugScreenText.text = ("Touch Position" + touch.position +  "\n Touch Position.x:" + touch.position.x + "\n Touch Position.y:" + touch.position.y);
            InvetoryButtons[CurrentButtonPressed].clicked = false;
        }
    }

}
