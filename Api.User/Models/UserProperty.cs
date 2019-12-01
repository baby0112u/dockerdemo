namespace Api.User.Models
{
    public class UserProperty
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int AppUserId { get; set; }

        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 展示文本
        /// </summary>
        public string  Text { get; set; }

        /// <summary>
        /// 值对        /// </summary>
        public string Value { get; set; }
    }
}
