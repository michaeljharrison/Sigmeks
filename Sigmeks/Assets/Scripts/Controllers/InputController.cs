using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    private Ray mouseRay;
    private RaycastHit mouseRayHit;
    private string currentTileHovered;
    private GameMaster gameMaster;
    // Use this for initialization
    void Start()
    {
        currentTileHovered = null;
        gameMaster = gameObject.GetComponent(typeof(GameMaster)) as GameMaster;
    }

    // Update is called once per frame
    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out mouseRayHit))
        {
            if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MINOR)
            {
                Debug.Log("Mouse hit tile: " + mouseRayHit.collider.name);
            }
            currentTileHovered = mouseRayHit.collider.name;
            gameMaster.setCurrentTileHovered(this.currentTileHovered);

        }
    }
}
