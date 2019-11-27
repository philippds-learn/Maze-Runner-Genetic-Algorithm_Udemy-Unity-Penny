using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaze : MonoBehaviour {

	public GameObject blockPrefab;
	int width = 40;
	int depth = 40;

	// Use this for initialization
	void Awake () {
		for(int w = 0; w < width; w++)
		{
			for(int d = 0; d < depth; d++)
			{
				if( w == 0 || d == 0)	//outside walls bottom and left
				{
					GameObject wall = Instantiate(blockPrefab, new Vector3(w + this.transform.position.x, this.transform.position.y, d + this.transform.position.z), Quaternion.identity);
                    wall.transform.SetParent(this.transform);
				}	
				else if( w < 3 && d < 3)
				{
					continue;
				}		
				else if(w == width-1 || d == depth-1) //outside walls top and right
				{
                    GameObject wall = Instantiate(blockPrefab, new Vector3(w + this.transform.position.x, this.transform.position.y,d + this.transform.position.z), Quaternion.identity);
                    wall.transform.SetParent(this.transform);
                }
				else if(Random.Range(0,5) < 1)
				{
                    GameObject wall = Instantiate(blockPrefab, new Vector3(w + this.transform.position.x, this.transform.position.y,d + this.transform.position.z), Quaternion.identity);
                    wall.transform.SetParent(this.transform);
                }
			}	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
