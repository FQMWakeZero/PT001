using FairyGUI;
using ECSFrame;
using UnityEngine;
using LoadGamePack;
using System.Collections;
using MainGamePack;

public class MainGameSystem : FullUIInterface
{
    private static MainGameSystem _init;
    public static MainGameSystem init { get { if (_init == null) _init = new MainGameSystem(); return _init; } }
    public MainGameCom self;
    public override void Start(GComponent UI)
    {
        self = (MainGameCom)UI;
        Load();
        
    }

    public void Load()
    {
        self.Eff_1.asGraph.SetNativeObject(new GoWrapper(Object.Instantiate((GameObject)Resources.Load("ParticleEffect/FloatingMars/FloatingMars"))));
    }
}
