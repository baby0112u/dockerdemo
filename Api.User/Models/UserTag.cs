using System;

namespace Api.User.Models
{
    public class UserTag
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int AppUserId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
