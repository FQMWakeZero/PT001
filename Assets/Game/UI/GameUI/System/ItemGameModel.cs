using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using ItemGame;
using GameModel;
using DG.Tweening;
using System;

public class ItemGameModel : PageModel<UI_ItemGame>
{
    private bool _isTrailing = true;
    /// <summary>
    /// 是否开启拖尾，默认开
    /// </summary>
    public bool isTrailing
    {
        get => _isTrailing;
        set
        {
            self.UI_Trail.gameObject.SetActive(value);
            _isTrailing = value;
        }
    }

    public int Number { get; private set; }

    /// <summary>
    /// 移动到另外一个ItemGameModel的位置
    /// </summary>
    /// <param name="ItemGameModel"></param>
    public IEnumerator ModeToItemGameModel(ItemDateUI ItemGameModel, bool Dispose = true)
    {
        //暂时的动画
        self.RectTransform.DOLocalMove(ItemGameModel.OccupationObject.GetComponent<RectTransform>().localPosition, 0.15f).onComplete = () =>
        {
            if (Dispose)
            {
                this.Dispose();
            }
        };

        yield return new WaitForSeconds(0.25f);
        yield return 0;
    }

    /// <summary>
    /// 移动到另外一个ItemGameModel的位置
    /// </summary>
    /// <param name="ItemGameModel"></param>
    public IEnumerator ModeToItemGameModel(ItemDateUI ItemGameModel, Action DisposeOK)
    {
        //暂时的动画
        self.RectTransform.DOLocalMove(ItemGameModel.OccupationObject.GetComponent<RectTransform>().localPosition, 0.25f).onComplete = () =>
        {
            this.Dispose();
            DisposeOK?.Invoke();
        };
        yield return 0;
    }
    /// <summary>
    /// 动画到另一个数字
    /// </summary>
    /// <param name="Number"></param>
    /// <returns></returns>
    public IEnumerator TweenToNumber(int Number)
    {
        ItemDataSubobject data = ItemData.Init.find(Number.ToString());
        if (data != null)
        {
            DOTween.To(() => this.Number, (value) => self.UI_ItemNumber.TextMeshProUGUI.text = value.ToString(), Number, 0.2f);
            self.RectTransform.DOScale(1.2f, 0.15f).onComplete = () =>
            {
                self.RectTransform.DOScale(1f, 0.15f);
            };

            SetTailing(Number);
            AssetsManager<Sprite>.Init.LoadAssetAsync(data.SpriteID.ToEntityTable().Spirit, (Sprite) => self.UI_TransitionalBackground.Image.sprite = Sprite);
            self.UI_TransitionalBackground.Image.DOFade(1, 0.15f);


            yield return new WaitForSeconds(0.2f);

            this.Number = Number;

            AssetsManager<Sprite>.Init.LoadAssetAsync(data.SpriteID.ToEntityTable().Spirit, (Sprite) =>
            {
                self.UI_ItemBack.Image.sprite = Sprite;
                self.UI_TransitionalBackground.Image.DOFade(0, 0);
            });
        }

        yield return 0;
    }

    /// <summary>
    /// 设置数字
    /// </summary>
    public void SetNumber(int Number)
    {
        ItemDataSubobject data = ItemData.Init.find(Number.ToString());
        if (data != null)
        {
            this.Number = Number;
            AssetsManager<Sprite>.Init.LoadAssetAsync(data.SpriteID.ToEntityTable().Spirit, (Sprite) =>
            {
                self.UI_ItemBack.Image.sprite = Sprite;
            });
            self.UI_ItemNumber.TextMeshProUGUI.text = Number.ToString();
            SetTailing(Number);
        }
    }

    private void SetTailing(int Number)
    {
        ItemDataSubobject data = ItemData.Init.find(Number.ToString());
        self.UI_Trail.TrailRenderer.colorGradient.SetKeys(
                new GradientColorKey[]{
                    new GradientColorKey(new Color(data.TrailColors_RGB[0]/255,data.TrailColors_RGB[0]/255,data.TrailColors_RGB[0]/255),1),
                    new GradientColorKey(new Color(data.TrailEnd_RGB[0]/255,data.TrailEnd_RGB[0]/255,data.TrailEnd_RGB[0]/255),1),
                }, new GradientAlphaKey[]
                {
                    new GradientAlphaKey(1,0),
                    new GradientAlphaKey(0,1),
                });
    }

    public override void Awake()
    {

    }
}
