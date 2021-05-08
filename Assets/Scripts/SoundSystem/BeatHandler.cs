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

    [SerializeField] bool testFireBeat;
    [SerializeField] private float bpm = 100;

    private LinkedList<OnBeatBehaviour> beatBehaviours;
    private float beatDistance;
    private float beatDistanceClipped;

    private string musicEvent = "event:/Music";
    FMOD.Studio.EventInstance musicState;
    FMOD.Studio.PARAMETER_ID layerParameterId;

    public static BeatHandler Instance { get => instance; }
    public float BeatDistance => beatDistance;
    public float BeatDistanceClipped => beatDistanceClipped;

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

        StartCoroutine(OnBeatRoutine());

        try
        {
            musicState = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
            musicState.start();
            FMOD.Studio.EventDescription description;
            musicState.getDescription(out description);
            FMOD.Studio.PARAMETER_DESCRIPTION paramDesc;
            description.getParameterDescriptionByName("layer", out paramDesc);
            layerParameterId = paramDesc.id;
            SetMusicLayer(0);
        }
        catch
        {
            //EventNotFound
        }
    }

    public void SetMusicLayer(int value)
    {
        musicState.setParameterByID(layerParameterId, value);
    }

    private void OnDestroy()
    {
        try
        {
            musicState.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        catch { }
    }

    private IEnumerator OnBeatRoutine()
    {

        float t = 0;
        while (true)
        {
            //Update tempo continuously to allow testing modification
            float tempo = 60.0f / bpm;
            yield return null;
            t += Time.deltaTime;

            float val = 1 - Mathf.Clamp01(t / tempo);
            beatDistance = Mathf.Abs(val * 2 - 1);
            beatDistanceClipped = val;

            if (t > tempo)
            {
                t = 0;
                NotifyOnBeat();
            }
        }
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
