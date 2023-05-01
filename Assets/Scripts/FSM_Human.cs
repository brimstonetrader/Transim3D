using System.Xml.Xsl;
using System.ComponentModel;
using System.Net.Cache;
using System.Net.WebSockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Given our analog clock, we will scale a day into six minutes. 
//Big ups to https://medium.com/c-sharp-progarmming/make-a-basic-fsm-in-unity-c-f7d9db965134

public class FSM_Human : MonoBehaviour
{
    public Rigidbody rigidbody;
    public SpriteRenderer spriteRenderer;
    public UnityEngine.AI.NavMeshAgent agent;
    public TimeClock clock;
    BaseState currentState;

    public float lerpduration = 5;
    public int timer = 0;
    public int days =  0;
    private int daylength = 360;
    public int c = 0;
    private int r;
    public string state = "Home";
    public UnityEngine.Vector3 homeLoc;
    public UnityEngine.Vector3 vibeLoc;
    public UnityEngine.Vector3 workLoc;
    bool worked = false;
    bool homed = false;
    bool vibed = false;
    int vtoh=100;
    int htow=200;
    int wtovorh=300;
    private UnityEngine.Vector3  loc1;
    private UnityEngine.Vector3  loc2;
    private UnityEngine.Vector3  loc3;
    private UnityEngine.Vector3  loc4;
    private UnityEngine.Vector3  loc5;
    private UnityEngine.Vector3  loc6;
    private UnityEngine.Vector3  loc7;
    private UnityEngine.Vector3  loc8;
    private UnityEngine.Vector3  loc9;
    private UnityEngine.Vector3 loc10;
    private UnityEngine.Vector3 loc11;
    private UnityEngine.Vector3 loc12;
    private UnityEngine.Vector3 loc13;
    private UnityEngine.Vector3 loc14;
    private UnityEngine.Vector3 loc15;
    private UnityEngine.Vector3 loc16;
    private UnityEngine.Vector3 loc17;
    private UnityEngine.Vector3 loc18;
    private UnityEngine.Vector3 loc19;
    
    List<UnityEngine.Vector3> locs;
    

    void Start()
    {
        currentState = new BaseState("Work", this);
        loc1 = new UnityEngine.Vector3  ( -4.64f,-0.43f,23.52f);
        loc2 = new UnityEngine.Vector3  ( -24.6f,-0.43f,26.8f);
        loc3 = new UnityEngine.Vector3  (-18.57f,-0.43f,23.77f);
        loc4 = new UnityEngine.Vector3  (-12.72f,-0.43f,18.6f);
        loc5 = new UnityEngine.Vector3  ( -20.7f,-0.43f,18.6f);
        loc6 = new UnityEngine.Vector3  ( -25.5f,-0.43f,17.1f);
        loc7 = new UnityEngine.Vector3  ( -15.9f,-0.43f,26.9f);        
        loc8 = new UnityEngine.Vector3  ( -11.3f,-0.47f,-9.19f);
        loc9 = new UnityEngine.Vector3  (  -5.8f,-0.43f,17.1f);
        loc10 = new UnityEngine.Vector3 (  11.5f,-0.43f,26.9f);        
        loc11 = new UnityEngine.Vector3 (  33.4f,-0.47f,-9.19f);
        loc12 = new UnityEngine.Vector3 (  10.7f,-0.43f,17.1f);
        loc13 = new UnityEngine.Vector3 ( 17.24f,-0.43f,26.9f);        
        loc14 = new UnityEngine.Vector3 (  9.96f,-0.47f,-9.19f);
        loc15 = new UnityEngine.Vector3 (  10.1f,-0.43f,17.1f);
        loc16 = new UnityEngine.Vector3 (  19.4f,-0.43f,26.9f);        
        loc17 = new UnityEngine.Vector3 (  20.5f,-0.43f,16.7f);
        loc18 = new UnityEngine.Vector3 ( 29.24f,-0.43f,26.5f);  
        loc19 = new UnityEngine.Vector3 (  34.1f,-0.47f,16.58f);  

        locs = new List<UnityEngine.Vector3>() {loc1, loc2, loc3, loc4, loc5, loc6, loc7, loc8, loc9, loc10, loc11, loc12, loc13, loc14, loc15, loc16, loc17, loc18, loc19};
        homeLoc = locs[UnityEngine.Random.Range(0, 18)];
        vibeLoc = new UnityEngine.Vector3  (UnityEngine.Random.Range(-25f, 34f),-0.43f,UnityEngine.Random.Range(-11f, 26f));;
        workLoc = locs[UnityEngine.Random.Range(0, 18)];
        if (currentState != null)
            currentState.Enter();
        }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
        if (((clock.GetTimer() % daylength) - timer) < 0) { days++; worked = false; vibed = false; homed = false; }
        timer += ((clock.GetTimer() % daylength) - timer);
        if ((timer > 10)  && !worked) {worked = true; ChangeState(new BaseState("Work", this));}
        if ((timer > 100) &&  !vibed) {vibed =  true; ChangeState(new BaseState("Vibe", this));}
        if ((timer > 200) &&  !homed) {homed =  true; ChangeState(new BaseState("Home", this));}
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = new BaseState("Flux", this);
        currentState.Enter();
        if (newState.name == "Home") {
            agent.destination = homeLoc;
            spriteRenderer.color = Color.cyan;
        }
        if (newState.name == "Work") {
            agent.destination = workLoc;
            spriteRenderer.color = Color.red;
        }
        if (newState.name == "Vibe") {
            agent.destination = vibeLoc;
            spriteRenderer.color = Color.green;
        }
        while (((((agent.transform.position.x - agent.destination.x)*(agent.transform.position.z - agent.destination.z))) < 10f) &&
               ((((agent.transform.position.x - agent.destination.x)*(agent.transform.position.z - agent.destination.z))) > 10f)) {print("zam");}
        currentState.Exit();
        currentState = new BaseState(newState.name, this);
        currentState.Enter();

    }


    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? " State:  " + currentState.name + "            time: " + timer.ToString() + "             days: " + days.ToString(): "";
        GUILayout.Label($"<color='black'><size=30>{content}</size></color>");
    }
}






// using System.Numerics;
// using System.Net.Cache;
// using System.Text.RegularExpressions;
// using System.Linq.Expressions;
// using System.Net.WebSockets;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// //Given our analog clock, we will scale a day into six minutes. 
// //Big ups to https://medium.com/c-sharp-progarmming/make-a-basic-fsm-in-unity-c-f7d9db965134

// public class FSM_Human : MonoBehaviour
// {
//     public Rigidbody rigidbody;
//     public SpriteRenderer spriteRenderer;
//     public NavMeshAgent agent;
//     public TimeClock clock;
//     BaseState currentState;

//     public float lerpduration = 5;
//     public int timer = 0;
//     public int days =  0;
//     private int daylength = 360;
//     public int c = 0;
//     private int r;
//     public string state = "Home";
//     public UnityEngine.Vector3 homeLoc;
//     public UnityEngine.Vector3 vibeLoc;
//     public UnityEngine.Vector3 workLoc;
//     bool worked = false;
//     bool homed = true;
//     bool vibed = true;
//     int vtoh=100;
//     int htow=200;
//     int wtovorh=300;
//     List<UnityEngine.Vector3> locs = {UnityEngine.Vector3 (9.56000042f,23.1399994f,3.95000005f)};

//     void Start()
//     {
//         currentState = new BaseState("Work", this);
//         homeLoc = new UnityEngine.Vector3 (9.56000042f,23.1399994f,3.95000005f);
//         vibeLoc = new UnityEngine.Vector3 (19.2600002f,23.1399994f,17.1800003f);
//         workLoc = new UnityEngine.Vector3 (-25.6200008f,23.1399994f,26.9500008f);
//         if (currentState != null)
//             currentState.Enter();

//         agent.destination = workLoc;
//         htow     = UnityEngine.Random.Range(110, 130);
//         wtovorh  = UnityEngine.Random.Range(230, 250);
//         vtoh     = UnityEngine.Random.Range(260, 280);
//         worked   = false;
//         homed    = false;
//         vibed    = true;
//         if (UnityEngine.Random.Range(0, 100) < 70) {vibed = false;}
//         }

//     void Update()
//     {
//         if (currentState != null)
//             currentState.UpdateLogic();
//         if (((clock.GetTimer() % daylength) - timer) < 0) {
//             days++;
//         }
//         timer += ((clock.GetTimer() % daylength) - timer);
//         if ((timer > htow) && (!worked)) {
//             worked = true;
//             state = "Work";
//             agent.destination = workLoc;
//             ChangeState(new BaseState("Work", this));
//         }
//         else if ((timer > wtovorh+htow) &&(!vibed) && worked){
//             vibed = true;
//             state = "Vibe";
//             agent.destination = vibeLoc;
//             ChangeState(new BaseState("Vibe", this));
//         }
//         else if ((timer > vtoh+wtovorh+htow) && (!homed) && worked && vibed) {
//             homed = true;
//             state = "Home";
//             agent.destination = homeLoc;
//             ChangeState(new BaseState("Home", this));
//         }

        
//     }

//     void LateUpdate()
//     {
//         if (currentState != null)
//             currentState.UpdatePhysics();
//     }

//     public IEnumerator DailyUpdate() {           
                                                        
//         yield return new WaitForSeconds(0.1f);
//         }

//     public void ChangeState(BaseState newState)
//     {
//         if      (newState.name == "Home") {agent.destination = homeLoc;}
//         else if (newState.name == "Work") {agent.destination = workLoc;}
//         else if (newState.name == "Vibe") {agent.destination = vibeLoc;}
        
//         currentState.Exit();
//         currentState = new BaseState("Flux", this);
//         state = "Flux";
//         spriteRenderer.color = Color.black;
//         currentState.Enter();
        
//         if (transform.position == agent.destination) {
//         currentState.Exit();
//         currentState = new BaseState(newState.name, this);
//         state = newState.name;
//         if      (state=="Work") {spriteRenderer.color = Color.red;}
//         else if (state=="Home") {spriteRenderer.color = Color.blue;}
//         else if (state=="Vibe") {spriteRenderer.color = Color.green;}        
//         currentState.Enter();
//         }
//    }


//     protected virtual BaseState GetInitialState()
//     {
//         return new BaseState("Flux", this);
//     }

//     private void OnGUI()
//     {
//         string content = currentState != null ? " State: " + currentState.name + " time: " + timer.ToString() + " days: " + days.ToString(): "";
//         //string content = currentState != null ? currentState.name + "time: " + timer.ToString() + " days: " + days.ToString();
//         GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
//     }
// }



public class BaseState
{
    public string name;
    protected FSM_Human stateMachine;

    public BaseState(string name, FSM_Human stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}

public class Flux : BaseState
{
  private FSM_Trans _sm;

  public Flux(FSM_Trans stateMachine) : base("Flux", stateMachine) {
    _sm = stateMachine;
  }

  public override void UpdateLogic()
  {
    base.UpdateLogic();
    stateMachine.ChangeState(_sm.vibeState);
  }

  public override void UpdatePhysics()
  {
    base.UpdatePhysics();
    UnityEngine.Vector2 vel = _sm.rigidbody.velocity;
    vel.x = 2 * _sm.speed;
    _sm.rigidbody.velocity = vel;
  }

  public override void Enter()
  {
    base.Enter();
    _sm.spriteRenderer.color = Color.black;
  }

}

public class Vibe : BaseState
{
    private FSM_Trans _sm;

    public Vibe(FSM_Trans stateMachine) : base("Vibe", stateMachine) {
      _sm = stateMachine;
    }    
    public override void Enter()
    {
        base.Enter();
        _sm.spriteRenderer.color = Color.green;
    }
}

public class Work : BaseState
{
    private FSM_Trans _sm;

    public Work(FSM_Trans stateMachine) : base("Work", stateMachine) {
      _sm = stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        _sm.spriteRenderer.color = Color.red;
    }
}

public class Home : BaseState
{
    private FSM_Trans _sm;

    public Home(FSM_Trans stateMachine) : base("Home", stateMachine) {
      _sm = stateMachine;
    }

    
    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }
    public override void Enter()
    {
        base.Enter();
        _sm.spriteRenderer.color = Color.cyan;
    }
}
