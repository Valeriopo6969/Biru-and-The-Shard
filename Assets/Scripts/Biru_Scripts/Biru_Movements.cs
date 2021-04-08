using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider))]
public class Biru_Movements : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rb;

    [Header("DebugVariables")]
    public float moveSpeed = 5f;

    [Header("GUIVariables")]
    public Vector2 GUIDimensions=new Vector2(200,150);   //x=Rect.width, y=Rect.height for the GUILabel rect
    public Vector2 GUIPosition= new Vector2(20,20);
    public int GUIFontSize;
    public Color GUIColor;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter(GetInput());
    }

    private Vector2 GetInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }

    private void MoveCharacter(Vector2 input)
    {
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);
    }

    private void OnGUI()
    {
        GUI.color = GUIColor;
        GUI.skin.label.fontSize = GUIFontSize;
        GUI.Label(new Rect(GUIPosition.x, GUIPosition.y, GUIDimensions.x, GUIDimensions.y), $"rb.velocity = {rb.velocity}");
    }
}
