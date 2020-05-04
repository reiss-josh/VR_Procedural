using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class Chunk : MonoBehaviour
{
	public MeshCollider chunkMeshCollider;
	public Mesh chunkMesh;
	private VoxelMap parentMap;

	public int cX, cY, cZ, ciD;

	//this function takes some resolution (how many cubes per chunk), and some size (the size of the cubes)
	public void Initialize(int x, int y, int z, int i, VoxelMap m)
	{
		cX = x;
		cY = y;
		cZ = z;
		ciD = i;
		parentMap = m;
		chunkMeshCollider = GetComponent<MeshCollider>();
		chunkMeshCollider.sharedMesh = null;

		GetComponent<MeshFilter>().mesh = chunkMesh = new Mesh();
		chunkMesh.name = "VoxelGrid Mesh";
	}
	
	public void ChunkUpdate()
	{
		parentMap.Triangulate(ciD);
	}
}