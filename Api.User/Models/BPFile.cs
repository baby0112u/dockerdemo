using System;

namespace Api.User.Models
{
    public class BPFile
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int AppUserId { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 上传源文件的地址
        /// </summary>
        public string OriginFilePath { get; set; }

        /// <summary>
        /// 格式转行后的文件地址
        /// </summary>
        public string FormatFilePath { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

    }
}
