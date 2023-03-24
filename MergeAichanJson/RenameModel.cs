using Newtonsoft.Json;
using System;

namespace MergeAichanJson
{
    public class RenameModel
    {
        public bool Detect { get; set; } = false;
        public bool Selected { get; set; } = false;

        public Guid RoadId { get; set; } = Guid.Empty;
        public Guid RectId { get; set; } = Guid.Empty;

        public string Rename { get; set; } = string.Empty;


        /// <summary>
        /// 表示用納品ラベル文字列を返す
        /// </summary>
        [JsonIgnore]
        public string DispRename
        {
            get
            {
                if (string.IsNullOrEmpty(Rename)) return "";
                return Rename;
            }
        }

    }
}
