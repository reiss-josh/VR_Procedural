using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xyPerlin : MonoBehaviour
{
    public Vector2Int xyLims;
    public Vector2Int xyMins;
    public float threshold;
    private Vector2Int xyRange;
    private GameObject[] cubeHolder;

    // Start is called before the first frame update
    void Start()
    {
        xyRange = new Vector2Int(xyLims.x - xyMins.x, xyLims.y - xyMins.y);
        cubeHolder = new GameObject[xyRange.x * xyRange.y];
        int currInd = 0;
        for (int j = xyMins.y; j < xyLims.y; j++)
        {
            for (int i = xyMins.x; i < xyLims.x; i++)
            {
                GameObject freshCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeHolder[currInd] = freshCube;
                freshCube.transform.SetParent(transform);
                freshCube.transform.position = new Vector2(i, j);
                currInd++;
            }
        }

        for (int i = 0; i < cubeHolder.Length; i++)
        {
            var coords = cubeHolder[i].transform.position;
            var x = coords.x;
            var y = coords.y;
            var w = Mathf.PerlinNoise(x/5, y/5);
            Debug.Log(w);
            if (w > threshold)
                cubeHolder[i].GetComponent<Renderer>().material.color = Color.black;
            else
                cubeHolder[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }
}