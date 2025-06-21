using System.ComponentModel.DataAnnotations.Schema;

namespace PowerSoft_IT.Areas.Admin.Models
{
    public class Nav
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum NavStatus
    {
        active,
        inactive
    }

    public class HeaderNav
    { 
        public HeaderNav()
        {
            this.Childs = new List<HeaderNavChild>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Url { get; set; }
        public NavStatus Status { get; set; }
        public List<HeaderNavChild> Childs {  get; set; }


    }  

    public class HeaderNavChild
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Url { get; set; }
        public NavStatus Status { get; set; }
        [ForeignKey("HeaderNav")]
        public int PrentId { get; set; }
        public HeaderNav HeaderNav { get; set; }
    }

    public class FooterNav
    {
        public FooterNav()
        {
            this.Childs = new List<FooterNavChild>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public NavStatus Status { get; set; }
        public List<FooterNavChild> Childs { get; set; }
    }

    public class FooterNavChild
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public NavStatus Status { get; set; }
        [ForeignKey("FooterNav")]
        public int PrentId { get; set; }
        public FooterNav HeaderNav { get; set; }
    }

}
