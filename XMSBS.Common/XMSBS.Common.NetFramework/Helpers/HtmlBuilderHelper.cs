using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.Helpers
{
    public class HtmlBuilderHelper
    {
        private StringBuilder Builder { get; set; }

        public TableModel Table { get; set; }
        public DivModel Div { get; set; }
        public ParagraphModel P { get; set; }
        public LineBreakModel BR { get; set; }
        public AddressModel Address { get; set; }
        public StrongModel Strong { get; set; }
        public ListModel List { get; set; }

        public HtmlBuilderHelper()
        {
            this.Builder = new StringBuilder();
            this.Table = new TableModel(Builder, this);
            this.Div = new DivModel(Builder, this);
            this.P = new ParagraphModel(Builder, this);
            this.BR = new LineBreakModel(Builder, this);
            this.Address = new AddressModel(Builder, this);
            this.Strong = new StrongModel(Builder, this);
            this.List = new ListModel(Builder, this);
        }

        public string HtmlBuilderHerperEnd()
        {
            return this.Builder.ToString();
        }


        public class LineBreakModel
        {
            private StringBuilder Builder { get; set; }
            public HtmlBuilderHelper Html { get; set; }

            public LineBreakModel(StringBuilder builder, HtmlBuilderHelper html)
            {
                this.Builder = builder;
                this.Html = html;
            }

            public LineBreakModel()
            {
                Builder = new StringBuilder();
            }
            public HtmlBuilderHelper Create()
            {
                Builder.Append("</br>");
                return this.Html;
            }
        }

        public class StrongModel
        {
            private StringBuilder Builder { get; set; }
            public HtmlBuilderHelper Html { get; set; }

            public StrongModel(StringBuilder builder, HtmlBuilderHelper html)
            {
                this.Builder = builder;
                this.Html = html;
            }

            public StrongModel()
            {
                Builder = new StringBuilder();
            }
            public HtmlBuilderHelper Create(string text)
            {
                Builder.Append("<strong>");
                Builder.Append(text);
                Builder.Append("</strong>");
                return this.Html;
            }
        }

        public class ParagraphModel
        {
            private StringBuilder Builder { get; set; }
            public HtmlBuilderHelper Html { get; set; }

            public ParagraphModel(StringBuilder builder, HtmlBuilderHelper html)
            {
                this.Builder = builder;
                this.Html = html;
            }

            public ParagraphModel()
            {
                Builder = new StringBuilder();
            }
            public HtmlBuilderHelper Create(string paragraph)
            {
                Builder.Append("<p>");
                Builder.Append(paragraph);
                Builder.Append("</p>");
                return this.Html;
            }
        }

        public class DivModel
        {
            private StringBuilder Builder { get; set; }
            public HtmlBuilderHelper Html { get; set; }

            public DivModel(StringBuilder builder, HtmlBuilderHelper html)
            {
                this.Builder = builder;
                this.Html = html;
            }

            public DivModel()
            {
                Builder = new StringBuilder();
            }
            public DivModel Create()
            {

                Builder.Append("<div>");
                return this;
            }

            public HtmlBuilderHelper End()
            {

                Builder.Append("</div>");
                return this.Html;
            }
        }

        public class AddressModel
        {
            private StringBuilder Builder { get; set; }
            public HtmlBuilderHelper Html { get; set; }

            public AddressModel(StringBuilder builder, HtmlBuilderHelper html)
            {
                this.Builder = builder;
                this.Html = html;
            }

            public AddressModel()
            {
                Builder = new StringBuilder();
            }
            public AddressModel Create()
            {

                Builder.Append("<address>");
                return this;
            }

            public HtmlBuilderHelper End()
            {
                Builder.Append("</address>");
                return this.Html;
            }

            public AddressModel Title(string value)
            {
                Builder.Append("<strong>");
                Builder.Append(value);
                Builder.Append("</strong>");
                return this;
            }
            public AddressModel BR()
            {
                Builder.Append("</br>");
                return this;
            }
            public AddressModel Row(string value)
            {
                Builder.Append(value);
                return this;
            }
        }

        public class TableModel
        {
            private StringBuilder Builder { get; set; }
            public HtmlBuilderHelper Html { get; set; }

            public TableModel()
            {
                Builder = new StringBuilder();
            }

            public TableModel(StringBuilder builder, HtmlBuilderHelper html)
            {
                this.Builder = builder;
                this.Html = html;
            }

            public TableModel Create()
            {

                Builder.Append("<table border='1' cellspacing='0' cellpadding='10' width='100%' style='font-family:'Arial';font-size:'8px';>");
                return this;
            }

            public HtmlBuilderHelper EndTable()
            {
                Builder.Append("</table>");
                return this.Html;
            }

            public TableModel AddColumn(params string[] values)
            {
                Builder.Append("<td>");

                foreach (var item in values)
                {
                    Builder.Append(item);
                }

                Builder.Append("</td>");
                return this;
            }

            public TableModel StartRow()
            {
                Builder.Append("<tr>");
                return this;
            }

            public TableModel EndRow()
            {
                Builder.Append("</tr>");
                return this;
            }
        }

        public class ListModel
        {
            public enum ListType
            {
                Ordered,
                Unordered
            }
            private StringBuilder Builder { get; set; }
            public HtmlBuilderHelper Html { get; set; }
            private ListType Type { get; set; }

            public ListModel()
            {
                Builder = new StringBuilder();
            }
            public ListModel(StringBuilder builder, HtmlBuilderHelper html)
            {
                Builder = builder;
                Html = html;
            }

            public ListModel Create(ListType type)
            {
                Type = type;

                if (Type == ListType.Ordered)
                    Builder.Append("<ol>");
                else if (Type == ListType.Unordered)
                    Builder.Append("<ul>");

                return this;
            }

            public ListModel AddLi(string value)
            {
                Builder.Append($"<li>{value}</li>");
                return this;
            }

            public HtmlBuilderHelper EndList()
            {
                if (Type == ListType.Ordered)
                    Builder.Append("</ol>");
                else if (Type == ListType.Unordered)
                    Builder.Append("</ul>");

                return Html;
            }
        }
    }
}
