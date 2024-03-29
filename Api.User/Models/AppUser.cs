﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Models
{
    public class AppUser
    {
        public AppUser() {
            Properties = new List<UserProperty>();
        }
        /// <summary>
        /// 自增主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// 头像地址
        /// </summary>
        public string Avatar { get; set; }
        
        /// <summary>
        /// 性别 1男 0女
        /// </summary>
        public byte Gender { get; set; }
        
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 公司号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 省Id
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 名片地址
        /// </summary>
        public string NameCard { get; set; }

        /// <summary>
        /// 用户属性列表
        /// </summary>
        public List<UserProperty> Properties { get; set; }
        

    }
}
