using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    Restaurant,
    Shop,
    Bar
}

public enum BuildingLevel
{
    Level_1,
    Level_2,
    Level_3
}

public class BuildingInformations : MonoBehaviour
{
    public string _name;
    public BuildingType _type;
    public int _rent;
    public BuildingLevel _level;
}
