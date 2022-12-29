using FairyGUI;
using ECSFrame;
using UnityEngine;
using LoadGamePack;
using System.Collections;
using MainGamePack;

public class LoadGameSystem : FullUIInterface
{
    private static LoadGameSystem _init;
    public static LoadGameSystem init { get { if (_init == null) _init = new LoadGameSystem(); return _init; } }
    public LoadGameCom self;
    public override void Start(GComponent UI)
    {
        self = (LoadGameCom)UI;

        Init.init.StartCoroutine(Voi());
        IEnumerator Voi()
        {
            self.LogingBar.value = 0;
            float number = 0;
            while (number < 101)
            {
                number += Random.Range(0.1f,5f);
                self.LogingBar.TweenValue(number, 0.5f);
                yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));
            }
            self.LogingBar.value = 100;
            yield return new WaitForSeconds(0.5f);

            self.End.Play(() =>
            {
                UIManager.Init.Dispose(this);
                MainGameCom.CreateInstance().ShowUI(MainGameSystem.init);
            });
        }
    }
}
