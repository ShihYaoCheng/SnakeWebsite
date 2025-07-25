﻿namespace SnakeAsianLeague.Data.Paging
{
    public class PagingLink
    {
        public string Text { get; set; }
        public int Page { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }

        public PagingLink(int page)
           : this(page, true) { }

        public PagingLink(int page, bool enabled)
            : this(page, enabled, page.ToString())
        { }

        public PagingLink(int page, bool enabled, string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
        

    }
}
