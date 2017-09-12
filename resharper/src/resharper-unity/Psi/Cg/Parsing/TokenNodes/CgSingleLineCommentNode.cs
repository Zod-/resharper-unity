﻿using JetBrains.ReSharper.Plugins.Unity.Psi.Cg.Parsing.TokenNodeTypes;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.ReSharper.Plugins.Unity.Psi.Cg.Parsing.TokenNodes
{
    public class CgSingleLineCommentNode : CgTokenNodeBase, ICommentNode
    {
        private readonly string myText;

        public CgSingleLineCommentNode(string text)
        {
            myText = text;
        }

        public override NodeType NodeType => CgTokenNodeTypes.SINGLE_LINE_COMMENT;

        public override int GetTextLength() => myText.Length;
        public override string GetText() => myText;
        public override bool IsFiltered() => true;
        
        public TreeTextRange GetCommentRange()
        {
            // remove two slashes
            var start = GetTreeStartOffset();
            return new TreeTextRange(start + 2, start + GetTextLength());
        }

        // remove two slashes
        public string CommentText => myText.Substring(2);
    }
}