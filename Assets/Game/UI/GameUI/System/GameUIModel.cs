using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using ItemGame;
using GameUI;
using DG.Tweening;
using UnityEngine.EventSystems;
using GameModel;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameUIModel : PageModel<UI_GameUI>
{
    private List<ItemDateUI> itemDateUIs = new List<ItemDateUI>();
    /// <summary>
    /// 准备位置上的item
    /// </summary>
    private ItemGameModel Preparation;
    /// <summary>
    /// 选中的位置
    /// </summary>
    private int PointerEnterIndex;

    public override void Awake()
    {
        CreateItemContainer();
        CreateItem();
        MonitoringSlideRail();
        GameInit.Init.StartCoroutine(QueueExecutor());

        self.UI_Top.UI_BackButton.Button.ButtonShrink(ExitGame);

        NumericalSubscription();
    }

    /// <summary>
    /// 订阅数值变动并赋予动画
    /// </summary>
    private void NumericalSubscription()
    {
        self.UI_Top.UI_SilverCoin.UI_SilverCoinText.TextMeshProUGUI.text = PlayerData.init.numericalManaqer.GetValue<long>(Numer.SilverCoin).Units();
        PlayerData.init.numericalManaqer.AddUpData<long>(Numer.SilverCoin, (Value) =>
        {
            if (self != null)
            {
                DOTween.To(() => Value, (value) => self.UI_Top.UI_SilverCoin.UI_SilverCoinText.TextMeshProUGUI.text = PlayerData.init.numericalManaqer.GetValue<long>(Numer.SilverCoin).Units(), Value, 0.15f);
            }
        });

        //宝石订阅
        PlayerData.init.numericalManaqer.AddUpData<long>(Numer.Gemstone, (value) =>
        {
            self.UI_Top.UI_Gemstone.UI_GemstoneText.TextMeshProUGUI.text = value.ToString();
        });
    }

    #region 主要游戏玩法代码
    /// <summary>
    /// 队列执行器
    /// </summary>
    /// <returns></returns>
    private IEnumerator QueueExecutor()
    {
        do
        {
            if (ArrayQueue.Count != 0)
                if (!IsBlocked(ArrayQueue[0].ItemDateUI))
                {
                    GameInit.Init.StartCoroutine(ArrayQueue[0].Enumerator);
                    //yield return ArrayQueue[0].Enumerator;
                    ArrayQueue.RemoveAt(0);
                    yield return null;
                }
                else
                {
                    SearchForMovableBlocks();
                    yield return null;
                }

            yield return null;

        } while (true);
    }

    /// <summary>
    /// 带动画计算队列
    /// </summary>
    private List<ObjectAndCoroutine> ArrayQueue = new List<ObjectAndCoroutine>();
    /// <summary>
    /// 开始计算阵列
    /// </summary>
    /// <param name="itemDateUI">起始点</param>
    private IEnumerator ArrayComputing(ItemDateUI itemDateUI)
    {
        if (itemDateUI?.isEmpty == true)
        {
            ItemDateUI Upper = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x, itemDateUI.Position.y - 1));
            ItemDateUI below = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x, itemDateUI.Position.y + 1));
            ItemDateUI left = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x - 1, itemDateUI.Position.y));
            ItemDateUI right = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x + 1, itemDateUI.Position.y));

            //提前锁住要参与动画的数据，避免被其他协程影响
            itemDateUI.isLook = true;
            if (Upper != null)
                if (Upper.isEmpty)
                    Upper.isLook = true;
            if (below != null)
                if (below.isEmpty)
                    below.isLook = true;
            if (left != null)
                if (left.isEmpty)
                    left.isLook = true;
            if (right != null)
                if (right.isEmpty)
                    right.isLook = true;


            itemDateUI.ItemGame.self.RectTransform.SetAsLastSibling();
            //然后再放对应的动画


            if (left != null && left.isEmpty && left.ItemGame.Number == itemDateUI.ItemGame.Number)
            {
                GameInit.Init.StartCoroutine(left.ItemGame.ModeToItemGameModel(itemDateUI));

                //如果左边抽走了块就判断左边的下面是否有块
                ItemDateUI leftBelow = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x - 1, itemDateUI.Position.y + 1));
                if (leftBelow?.isEmpty == true)
                {
                    ArrayQueue.Add(new ObjectAndCoroutine(ArrayComputing(leftBelow), leftBelow));
                }
            }

            if (right != null && right.isEmpty && right.ItemGame.Number == itemDateUI.ItemGame.Number)
            {
                GameInit.Init.StartCoroutine(right.ItemGame.ModeToItemGameModel(itemDateUI));

                //如果右边抽走了块就判断右边的下面是否有块
                ItemDateUI rightBelow = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x + 1, itemDateUI.Position.y + 1));
                if (rightBelow?.isEmpty == true)
                {
                    ArrayQueue.Add(new ObjectAndCoroutine(ArrayComputing(rightBelow), rightBelow));
                }


            }

            if (Upper != null && Upper.isEmpty && Upper.ItemGame.Number == itemDateUI.ItemGame.Number)
            {
                GameInit.Init.StartCoroutine(Upper.ItemGame.ModeToItemGameModel(itemDateUI));
                yield return new WaitForSeconds(0.15f);

                //ArrayQueue.Add(new ObjectAndCoroutine(ArrayComputing(itemDateUI), itemDateUI));
            }

            if (below != null && below.isEmpty && below.ItemGame.Number == itemDateUI.ItemGame.Number)
            {
                GameInit.Init.StartCoroutine(below.ItemGame.ModeToItemGameModel(itemDateUI));
                yield return new WaitForSeconds(0.15f);
            }




            if ((Upper?.ItemGame?.Number == itemDateUI.ItemGame.Number) ||
                (below?.ItemGame?.Number == itemDateUI.ItemGame.Number) ||
                (left?.ItemGame?.Number == itemDateUI.ItemGame.Number) ||
                (right?.ItemGame?.Number == itemDateUI.ItemGame.Number))
            {

                if (Upper?.ItemGame?.Number == itemDateUI.ItemGame.Number)
                    Upper.ItemGame = null;
                if (below?.ItemGame?.Number == itemDateUI.ItemGame.Number)
                    below.ItemGame = null;
                if (left?.ItemGame?.Number == itemDateUI.ItemGame.Number)
                    left.ItemGame = null;
                if (right?.ItemGame?.Number == itemDateUI.ItemGame.Number)
                    right.ItemGame = null;

                if (itemDateUI.ItemGame.Number * 2 <= 8192)
                {
                    Debug.Log("数字翻倍");
                    PlayerData.init.numericalManaqer.AddValue<long>(Numer.SilverCoin, itemDateUI.ItemGame.Number * 2);
                    yield return itemDateUI.ItemGame.TweenToNumber(itemDateUI.ItemGame.Number * 2);

                    ArrayQueue.Insert(0, new ObjectAndCoroutine(ArrayComputing(itemDateUI), itemDateUI));

                    //====================添加银币===================//

                }
                else
                {
                    //暂时空着还没想好怎么写
                    itemDateUI.ItemGame.Dispose();
                    itemDateUI.isLook = false;
                }
            }

            //====向上移动====//




            //判断是否可以往上移动
            ItemDateUI NewUpper = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x, itemDateUI.Position.y - 1));
            if (NewUpper != null && NewUpper.isEmpty == false)
            {
                itemDateUI.isLook = true;
                NewUpper.isLook = true;

                Debug.Log("添加向上移动");
                //yield return itemDateUI.ItemGame.ModeToItemGameModel(NewUpper, false);
                GameInit.Init.StartCoroutine(itemDateUI.ItemGame.ModeToItemGameModel(NewUpper, false));

                NewUpper.ItemGame = itemDateUI.ItemGame;
                itemDateUI.ItemGame = null;

                NewUpper.isLook = false;
                itemDateUI.isLook = false;




                //递归继续判断
                ArrayQueue.Add(new ObjectAndCoroutine(ArrayComputing(NewUpper), NewUpper));

                //检测下方是否有没动的给拉下来
                ItemDateUI NewNewUpper = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x, itemDateUI.Position.y + 1));
                if (NewNewUpper != null && NewNewUpper.isEmpty == true)
                {
                    ArrayQueue.Add(new ObjectAndCoroutine(ArrayComputing(NewNewUpper), NewNewUpper));
                }
            }



            if (Upper != null)
                Upper.isLook = false;
            if (below != null)
                below.isLook = false;
            if (left != null)
                left.isLook = false;
            if (right != null)
                right.isLook = false;

            itemDateUI.isLook = false;

            yield return 0;


        }

    }


    /// <summary>
    /// 寻找可动块，保险代码
    /// </summary>
    private void SearchForMovableBlocks()
    {
        foreach (var item in itemDateUIs)
        {
            ItemDateUI NewUpper = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(item.Position.x, item.Position.y - 1));
            if (NewUpper != null && NewUpper.isEmpty == false)
            {
                ArrayQueue.Add(new ObjectAndCoroutine(ArrayComputing(NewUpper), NewUpper));
            }
        }
    }

    /// <summary>
    /// 判断是否有锁
    /// </summary>
    /// <param name="itemDateUI"></param>
    /// <returns></returns>
    private bool IsBlocked(ItemDateUI itemDateUI)
    {
        ItemDateUI Upper = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x, itemDateUI.Position.y - 1));
        ItemDateUI below = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x, itemDateUI.Position.y + 1));
        ItemDateUI left = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x - 1, itemDateUI.Position.y));
        ItemDateUI right = itemDateUIs.FirstOrDefault(item => item.Position == new Vector2(itemDateUI.Position.x + 1, itemDateUI.Position.y));

        //连续判断要进行计算的对象是否会遇到被锁住的对象
        if (itemDateUI?.ItemGame != null)
            if (itemDateUI.isLook)
                return true;
        if (Upper != null)
            if (Upper.isLook)
                return true;
        if (below != null)
            if (below.isLook)
                return true;
        if (left != null)
            if (left.isLook)
                return true;
        if (right != null)
            if (right.isLook)
                return true;
        return false;
    }

    private void MonitoringSlideRail()
    {
        //点击
        EventTrigger.Entry PressDown = new EventTrigger.Entry();
        PressDown.eventID = EventTriggerType.PointerDown;
        PressDown.callback.AddListener((BaseEventData) => MoveIndex());

        //滑动
        EventTrigger.Entry dragEntry = new EventTrigger.Entry();
        dragEntry.eventID = EventTriggerType.Drag;
        dragEntry.callback.AddListener((BaseEventData) => MoveIndex());

        //松开
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((BaseEventData) => ReleaseMouse());

        self.UI_Game.UI_Track.EventTrigger.triggers.Add(dragEntry);
        self.UI_Game.UI_Track.EventTrigger.triggers.Add(entry2);
        self.UI_Game.UI_Track.EventTrigger.triggers.Add(PressDown);



        //松开手指
        void ReleaseMouse()
        {
            if (Preparation == null)
                return;

            if (PointerEnterIndex != -1)
            {
                //判断是否复合条件
                Vector2 vector2 = new Vector2(PointerEnterIndex, 8);
                ItemDateUI foundItem = itemDateUIs.FirstOrDefault(item => item.Position == vector2);
                Debug.Log($"当前选择的轨道为：{PointerEnterIndex}");

                if (foundItem.isEmpty == false)
                {
                    ItemDateUI predeterminedLocation = null;

                    for (int i = 9 - 1; i >= 0; i--)
                    {
                        Vector2 DetectingCoordinates = new Vector2(PointerEnterIndex, i);
                        predeterminedLocation = itemDateUIs.FirstOrDefault(item => item.Position == DetectingCoordinates);
                        if (predeterminedLocation?.isEmpty == true)
                        {
                            Vector2 _DetectingCoordinates = new Vector2(PointerEnterIndex, i + 1);
                            predeterminedLocation = itemDateUIs.FirstOrDefault(item => item.Position == _DetectingCoordinates);
                            break;
                        }

                    }

                    if (predeterminedLocation != null && predeterminedLocation?.isEmpty == false)
                    {
                        Preparation.self.RectTransform.DOLocalMove(predeterminedLocation.OccupationObject.GetComponent<RectTransform>().localPosition, 0.25f).onComplete = () =>
                        {
                            predeterminedLocation.isLook = false;
                        };
                        predeterminedLocation.ItemGame = Preparation;
                        predeterminedLocation.isLook = true;
                        Preparation = null;
                        ArrayQueue.Add(new ObjectAndCoroutine(ArrayComputing(predeterminedLocation), predeterminedLocation));
                        CreateItem();
                    }
                    else
                    {
                        Preparation.SetParent(self.UI_Buttn.UI_Icon.UI);
                        Preparation.self.RectTransform.DOLocalMove(Vector3.zero, 0.25f);
                    }
                }
                else
                {
                    Preparation.SetParent(self.UI_Buttn.UI_Icon.UI);
                    Preparation.self.RectTransform.DOLocalMove(Vector3.zero, 0.25f);
                }
            }
        }

        //移动到指定位置
        void MoveIndex()
        {
            if (Preparation == null)
                return;

            //获取当前手指在哪一条轨道
            if (EventSystem.current.IsPointerOverGameObject())
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                };

                List<RaycastResult> raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);

                foreach (RaycastResult result in raycastResults)
                {
                    int index = 0;
                    foreach (Transform itemDateUI in self.UI_Game.UI_Track.transform)
                    {
                        if (result.gameObject.name != itemDateUI.gameObject.name)
                            PointerEnterIndex = -1;
                        else
                        {
                            PointerEnterIndex = index;
                            break;
                        }
                        index++;
                    }

                    if (PointerEnterIndex != -1)
                        break;
                }
            }

            //播放移动的动画
            if (PointerEnterIndex != -1)
            {

                Vector2 vector2 = new Vector2(PointerEnterIndex, 8);
                ItemDateUI foundItem = itemDateUIs.FirstOrDefault(item => item.Position == vector2);
                if (foundItem.isEmpty == false && foundItem.isLook == false)
                {
                    Preparation.SetParent(foundItem.OccupationObject.transform.parent.gameObject);
                    Preparation.self.RectTransform.DOLocalMove(foundItem.OccupationObject.GetComponent<RectTransform>().localPosition, 0.1f);
                }
            }
        }
    }

    /// <summary>
    /// 创建一个Item在准备位置
    /// </summary>
    private void CreateItem()
    {

        ItemGameModel.CreateAnsy<ItemGameModel>(self.UI_Buttn.UI_Icon.gameObject, (ItemGameModel) =>
        {
            Preparation = ItemGameModel;

            ItemGameModel.self.RectTransform.localPosition = Vector3.zero;

            //==========设置出现动画===========//
            ItemGameModel.self.RectTransform.localScale = Vector3.zero;
            ItemGameModel.self.RectTransform.DOScale(Vector3.one, 0.25f);

            ItemGameModel.SetNumber(GetNumber());
        });
    }

    #endregion

    /// <summary>
    /// 退出游戏
    /// </summary>
    private void ExitGame()
    {
        Dispose();
    }

    private int GetNumber()
    {
        int[] Numbers = { 2, 4, 8 };
        return Numbers[Random.Range(0, Numbers.Length)];
    }

    /// <summary>
    /// 创建Item容器
    /// </summary>
    private void CreateItemContainer()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                GameObject Object = new GameObject($"{x}-{y}", typeof(RectTransform));
                Object.transform.SetParent(self.UI_Game.UI_Items.transform);
                Object.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
                Object.GetComponent<RectTransform>().localScale = Vector2.one;
                ItemDateUI ItemDateUI = new ItemDateUI(Object, new Vector2(x, y));

                itemDateUIs.Add(ItemDateUI);
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(self.UI_Game.UI_Items.RectTransform);
        self.UI_Game.UI_Items.GridLayoutGroup.enabled = false;
    }
}

/// <summary>
/// 对象和协程，包装类
/// </summary>
public class ObjectAndCoroutine
{
    public IEnumerator Enumerator;
    public ItemDateUI ItemDateUI;

    public ObjectAndCoroutine(IEnumerator enumerator, ItemDateUI itemDateUI)
    {
        Enumerator = enumerator;
        ItemDateUI = itemDateUI;
    }
}

public class ItemDateUI
{
    /// <summary>
    /// 占位对象
    /// </summary>
    public GameObject OccupationObject;
    /// <summary>
    /// UI对象
    /// </summary>
    public ItemGameModel ItemGame;
    /// <summary>
    /// 坐标
    /// </summary>
    public Vector2 Position;
    /// <summary>
    /// 是否被占用
    /// </summary>
    public bool isEmpty => ItemGame != null;
    /// <summary>
    /// 是否被锁定
    /// </summary>
    public bool isLook = false;

    public ItemDateUI(GameObject OccupationObject, Vector2 Position)
    {
        this.OccupationObject = OccupationObject;
        this.Position = Position;
    }
}