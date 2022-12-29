using FairyGUI;

namespace ECSFrame
{
    public class FullUIInterface : ISystem
    {
        /// <summary>
        /// UI被显示后调用
        /// </summary>
        /// <param name="UI"></param>
        public virtual void Start(GComponent UI)
        {

        }

        /// <summary>
        /// Start调用后每帧调用
        /// </summary>
        public virtual void UpData()
        {

        }
    }
}
