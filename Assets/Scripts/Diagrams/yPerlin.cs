using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yPerlin : MonoBehaviour
{
    public Vector2Int xyLims; //YLIM MUST BE AT LEAST 100
    public Vector2Int xyMins;
    public float threshold;
    private Vector2Int xyRange;
    private GameObject[] cubeHolder;
    private int divisor;

    int xyToIndex(int x, float y)
    {
        float fixedYf = y / divisor;
        int fixedY = (int)fixedYf;
        Debug.Log(fixedY);
        for(int i = 0; i < cubeHolder.Length; i++)
        {
            if (cubeHolder[i].transform.position.x == x && cubeHolder[i].transform.position.y == fixedY)
                return i;
        }
        return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(xyLims.y);
        divisor = 100 / xyLims.y;
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
            float x = coords.x;
            if (x >= 0)
            {
                var y = Mathf.PerlinNoise(x/100, 0.0f);
                Debug.Log(x + ", " + y);
                int ind = xyToIndex((int)x, (y*100)/divisor);
                cubeHolder[ind].GetComponent<Renderer>().material.color = Color.black;
            }
        }
    }
}
