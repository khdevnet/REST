using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Hal.Engine.Interfaces;

namespace Hal.Engine
{
    public class Link
    {
        public const string RelForSelf = "self";
        public const string RelForCuries = "curies";

        static readonly IEqualityComparer<Link> ComparerInstance = new LinkEqualityComparer();

        string linkRelation;

        public Link()
        { }

        public Link(string href)
        {
            if (string.IsNullOrEmpty(href))
            {
                throw new ArgumentNullException("href");
            }
            Href = href;
        }

        public string Href { get; set; }

        public string Name { get; set; }


        public bool IsTemplated
        {
            get { return !string.IsNullOrEmpty(Href) && IsTemplatedRegex.IsMatch(Href); }
        }

        private static readonly Regex IsTemplatedRegex = new Regex(@"{.+}", RegexOptions.Compiled);


       

        public static IEqualityComparer<Link> EqualityComparer
        {
            get { return ComparerInstance; }
        }
    }


}