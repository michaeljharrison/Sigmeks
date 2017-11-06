using UnityEngine;
public class MapTile : ScriptableObject
{
    private Enums.MapTileEnum type;

    public MapTile(Enums.MapTileEnum type)
    {
        this.type = type;
    }

    public string toString()
    {
        switch (this.type)
        {
            case Enums.MapTileEnum.BLANK:
                return "    ";
            case Enums.MapTileEnum.BUILDING:
                return "BLD1";
            default:
                Debug.LogError("Undefined MapTile Type.");
                return "????";
        }
    }

    public Enums.MapTileEnum getTileType()
    {
        return this.type;
    }
}
