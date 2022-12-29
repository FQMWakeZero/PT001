using FairyGUI;

namespace ECSFrame
{
    /// <summary>
    /// UI基础系统，包含基础事件
    /// </summary>
    public interface ISystem:UI
    {
        public void Start(GComponent UI);
    }
}
