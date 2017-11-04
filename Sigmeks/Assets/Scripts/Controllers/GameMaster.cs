using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Map newMap = FetchMap("???");
        GenerateMap(newMap);
    }

    Map FetchMap(string mapName)
    {
        // Look at mapName, use that to create the map object.
        // @TODO Actually fetch a map.
        Map returnMap = new Map(4, 4);
        // Fill map with tiles.
        for (var counterY = 0; counterY < returnMap.Height; counterY++)
        {
            for (var counterX = 0; counterX < returnMap.Width; counterX++)
            {
                returnMap.setTile(counterX, counterY, new MapTile());
            }
        }
        return returnMap;
    }
    // Use a map object to generate the Map into the scene.
    void GenerateMap(Map map)
    {
        if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MODERATE)
        {
            Debug.Log(map.toString());
        }

        // Read the map and create any needed objects.
        for (var counterY = 0; counterY < map.Height; counterY++)
        {
            for (var counterX = 0; counterX < map.Width; counterX++)
            {
                if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MINOR)
                {
                    Debug.Log("Generating Tile [" + counterX + "," + counterY + "]");
                }
                // @TODO Actually generate Tile
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
