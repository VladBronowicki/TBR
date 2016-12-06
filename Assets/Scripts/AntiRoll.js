// AntiRoll.js
//private var GC : GameController;
//private var EC : EnvironmentController;
private var doScript=false; //if this is false, quit.

var WheelLeft : Transform;
var WheelRight : Transform;
var AntiRoll = 25000.0;

private var WheelL : WheelCollider;
private var WheelR : WheelCollider;
private var doSetup=true;

function Init(){
	doSetup=false;
	var obj : GameObject;
	//obj=GameObject.Find("GameController");
	//if(!obj) return;
	//GC=obj.GetComponent("GameController");
	//if(!GC) return;
	//obj=GameObject.Find("EnvironmentController");
	//if(!obj) return;
	//EC=obj.GetComponent("EnvironmentController");
	//if(!EC) return;
	
	if(WheelLeft==null || WheelRight==null)return;
	var ws=WheelLeft.gameObject.GetComponent("WheelController");
	if(ws==null)return;
	ws.Start();
	WheelL=ws.col;
	ws=WheelRight.gameObject.GetComponent("WheelController");
	if(ws==null)return;
	ws.Start();
	WheelR=ws.col;
	
	isSetup=true;
	doScript=true;
}

function FixedUpdate ()
    {
	if(doSetup) Init();
	if(!doScript) return;
    var hit : WheelHit;
    var travelL = 1.0;
    var travelR = 1.0;
	
    var groundedL = WheelL.GetGroundHit(hit);
    if (groundedL)
        travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

    var groundedR = WheelR.GetGroundHit(hit);
    if (groundedR)
        travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

    var antiRollForce = (travelL - travelR) * AntiRoll;

    if (groundedL)
        rigidbody.AddForceAtPosition(WheelL.transform.up * -antiRollForce,
               WheelL.transform.position);	
    if (groundedR)
        rigidbody.AddForceAtPosition(WheelR.transform.up * antiRollForce,
               WheelR.transform.position);	
    }