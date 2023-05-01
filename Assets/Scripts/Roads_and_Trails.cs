using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Roads_and_Trails : MonoBehaviour
{
    private UnityEngine.Vector3 _dragOffset;
    private Camera _cam;
    public GameObject roadNavM;
    public GameObject trailNavM;
    public Tilemap tilemap;
    public TileBase road;
    public TileBase trail;
    private UnityEngine.Vector3 worldPosition;
    private Vector3Int dummy;  
    public int money = 250;
    public bool spac = false;
    void Awake() 
    {
        _cam = Camera.main;
    }




    // Use this for initialization
    void Update () 
    {
                                   // www.gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/#screen_to_world_3d
    float distance;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitData;
    if (Input.GetKeyDown("space")) {spac = !spac;}
    if(Physics.Raycast(ray, out hitData, 1000)) {
        worldPosition = hitData.point;
        print(worldPosition); }
    if((Input.GetMouseButtonDown(0) && !spac) && (money > 0)) {
        if (hitData.transform.gameObject != null && hitData.transform.tag == "tralfamadorians")
        {   GameObject.Destroy(hitData.transform.gameObject); }
        dummy = Intizer(worldPosition);
        tilemap.SetTile(dummy, road);   
        Instantiate(trailNavM, GridAligner(worldPosition), UnityEngine.Quaternion.Euler(0,90,0));
        money--; }
    if((Input.GetMouseButtonDown(0) &&  spac) && (money > 0)) {
        if (hitData.transform.gameObject != null && hitData.transform.tag == "tralfamadorians")
        {   GameObject.Destroy(hitData.transform.gameObject); }
        dummy = Intizer(worldPosition);
        tilemap.SetTile(dummy, trail); 
        Instantiate(roadNavM,   GridAligner(worldPosition), UnityEngine.Quaternion.Euler(0,90,0));
        money--; }        }
    
    void OnMouseDrag() 
    {
        transform.position = GetMousePos() + _dragOffset;
    }

    UnityEngine.Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    UnityEngine.Vector3 GridAligner(UnityEngine.Vector3 pos) {
        float mxmin =  -33.3f;
        float mxmax =  36.54f;
        float mymin =  -26.7f;
        float mymax =  18.91f;
        float xmin  = -33.21f;
        float xmax  =  34.15f;
        float ymin  =  -26.6f;
        float ymax  =  18.85f;
        float yi    =    5.5f;
        float xi    = (pos.x * ((mxmax-mxmin)/(xmax-xmin))); 
        float zi    = (pos.z * ((mymax-mymin)/(ymax-ymin))); 
        return (new UnityEngine.Vector3(xi,yi,zi));
    }        


    Vector3Int Intizer(UnityEngine.Vector3 pos) {
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
        int xi = (int)Math.Round(pos.x * 136f/67.36f); 
        int yi = (int)Math.Round(pos.z *  92f/45.45f); 
        int zi = 1; 
        return (new Vector3Int (xi,yi-1,zi));
    }
}

//     Vector3Int GridAligner(Vector3 mPos) {
//         float xmax   =  34.19f;
//         float xmin   = -33.27f;
//         float ymax   = -26.75f;
//         float ymin   = -18.18f;
        
//         float  gxmax =     68f;
//         float  gxmin =    -67f;
//         float  gymax =     37f;
//         float  gymin =    -54f;
