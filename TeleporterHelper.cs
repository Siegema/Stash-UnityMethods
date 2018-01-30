using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

/// <summary>
/// Teleporter helper.
/// When too lazy to write simple teleporting code
/// Pair each gateway by matching Ids.
/// </summary>
namespace Teleporter{
	public class TeleporterHelper{

		private static TeleporterHelper instance = null;
		private static readonly object padlock = new object();

		public static TeleporterHelper Instance{
			get{ 
				lock (padlock) {
					if (instance == null) {
						instance = new TeleporterHelper ();
					}
					return instance;
				}
			}
		}

		public List<GatePoint> warpPoints = new List<GatePoint>();

		public void warpTo(GameObject obj, WarpPoint point){
			foreach (var pt in warpPoints) {
				int nextId = pt.id;
				Vector3 nextPos = pt.getPos().position;
				if (point.id == nextId && point.pos.position != nextPos) {
					nextPos.z += 2f;
					obj.transform.position = nextPos;
					break;
				}
			}
		}

		public void warpRandom(GameObject obj){
			int randInt = Random.Range (1, warpPoints.Count);
			GatePoint pt = warpPoints [randInt]; 
			Vector3 nextPos = pt.getPos ().position;
			nextPos.z += 2f;
			obj.transform.position = nextPos;
		}
	}

	[System.Serializable]
	public struct WarpPoint{
		public int id;
		public Transform pos;
		public WarpPoint (int ID, Transform Pos)
		{
			this.id = ID;
			this.pos = Pos;
		}
	}
}