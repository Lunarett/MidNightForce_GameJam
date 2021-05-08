using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class BeatHandlerInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    public static void Initialize()
    {
        GameObject beatHandler = new GameObject("__BeatHandler");
        GameObject.DontDestroyOnLoad(beatHandler);
        beatHandler.hideFlags = HideFlags.DontSave;
        beatHandler.AddComponent<BeatHandler>();
    }


}



public class BeatHandler : MonoBehaviour
{
    private static BeatHandler instance;

    private LinkedList<OnBeatBehaviour> beatBehaviours;

    [SerializeField] bool testFireBeat;


    public static BeatHandler Instance { get => instance; }

    private void Awake()
    {
        if (instance)
        {
            Debug.LogError("Added Second Definiton of BeatHandler");
            Destroy(gameObject);
            return;
        }
        instance = this;
        beatBehaviours = new LinkedList<OnBeatBehaviour>();
    }

    private void Update()
    {
        //For testing purpuses
        if (testFireBeat)
        {
            NotifyOnBeat();
            testFireBeat = false;
        }
    }

    public void NotifyOnBeat()
    {
        foreach (var b in beatBehaviours)
        {
            b.OnBeat();
        }
    }

    public void RegisterBeatBehaviour(OnBeatBehaviour behaviour)
    {
        beatBehaviours.AddLast(behaviour);
    }

    public void UnregisterBeatBehaviour(OnBeatBehaviour behaviour)
    {
        beatBehaviours.Remove(behaviour);
    }
}
