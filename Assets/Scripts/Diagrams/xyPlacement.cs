using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xyPlacement : MonoBehaviour
{
    public Vector2Int xyLims;
    public Vector2Int xyMins;
    private Vector2Int xyRange;
    private GameObject[] cubeHolder;

    // Start is called before the first frame update
    void Start()
    {
        xyRange = new Vector2Int (xyLims.x - xyMins.x, xyLims.y - xyMins.y);
        cubeHolder = new GameObject[xyRange.x * xyRange.y];
        int currInd = 0;
        for(int j = xyMins.y; j < xyLims.y; j++)
        {
            for(int i = xyMins.x; i < xyLims.x; i++)
            {
                GameObject freshCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeHolder[currInd] = freshCube;
                freshCube.transform.SetParent(transform);
                freshCube.transform.position = new Vector2 ( i, j);
                currInd++;
            }
        }

        for(int i = 0; i < cubeHolder.Length; i++)
        {
            var coords = cubeHolder[i].transform.position;
            var x = coords.x;
            var y = coords.y;
            if(x < -25 || x > 25 || y < -25 || y > 25){
                cubeHolder[i].GetComponent<Renderer>().material.color = Color.black;
            } else {
                var bw = (Random.value > 0.5f);
                if(!bw)
                    cubeHolder[i].GetComponent<Renderer>().material.color = Color.black;
                else
                    cubeHolder[i].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
