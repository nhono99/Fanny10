using UnityEngine;
using System.Collections;

public class GearModel{

	public float cableSpeed;
	public float cablePullSpeed;
	public float cableMaxLength;

	public GearModel(float cableSpeed, float cablePullSpeed, float cableMaxLength){
		this.cableSpeed = cableSpeed;
		this.cablePullSpeed = cablePullSpeed;
		this.cableMaxLength = cableMaxLength;
	}
}
