﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forensics.Model.Extract
{
    public class Act
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ActExtractType> listExtractType { get; set; } = new List<ActExtractType>();

        public string ImagePath
        {
            get
            {
                return Directory.GetCurrentDirectory() + "\\Images\\extract\\" + this.Id + ".png";
            }
        }

        public bool IsAvailable { get; set; } = false;

        public bool IsSelected
        {
            get
            {
                if (!this.IsAvailable)
                {
                    return false;
                }

                // 至少有一个提取方式选择的就设置为选择
                return this.listExtractType.Where(x => x.IsSelected == true).Count() > 0 ? true : false;
            }
        }
    }

    public class ActGroup
    {
        public enum SelectTypeEnum
        {
            MultiSelect,
            SingleSelect
        }

        public List<Act> Acts { get; set; } = new List<Act>();
        public SelectTypeEnum SelectType { get; set; }
    }
}
