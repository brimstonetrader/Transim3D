using System.Xml.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// This is a refrence to Drag and Drop in Unity - 2021 Tutorial 
// https://www.youtube.com/watch?v=Tv82HIvKcZQ

public class Roads_and_Trails : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera  _cam;
    public Tilemap  tilemap;
    public Tilemap  expTilemap; 
    public TileBase road;
    private bool lining = false;
    private Vector3 worldPosition;

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
        {worldPosition = hitData.point;}
    if(Input.GetMouseButtonDown(0)) 
        {if (!lining) {Fingers(worldPosition);}}
    }
   
    // just so you know this could work
    // if(Input.GetMouseButtonDown(1))
    //     {
    //     print(GridAligner(GetMousePos()));
    //     tilemap.SetTile(GridAligner(worldPosition), trail);   
    //     }    

    void Fingers(Vector3 forever) {
      //  lining = true;
        var p = GridAligner(forever);
        tilemap.SetTile(p, road);   
      //  StartCoroutine(Liner(p));
    }

    IEnumerator Liner(Vector3Int clickPoint) 
    {   
        while (!Input.GetMouseButtonDown(0)) {
            var mousePos =   GridAligner(GetMousePos());
            var delx     = Mathf.Abs(mousePos.x - clickPoint.x);
            var dely     = Mathf.Abs(mousePos.y - clickPoint.y);
            if     (dely > delx) {
                tilemap.SetTile(new Vector3Int(clickPoint.x, mousePos.y, 1), road);}
            if     (delx > dely) {
                tilemap.SetTile(new Vector3Int(mousePos.x, clickPoint.y, 1), road);}}
        lining = false;
        yield return new WaitForSeconds(0.02f);
    }
    
    void OnMouseDrag() 
    {
        transform.position = GetMousePos() + _dragOffset;
    }

    Vector3 GetMousePos()
    {
        return _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector3Int GridAligner(Vector3 mPos) {
        float xmax   =  34.19f;
        float xmin   = -33.27f;
        float ymax   = -26.75f;
        float ymin   = -18.18f;
        
        float  gxmax =     68f;
        float  gxmin =    -67f;
        float  gymax =     37f;
        float  gymin =    -54f;

        float xprop = (mPos.x - xmin) / (xmax - xmin);
        float yprop = (mPos.z - ymin) / (ymax - ymin);

        int xi = (int)Math.Round((xprop * (gxmax-gxmin)) + gxmin); 
        int yi = (int)Math.Round((yprop * (gymax-gymin)) + gymin); 
        int zi = 1; 

        var ans = new Vector3Int (xi,yi,zi);
        print(mPos); //print(ans);
        return (ans);
     }
}


// using System.Xml.Schema;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;

// // This is a refrence to Drag and Drop in Unity - 2021 Tutorial 
// // https://www.youtube.com/watch?v=Tv82HIvKcZQ

// public class Roads_and_Trails : MonoBehaviour
// {
//     private Vector3 _dragOffset;
//     private Camera  _cam;
//     public Tilemap  tilemap;
//     public Tilemap  expTilemap; 
//     public TileBase road;
//     private bool lining = false;
//     private Vector3 worldPosition;

//     void Awake() 
//     {
//         _cam = Camera.main;
//     }

//     void Update()
//     {                        // www.gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/#screen_to_world_3d
//     float distance;
//     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//     RaycastHit hitData;
//     if(Physics.Raycast(ray, out hitData, 1000))
//         {worldPosition = hitData.point;}
//     if(Input.GetMouseButtonDown(0)) 
//         {if (!lining) {Fingers(worldPosition);}}
//     }
   
//     // just so you know this could work
//     // if(Input.GetMouseButtonDown(1))
//     //     {
//     //     print(GridAligner(GetMousePos()));
//     //     tilemap.SetTile(GridAligner(worldPosition), trail);   
//     //     }    

//     void Fingers(Vector3 forever) {
//       //  lining = true;
//         var p = GridAligner(forever);
//         tilemap.SetTile(p, road);   
//       //  StartCoroutine(Liner(p));
//     }

//     IEnumerator Liner(Vector3Int clickPoint) 
//     {   
//         while (!Input.GetMouseButtonDown(0)) {
//             var mousePos =   GridAligner(GetMousePos());
//             var delx     = Mathf.Abs(mousePos.x - clickPoint.x);
//             var dely     = Mathf.Abs(mousePos.y - clickPoint.y);
//             if (dely > delx) {
//                 tilemap.SetTile(new Vector3Int(clickPoint.x, mousePos.y, 1), road);}
//             if (delx > dely) {
//                 tilemap.SetTile(new Vector3Int(mousePos.x, clickPoint.y, 1), road);}}
//         lining = false;
//         yield return new WaitForSeconds(0.02f);
//     }
    
//     void OnMouseDrag() 
//     {
//         transform.position = GetMousePos() + _dragOffset;
//     }

//     Vector3 GetMousePos()
//     {
//         return _cam.ScreenToWorldPoint(Input.mousePosition);
//     }

//     Vector3Int GridAligner(Vector3 mPos) {
//         float xmax   =  34.19f;
//         float xmin   = -33.27f;
//         float ymax   = -26.75f;
//         float ymin   = -18.18f;
        
//         float  gxmax =     68f;
//         float  gxmin =    -67f;
//         float  gymax =     37f;
//         float  gymin =    -54f;

//         float xprop = (mPos.x - xmin) / (xmax - xmin);
//         float yprop = (mPos.z - ymin) / (ymax - ymin);

//         int xi = (int)Math.Round((xprop * (gxmax-gxmin)) + gxmin); 
//         int yi = (int)Math.Round((yprop * (gymax-gymin)) + gymin); 
//         int zi = 1; 

//         var ans = new Vector3Int (xi,yi,zi);
//         print(mPos); //print(ans);
//         return (ans);
//      }
// }

// // using System.Numerics;
// // using System.Diagnostics;
// // using System;
// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.Tilemaps;

// // // This is a refrence to Drag and Drop in Unity - 2021 Tutorial 
// // // https://www.youtube.com/watch?v=Tv82HIvKcZQ

// // public class Roads_and_Trails : MonoBehaviour
// // {
// //     private UnityEngine.Vector3 _dragOffset;
// //     private Camera _cam;
// //     public Tilemap tilemap;
// //     public TileBase road;
// //     public TileBase trail;

// //     void Awake() 
// //     {
// //         _cam = Camera.main;
// //     }

// //     void Update()
// //     {
// //     if(Input.GetMouseButtonDown(0))
// //         {}
// //     if(Input.GetMouseButtonDown(1))
// //         {
// //         Vector3Int stwp = GridAligner(GetMousePos());
// //         tilemap.SetTile(stwp, trail);   
// //         tilemap.SetTile(new Vector3Int (stwp.x - 1, stwp.y, 1), trail);   
// //         tilemap.SetTile(new Vector3Int (stwp.x, stwp.y - 1, 1), trail);   
// //         tilemap.SetTile(new Vector3Int (stwp.x - 1, stwp.y - 1, 1), trail);   
// //         }
// //     }
    
// //     UnityEngine.Vector3 GetMousePos()
// //     {
// //         var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
// //         mousePos.z = 1;
// //         return mousePos;
// //     }

// //     Vector3Int GridAligner(UnityEngine.Vector3 pos) {
// //         int xmin  = -50;
// //         int xmax  = 15;
// //         int ymin  = -30;
// //         int ymax  = 15;
// //         int gxmin  = -67;
// //         int gxmax  = 68;
// //         int gymin  = -54;
// //         int gymax  = 37;
// //         int xi = (int)Math.Round(((pos.x - xmin / (xmax-xmin)) * (gxmax-gxmin)) + gxmin); 
// //         int yi = (int)Math.Round(((pos.y - ymin / (ymax-ymin)) * (gymax-gymin)) + gymin); 
// //         int zi = (int)Math.Round(pos.z); 
// //         return (new Vector3Int (xi,yi,zi));
// //     }
// // }






// // // using System.Numerics;
// // // using System.Diagnostics;
// // // using System;
// // // using System.Collections;
// // // using System.Collections.Generic;
// // // using UnityEngine;
// // // using UnityEngine.Tilemaps;

// // // // This is a refrence to Drag and Drop in Unity - 2021 Tutorial 
// // // // https://www.youtube.com/watch?v=Tv82HIvKcZQ

// // // public class Roads_and_Trails : MonoBehaviour
// // // {
// // //     private UnityEngine.Vector3 _dragOffset;
// // //     private Camera _cam;
// // //     public Tilemap tilemap;
// // //     public TileBase road;
// // //     public TileBase trail;

// // //     void Awake() 
// // //     {
// // //         _cam = Camera.main;
// // //     }

// // //     void Update()
// // //     {
// // //     if(Input.GetMouseButtonDown(0))
// // //         {}
// // //     if(Input.GetMouseButtonDown(1))
// // //         {
// // //         Vector3Int stwp = GridAligner(GetMousePos());
// // //         tilemap.SetTile(stwp, trail);   
// // //         tilemap.SetTile(new Vector3Int (stwp.x - 1, stwp.y, 1), trail);   
// // //         tilemap.SetTile(new Vector3Int (stwp.x, stwp.y - 1, 1), trail);   
// // //         tilemap.SetTile(new Vector3Int (stwp.x - 1, stwp.y - 1, 1), trail);   
// // //         }
// // //     }
    
// // //     UnityEngine.Vector3 GetMousePos()
// // //     {
// // //         var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
// // //         mousePos.z = 1;
// // //         return mousePos;
// // //     }

// // //     Vector3Int GridAligner(UnityEngine.Vector3 pos) {
// // //         int xmin  = -50;
// // //         int xmax  = 15;
// // //         int ymin  = -30;
// // //         int ymax  = 15;
// // //         int gxmin  = -67;
// // //         int gxmax  = 68;
// // //         int gymin  = -54;
// // //         int gymax  = 37;
// // //         int xi = (int)Math.Round(((pos.x - xmin / (xmax-xmin)) * (gxmax-gxmin)) + gxmin); 
// // //         int yi = (int)Math.Round(((pos.y - ymin / (ymax-ymin)) * (gymax-gymin)) + gymin); 
// // //         int zi = (int)Math.Round(pos.z); 
// // //         return (new Vector3Int (xi,yi,zi));
// // //     }
// // // }


