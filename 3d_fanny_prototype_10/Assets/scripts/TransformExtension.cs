using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension{

	public static void LookAt2D(this Transform t, Vector3 target){
		float angle = Mathf.Atan2(target.y - t.position.y, target.x - t.position.x) * Mathf.Rad2Deg;
		t.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

}
