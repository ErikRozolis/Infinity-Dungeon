using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseController {

    public static Vector2 GetMousePosition()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }
}
