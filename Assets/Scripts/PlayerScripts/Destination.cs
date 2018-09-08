using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Idle = 0, Up = 1, Right = 2, Down = 3, Left = 4
}

public class Destination{
    public Vector2 Coordinates;
    public int Speed;

    public static Direction Directify(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            //left or right
            if (dir.x >= 0)
                return Direction.Right;
            else
                return Direction.Left;
        }
        else
        {
            //up or down
            if (dir.y >= 0)
                return Direction.Up;
            else
                return Direction.Down;
        }
    }
}
