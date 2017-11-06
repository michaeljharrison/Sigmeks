using UnityEngine;
public class Enums : ScriptableObject
{
    public enum DebugLevelEnum
    {
        NONE,
        MAJOR,
        MODERATE,
        MINOR,
        ALL
    }

    public enum MapTileEnum
    {
        BLANK,
        BUILDING
    }
}