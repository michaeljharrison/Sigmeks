using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private Map currentMap;
    // Use this for initialization
    void Start()
    {
        this.currentMap = FetchMap("???");
        GenerateMap();
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
    void GenerateMap()
    {
        if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MODERATE)
        {
            Debug.Log(this.currentMap.toString());
        }

        // Read the map and create any needed objects.
        for (var counterY = 0; counterY < this.currentMap.Height; counterY++)
        {
            for (var counterX = 0; counterX < this.currentMap.Width; counterX++)
            {
                if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MINOR)
                {
                    Debug.Log("Generating Tile [" + counterX + "," + counterY + "] - " + this.currentMap.getTile(counterX, counterY));
                }
                // @TODO Actually generate Tile
                GenerateTile(this.currentMap.getTile(counterX, counterY));
            }
        }

    }

    void GenerateTile(MapTile tile)
    {
        // Render a new prefab at the designated location based on the tile.
        Instantiate(BlankTile)

    }

    // Update is called once per frame
    void Update()
    {

    }
}
