using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    [SerializeField] private Texture2D cursorOnClickUp;
    [SerializeField] private Texture2D cursorOnClickDown;

    private Vector2 cursorHotSpot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursorHotSpot = new Vector2(cursorOnClickDown.width / 2, cursorOnClickDown.height / 2);
            Cursor.SetCursor(cursorOnClickDown, cursorHotSpot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorHotSpot = new Vector2(cursorOnClickUp.width / 2, cursorOnClickUp.height / 2);
            Cursor.SetCursor(cursorOnClickUp, cursorHotSpot, CursorMode.Auto);
        }

        
    }

}
