﻿namespace dotless.Core.Parser.Infrastructure.Nodes
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using dotless.Core.Utils;

    public abstract class Node
    {
        public int Index { get; set; }

        #region Boolean Operators

        public static implicit operator bool(Node node)
        {
            return node != null;
        }

        public static bool operator true(Node n)
        {
            return n != null;
        }

        public static bool operator false(Node n)
        {
            return n == null;
        }

        public static bool operator !(Node n)
        {
            return n == null;
        }

        public static Node operator &(Node n1, Node n2)
        {
            return n1 != null ? n2 : null;
        }

        public static Node operator |(Node n1, Node n2)
        {
            return n1 ?? n2;
        }

        #endregion

        public virtual StringBuilder ToCSS(Env env, StringBuilder output)
        {
            throw new InvalidOperationException(string.Format("ToCSS() not valid on this type of node. '{0}'",
                                                              GetType().Name));
        }

        public string ToCSS(Env env)
        {
            return ToCSS(env, new StringBuilder())
                .ToString();
        }

        public virtual Node Evaluate(Env env)
        {
            return this;
        }

        public bool IgnoreOutput()
        {
            return
                this is RegexMatchResult ||
                this is CharMatchResult;
        }
    }
}