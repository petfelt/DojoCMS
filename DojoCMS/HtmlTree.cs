using System;
using System.Collections.Generic;

namespace DojoCMS
{
    public class HtmlTree
    {
        Node root;
        public Dictionary<String, Dictionary<String, Object>> json;
        public HtmlTree()
        {
            this.root = new Node("primary", "div", new List<String>(), 0);
        }

        public String compileLinks(List<String> links) {
            String retStr = "";
            for (int i = 2; i < links.Count; ++i) {
                retStr += String.Format("\t\t\t\t<li><a href=\"#\">{0}</a></li>\n", links[i]);
            }
            return retStr;
            
        }

        public String addTemplate() {
            return "@{\n\tViewData[\"Title\"] = \"Login\";\n}";
        }

        public void buildSideBar() {
            List<String> links = new List<String>();
            List<String> demo = new List<String>();
            demo.Add("class=\"sm-3 sidebar text-center\"");
            links.Add("Test1");
            links.Add("Test2");
            links.Add("Test3");
            links.Add("Test4");
            addNode("sideBar", "div", demo);
            String contentStr = String.Format(
                                "<div class=\"col-sm-2 sidebar2\">\n" +
                                "\t\t\t<br />\n" +
                                "\t\t\t<ul class = \"nav nav-pills nav-stacked toggle\">\n" +
                                compileLinks(links) +
                                "\t\t\t</ul><br />\n" +
                                "\t\t\t</div>\n" +
                                "\t\t</div>\n" +
                                
                                "");
            updateContent("sideBar", contentStr);
        }
        public void buildNavBar()
        {
            List<String> link = new List<String>();
            link.Add("Home");
            link.Add("About");
            link.Add("TEXT");
            link.Add("TEST");
            link.Add("TEST2");
            List<String> demo = new List<String>();
            demo.Add("class = \"navbar navbar-inverse\"");
            addNode("navBar", "nav", demo);
            String contentStr = String.Format("" +
                                 "<div class =\"container-fluid\">\n" +
                                 "\t\t\t<div class = \"navbar-header\">\n" +
                                 "\t\t\t\t<a class=\"navbar-brand\" href=\"#\">{0}</a>\n" +
                                 "\t\t\t</div>\n" + 
                                 "\t\t\t<ul class={2}>\n" +
                                 "\t\t\t\t<li class = \"active\"><a href=\"#\">{1}</a></li>\n" +
                                 compileLinks(link) +
                                 "\t\t\t</ul>\n" +
                                 "\t\t</div>\n" +
                                 "", link[0], link[2], "\"nav navbar-nav\"");
            //json["navBar"]["Links"][0];
            updateContent("navBar", (string)contentStr);
        }

        public void buildMainBody() {
            List<String> attr = new List<String>();
            attr.Add("class=\"col-sm-9 col-sm-offset-3\"");
            addNode("mainBody", "div", attr);
            String contentStr = String.Format(
                                "\t<div>\n" +
                                "\t\t<h2 class=\"font1\">{0}</h2>\n" +
                                "\t</div>\n" +
                                "\t<div>\n" +
                                "\t\t<h5 class=\"font1\"><span class=\"glyphicon glyphicon-time\"></span> {1} {2} </h5><br />\n"+
                                "\t\t<p class=\"font1\">{3}</p>\n" +
                                "\t</div>\n",
                                    "Title", "UserName", "Date Submitted", "Edit your post here");
            updateContent("mainBody", contentStr);

        }
        public void buildDefault()
        {
            buildNavBar();
            buildSideBar();
            buildMainBody();
        }
        
        public void addJson(Dictionary<String, Dictionary<String, Object>> json) {
            this.json = json;
        }
 
        public void addNode(String id, String tag, List<String> attributes)
        {
            this.root.children.Add(new Node(id, tag, attributes, 1));
        }

        public String toHtml()
        {
            return addTemplate() + "\n" + toHtml(root);
        }

        public String toHtml(Node focus)
        {
            String page = focus.openTag;
            if (focus.children.Count > 0)
            {
                for (int i = 0; i < focus.children.Count; ++i)
                {
                    page += toHtml(focus.children[i]);
                }
            }
            return (page + focus.content + focus.closingTag);
        }


        public void updateContent(String id, String content)
        {
            Node active = findNode(id);
            active.content = String.Format("{0}{1}", active.addIndents(active.level + 1), content);
        }

        public Node findNode(String id)
        {
            if (root.children.Count > 0)
            {
                for (int i = 0; i < root.children.Count; ++i)
                {
                    if (root.children[i].id.Equals(id))
                    {
                        return root.children[i];
                    }
                }
            }
            return null;
        }
    }

    public class Node
    {
        public String id, content, openTag, closingTag;
        public List<Node> children;
        public int level;
        public Node(String id, String tag, List<String> attributes, int level)
        {
            this.id = id;
            this.openTag = buildTag(tag, attributes, level);
            this.closingTag = String.Format("{0}</{1}>\n", addIndents(level), tag);
            this.children = new List<Node>();
            this.content = "";
            this.level = level;
        }

        public String buildTag(String tag, List<String> attributes, int level)
        {
            String retTag = String.Format("{0}<{1}", addIndents(level), tag);
            if (attributes.Count > 0)
            {
                for (int i = 0; i < attributes.Count; ++i)
                {
                    retTag += String.Format(" {0}", attributes[i]);
                }
            }
            return (retTag + ">\n");
        }

        public String addIndents(int level)
        {
            String retStr = "";
            for (int i = 0; i < level; ++i)
            {
                retStr += "\t";
            }
            return retStr;
        }
    }
}