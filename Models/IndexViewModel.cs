using System.Collections.Generic;

namespace MVCGridProject.Models
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<GridTypeInfo> GridTypes { get; set; }
    }

    public class GridTypeInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}