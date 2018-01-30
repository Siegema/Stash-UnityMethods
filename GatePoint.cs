using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Teleporter;
using teleporter = Teleporter.TeleporterHelper;

/// <summary>
/// Gate point.
/// Warp gates Teleport to it's pair 
/// id == same id
/// 0 Random warp
/// </summary>

[AddComponentMenu("GatePoint")]
public class GatePoint : MonoBehaviour {

	Transform pos;

	public int id;
	public List<Object> objType = new List<Object>();

	// Use this for initialization
	void Start () {
		pos = this.gameObject.transform;
		teleporter.Instance.warpPoints.Add(this);
	}
	
	void OnCollisionEnter(Collision other){
		if (objType != null) {
			foreach (var obj in objType) {
				if (other.gameObject.GetComponent (obj.name) != null) {
					if (this.id == 0) {
						teleporter.Instance.warpRandom (other.gameObject);
						break;
					}
					teleporter.Instance.warpTo (other.gameObject, (new WarpPoint (this.id, this.pos)));
					break;
				}  
			}
		}
	}

	public Transform getPos(){
		return pos;
	}
}
