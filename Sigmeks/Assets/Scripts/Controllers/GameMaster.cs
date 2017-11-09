using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private GameObject blankTile;
    private GameObject buildingTile;
    private GameObject[,] tileArray;
    private Map currentMap;
    private TileLocation currentHoveredTile;

    // Use this for initialization
    void Start()
    {
        this.currentHoveredTile.x = -1;
        this.currentHoveredTile.y = -1;
        this.currentMap = FetchMap("default");
        LoadResources();
        GenerateMap();
    }

    private bool LoadResources()
    {
        this.blankTile = Resources.Load("Tiles/BlankTile", typeof(GameObject)) as GameObject;
        this.buildingTile = Resources.Load("Tiles/BuildingTile", typeof(GameObject)) as GameObject;
        return true;
    }
    private Map FetchMap(string mapName)
    {
        // Read Map Layout from File.
        string fullPath = "Assets/Resources/MapFiles/" + mapName + ".txt";
        StreamReader reader = new StreamReader(fullPath);
        string mapString = reader.ReadToEnd();
        reader.Close();
        if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MODERATE)
        {
            Debug.Log("Map String:\n" + mapString);
        }

        // Parse map string and create object.
        string[] rows = mapString.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        Map returnMap = new Map(rows.Length, rows.Length);

        // Fill map with tiles.
        for (var counterY = 0; counterY < returnMap.Height; counterY++)
        {
            string[] currentRow = rows[counterY].Split(new[] { "," }, StringSplitOptions.None);
            if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MINOR)
            {
                Debug.Log("Reading Row: " + string.Join(",", currentRow));
            }
            for (var counterX = 0; counterX < returnMap.Width; counterX++)
            {
                returnMap.setTile(counterX, counterY, new MapTile(toTileType(currentRow[counterX])));
            }
        }
        return returnMap;
    }
    // Use a map object to generate the Map into the scene.
    private void GenerateMap()
    {
        if (Constants.DEBUG_LEVEL >= Enums.DebugLevelEnum.MODERATE)
        {
            Debug.Log(this.currentMap.toString());
        }
        this.tileArray = new GameObject[this.currentMap.Width, this.currentMap.Height];
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
                GenerateTile(this.currentMap.getTile(counterX, counterY), counterX, counterY);
            }
        }

    }

    private void GenerateTile(MapTile tile, int x, int y)
    {
        // Render a new prefab at the designated location based on the tile.
        // @TODO -> Determine what tile to render first.
        GameObject tileType;
        switch (tile.getTileType())
        {
            case Enums.MapTileEnum.BLANK:
                tileType = blankTile;
                break;
            case Enums.MapTileEnum.BUILDING:
                tileType = buildingTile;
                break;
            default:
                Debug.LogError("Invalid Tile Type");
                tileType = blankTile;
                break;
        }
        Vector3 tilePos = new Vector3(x * Constants.TILE_WIDTH, 0, y * Constants.TILE_WIDTH);
        Quaternion tileRotation = new Quaternion(0, 0, 0, 0);

        GameObject newTile = Instantiate(tileType, tilePos, tileRotation) as GameObject;
        newTile.name = "tile_" + x + "_" + y;
        newTile.transform.parent = this.transform;
        tileArray[x, y] = newTile;
    }

    // Update is called once per frame
    void Update()
    {
        // Re-render the currently hovered tile.
        if (this.currentHoveredTile.x != -1 && this.currentHoveredTile.y != -1)
        {
            string tilePath = "GameMaster/tile_" + this.currentHoveredTile.x + "_" + this.currentHoveredTile.y + "/tile_base";
            GameObject tileToHighlight = GameObject.Find(tilePath);
        }
    }

    private Enums.MapTileEnum toTileType(string tileString)
    {
        switch (tileString)
        {
            case "    ":
                return Enums.MapTileEnum.BLANK;
            case "BLD1":
                return Enums.MapTileEnum.BUILDING;
            default:
                Debug.LogError("Unknown Title Type: " + tileString);
                return Enums.MapTileEnum.BLANK;
        }
    }

    public void setCurrentTileHovered(string tileName)
    {
        string[] tileNameArray = tileName.Split(new[] { "_" }, StringSplitOptions.None);
        this.currentHoveredTile.x = Int32.Parse(tileNameArray[1]);
        this.currentHoveredTile.y = Int32.Parse(tileNameArray[2]);
    }

    private struct TileLocation
    {
        public int x;
        public int y;
    }
}
