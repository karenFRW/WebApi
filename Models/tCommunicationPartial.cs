﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    /// <summary>
    /// 關聯欄位使用 partial class 與 MetadataType 解決
    /// 有關聯的欄位加入 private class 中，配合[JsonIgnore]
    /// </summary>

    [MetadataType(typeof(tCommunicationMetadata))]
    public partial class tCommunication
    {
        private class tCommunicationMetadata
        {
            [JsonIgnore]
            public virtual tStudent tStudent { get; set; }
        }

    }
}