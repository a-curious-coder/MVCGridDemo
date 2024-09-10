using System.Collections.Generic;

namespace MVCGridProject.Models
{
    public class IndexViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<GridTypeInfo> GridTypes { get; set; } = new List<GridTypeInfo>();
    }

    public class GridTypeInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}