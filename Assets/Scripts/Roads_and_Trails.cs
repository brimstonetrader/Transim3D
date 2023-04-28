using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Roads_and_Trails : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    public Tilemap tilemap;
    public TileBase road;
    public TileBase trail;
    private Vector3 worldPosition;
    private Vector3Int dummy;
    public bool lineBool = false;

    void Awake() 
    {
        _cam = Camera.main;
    }

    void Update()
    {                        // www.gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/#screen_to_world_3d
    float distance;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitData;
    if(Physics.Raycast(ray, out hitData, 1000))
    {
        worldPosition = hitData.point;
    }
    if(Input.GetMouseButtonDown(0) && !lineBool)
        {
        print(Intizer(GetMousePos()));
        tilemap.SetTile(Intizer(worldPosition), road);   
        lineBool = true;
        dummy = Intizer(worldPosition);
        }
    //if((Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(1)) && lineBool)
        //{
        //dummz = Intizer(GetMousePos());
        // if (dummz != dummy) {if (Mathf.Abs(dummz.x - dummy.x) > Mathf.Abs(dummz.y - dummy.y))};
        //for (int i = 0; i < Mathf.Abs(dummz.x - dummy.x); i++) 
        //{
        //if (dummz.x - dummy.x > 0) tilemap.SetTile(new Vector3Int (i +dummyx), trail);
        //}
        //tilemap.SetTile(Intizer(worldPosition), trail);
        //lineBool = false;
        //}
    
    }    



    void OnMouseDrag() 
    {
        transform.position = GetMousePos() + _dragOffset;
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    Vector3Int Intizer(Vector3 floatnasty) {
//     Vector3Int GridAligner(UnityEngine.Vector3 pos) {
//         int xmin  = -50;
//         int xmax  = 15;
//         int ymin  = -30;
//         int ymax  = 15;
//         int gxmin  = -67;
//         int gxmax  = 68;
//         int gymin  = -54;
//         int gymax  = 37;
//         int xi = (int)Math.Round(((pos.x - xmin / (xmax-xmin)) * (gxmax-gxmin)) + gxmin); 
//         int yi = (int)Math.Round(((pos.y - ymin / (ymax-ymin)) * (gymax-gymin)) + gymin); 
//         int zi = (int)Math.Round(pos.z); 
//         return (new Vector3Int (xi,yi,zi));
//     }
        int xi = (int)Math.Round(floatnasty.x * 136/65); 
        int yi = (int)Math.Round(floatnasty.z * 92/45); 
        int zi = 1; 
        return (new Vector3Int (xi,yi,zi));
    }
}

