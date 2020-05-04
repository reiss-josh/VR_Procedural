using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xyzPerlin : MonoBehaviour
{
    public float threshold = 0.5f;
    public Vector3Int xyzLims;
    public Vector3Int xyzMins;
    private Vector3Int xyzRange;
    private GameObject[] cubeHolder;

    // Start is called before the first frame update
    void Start()
    {
        xyzRange = new Vector3Int(xyzLims.x - xyzMins.x, xyzLims.y - xyzMins.y, xyzLims.z - xyzMins.z);
        cubeHolder = new GameObject[xyzRange.x * xyzRange.y * xyzRange.z];
        int currInd = 0;
        for (float k = xyzMins.z; k < xyzLims.z; k++)
        {
            for (float j = xyzMins.y; j < xyzLims.y; j++)
            {
                for (float i = xyzMins.x; i < xyzLims.x; i++)
                {

                    GameObject freshCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cubeHolder[currInd] = freshCube;
                    freshCube.transform.SetParent(transform);
                    freshCube.transform.position = new Vector3(i, j, k);
                    currInd++;
                    float w = PerlinNoise3D(i/10, j/10, k/10);
                    Debug.Log(i + ", " + j + ", " + k + ", " + w);
                    if (w > threshold)
                    {
                        freshCube.GetComponent<Renderer>().material.color = Color.black;
                    }
                    else
                    {
                        freshCube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    }
                }
            }
        }
    }


    public static float PerlinNoise3D(float x, float y, float z) //https://answers.unity.com/questions/938178/3d-perlin-noise.html
    {
        y += 1;
        z += 2;
        float xy = _perlin3DFixed(x, y);
        float xz = _perlin3DFixed(x, z);
        float yz = _perlin3DFixed(y, z);
        float yx = _perlin3DFixed(y, x);
        float zx = _perlin3DFixed(z, x);
        float zy = _perlin3DFixed(z, y);
        return xy * xz * yz * yx * zx * zy;
    }
    static float _perlin3DFixed(float a, float b)
    {
        return Mathf.Sin(Mathf.PI * Mathf.PerlinNoise(a, b));
    }
}