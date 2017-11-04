using UnityEngine;

public class Map : ScriptableObject
{

    #region Variables
    private MapTile[,] mapTiles;
    private int width;
    private int height;
    #endregion

    // Constructor
    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.mapTiles = new MapTile[width, height];
    }

    public string toString()
    {
        string outputString = "Map Overview: \n";
        // First print X axis:
        for (var counterX = 0; counterX < this.Width; counterX++)
        {
            outputString += "   " + counterX + " ";
        }
        outputString += "\n";

        for (var counterY = 0; counterY < this.Height; counterY++)
        {
            outputString += counterY + " ";
            for (var counterX = 0; counterX < this.Width; counterX++)
            {
                if (counterX == (this.Width - 1))
                {
                    outputString += "[" + this.mapTiles[counterX, counterY].toString() + "]";
                }
                else
                {
                    outputString += "[" + this.mapTiles[counterX, counterY].toString() + "] ";
                }
            }
            outputString += "\n";
        }
        return outputString;
    }

    #region Getters and Setters
    public void setTile(int x, int y, MapTile tile)
    {
        this.mapTiles[x, y] = tile;
    }

    public MapTile getTile(int x, int y)
    {
        return this.mapTiles[x, y];
    }

    public int Width
    {
        get { return this.width; }
        set { this.width = value; }
    }
    public int Height
    {
        get { return this.width; }
        set { this.width = value; }
    }
    #endregion
}
