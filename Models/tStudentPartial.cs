using Newtonsoft.Json;
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
    [MetadataType(typeof(tStudentMetadata))]
    public partial class tStudent
    {
        private class tStudentMetadata
        {
            [JsonIgnore]
            public virtual ICollection<tDiary> tDiaries { get; set; }

            [JsonIgnore]
            public virtual tClass tClass { get; set; }

            [JsonIgnore]
            public virtual tParent tParent { get; set; }

            [JsonIgnore]
            public virtual ICollection<tCommunication> tCommunications { get; set; }
        }

    }
}