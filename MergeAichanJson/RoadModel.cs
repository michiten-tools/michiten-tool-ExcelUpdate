using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeAichanJson
{
    public class RoadModel
    {
        public Guid RoadId { get; set; } = Guid.Empty;

        //public int Index { get; set; } = -1;
        public string Name { get; set; } = "";
        public string Define { get; set; } = "";

        public Color Color { get; set; } = Color.Magenta;

        public List<RectItem> Rects { get; set; } = new List<RectItem>();

        public int Add(RectItem item)
        {
            Rects.Add(item);
            ReIndex();

            return Rects.IndexOf(item);
        }

        public void Insert(int index, RectItem item)
        {
            Rects.Insert(index, item);
            ReIndex();
        }

        public void RemoveAt(int index)
        {
            Rects.RemoveAt(index);
            ReIndex();
        }

        public void Up(int index)
        {
            if (index == 0)
                return;

            //ListFunc.ReplaceList(Rects, index, index - 1);
            ReIndex();
        }

        public void Down(int index)
        {
            if (index == Rects.Count - 1)
                return;

            //ListFunc.ReplaceList(Rects, index, index + 1);
            ReIndex();
        }

        private void ReIndex()
        {
            int i = 1;
            foreach (var rect in Rects)
            {
                rect.Index = i++;
            }
        }
    }

    public class RectItem
    {
        public Guid RectId { get; set; } = Guid.Empty;

        public int Index { get; set; }
        public double Width { get; set; } = 10;

        public int Selected { get; set; } = 0;
        public int Count { get; set; } = 0;

        public LatLng Src { get; set; } = null;
        public LatLng Dst { get; set; } = null;

        public List<LatLng> Points { get; set; } = new List<LatLng>();
    }
}
