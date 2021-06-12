using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    private static void DrawDiamond(Vector2 point, float radius, Color color) {
        Debug.DrawLine(point + Vector2.up * radius, point + Vector2.right * radius, color);
        Debug.DrawLine(point + Vector2.right * radius, point + Vector2.down * radius, color);
        Debug.DrawLine(point + Vector2.down * radius, point + Vector2.left * radius, color);
        Debug.DrawLine(point + Vector2.left * radius, point + Vector2.up * radius, color);
    }
}
