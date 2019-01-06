using System;
using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SymbolicLab2.Writer.Models
{
    [Serializable]
    [XmlInclude(typeof(MathElement))]
    [XmlInclude(typeof(MfencedElement))]
    [XmlInclude(typeof(char))]
    [XmlInclude(typeof(string))]
    [XmlInclude(typeof(int))]
    [XmlInclude(typeof(MsupElement))]
    public abstract class MathMlTerm
    {
        [XmlIgnore]
        public ArrayList Terms { get; set; }

        [XmlElement(typeof(MathElement), ElementName = "math")]
        [XmlElement(typeof(MfencedElement), ElementName = "mf")]
        [XmlElement(typeof(MsupElement), ElementName = "msup")]
        [XmlElement(typeof(char), ElementName = "mi")]
        [XmlElement(typeof(string), ElementName = "mo")]
        [XmlElement(typeof(int), ElementName = "mn")]
        [XmlElement("Terms"), Browsable(false)]
        public ArrayList TermsProperty
        {
            get {
                for (int i = 0; i < Terms.Count; i++)
                {
                    if (Terms[i] is char)
                    {
                        Terms[i] = ((char)Terms[i]).ToString();
                    }
                }
                return Terms;
            }
            set { Terms = value; }
        }

        public MathMlTerm()
        {
            Terms = new ArrayList();
        }

        [XmlIgnore]
        public bool TermsSpecified
        {
            get { return (Terms.Count > 0); }
        }
    }
}
