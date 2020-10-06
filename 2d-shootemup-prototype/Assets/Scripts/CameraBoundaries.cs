using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    /**
     * Code created by Press Start, a great GameDev Youtube Channel.
     * Link of the video: https://www.youtube.com/watch?v=ailbszpt_AI
     */

    #region Components
    [SerializeField]
    private Camera MainCamera;
    #endregion

    #region Variables
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    [SerializeField]
    private bool isOrthographic = true;
    #endregion

    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isOrthographic)
        {
            CalculateBoundariesOrthographic();
        }
        else
        {
            CalculateBoundariesPerspective();
        }
    }

    private void CalculateBoundariesPerspective()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        transform.position = viewPos;
    }

    private void CalculateBoundariesOrthographic()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
