using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction
{
    north = 1,
    east = 2,
    south = 3,
    west =4
}

[ExecuteInEditMode]
public class Tile : MonoBehaviour
{
    public Tile(direction CreatedFrom)
    {
        if(CreatedFrom == 0)
        {


            return;
        } 


    }

    SideNeighbour[] neighbour;


   









    public void CreateTile()
    {

    }

}

public class SideNeighbour
{
    enum direction
    {
        north,
        east,
        south,
        west
    }
    public bool ocuppied;
}

